﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AhoCorasick
{
    public class Program
    {
        public static void Main()
        {
            string mainPattern = Console.ReadLine();
            string text = Console.ReadLine();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            Dictionary<string, int> patternCount = new Dictionary<string, int>();
            Dictionary<string, int> patternOcc = new Dictionary<string, int>();

            AhoCorasick.Trie trie = new AhoCorasick.Trie();

            for (int i = 1; i < mainPattern.Length; i++)
            {
                string pattern1 = mainPattern.Substring(0, i);
                string pattern2 = mainPattern.Substring(i, mainPattern.Length - i);

                trie.Add(pattern1);
                trie.Add(pattern2);
                if (!pairs.ContainsKey(pattern1))
                {
                    pairs.Add(pattern1, pattern2);
                }
                if (!patternCount.ContainsKey(pattern1))
                {
                    patternCount.Add(pattern1, 0);
                }
                if (!patternCount.ContainsKey(pattern2))
                {
                    patternCount.Add(pattern2, 0);
                }
                if (!patternOcc.ContainsKey(pattern1))
                {
                    patternOcc.Add(pattern1, 0);
                }
                if (!patternOcc.ContainsKey(pattern2))
                {
                    patternOcc.Add(pattern2, 0);
                }
                patternOcc[pattern1]++;
                patternOcc[pattern2]++;
            }

            patternCount.Add(mainPattern, 0);
            trie.Add(mainPattern);

            // build search tree
            trie.Build();
            // find words
            var words = trie.Find(text);
            foreach (string word in words)
            {
                patternCount[word]++;
            }

            int counter = 0;
            foreach (var item in pairs)
            {
                counter += patternCount[item.Key] / patternOcc[item.Key] * patternCount[item.Value] / patternOcc[item.Value];
            }

            counter += patternCount[mainPattern];

            Console.WriteLine(counter);
        }
    }

    /// <summary>
    /// Trie that will find and return strings found in a text.
    /// </summary>
    public class Trie : Trie<string>
    {
        /// <summary>
        /// Adds a string.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public void Add(string s)
        {
            Add(s, s);
        }

        /// <summary>
        /// Adds multiple strings.
        /// </summary>
        /// <param name="strings">The strings to add.</param>
        public void Add(IEnumerable<string> strings)
        {
            foreach (string s in strings)
            {
                Add(s);
            }
        }
    }

    /// <summary>
    /// Trie that will find strings in a text and return values of type <typeparamref name="T"/>
    /// for each string found.
    /// </summary>
    /// <typeparam name="TValue">Value type.</typeparam>
    public class Trie<TValue> : Trie<char, TValue>
    {
    }

    /// <summary>
    /// Trie that will find strings or phrases and return values of type <typeparamref name="T"/>
    /// for each string or phrase found.
    /// </summary>
    /// <remarks>
    /// <typeparamref name="T"/> will typically be a char for finding strings
    /// or a string for finding phrases or whole words.
    /// </remarks>
    /// <typeparam name="T">The type of a letter in a word.</typeparam>
    /// <typeparam name="TValue">The type of the value that will be returned when the word is found.</typeparam>
    public class Trie<T, TValue>
    {
        /// <summary>
        /// Root of the trie. It has no value and no parent.
        /// </summary>
        private readonly Node<T, TValue> root = new Node<T, TValue>();

        /// <summary>
        /// Adds a word to the tree.
        /// </summary>
        /// <remarks>
        /// A word consists of letters. A node is built for each letter.
        /// If the letter type is char, then the word will be a string, since it consists of letters.
        /// But a letter could also be a string which means that a node will be added
        /// for each word and so the word is actually a phrase.
        /// </remarks>
        /// <param name="word">The word that will be searched.</param>
        /// <param name="value">The value that will be returned when the word is found.</param>
        public void Add(IEnumerable<T> word, TValue value)
        {
            // start at the root
            var node = root;

            // build a branch for the word, one letter at a time
            // if a letter node doesn't exist, add it
            foreach (T c in word)
            {
                var child = node[c];

                if (child == null)
                    child = node[c] = new Node<T, TValue>(c, node);

                node = child;
            }

            // mark the end of the branch
            // by adding a value that will be returned when this word is found in a text
            node.Values.Add(value);
        }


        /// <summary>
        /// Constructs fail or fall links.
        /// </summary>
        public void Build()
        {
            // construction is done using breadth-first-search
            var queue = new Queue<Node<T, TValue>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                // visit children
                foreach (var child in node)
                    queue.Enqueue(child);

                // fail link of root is root
                if (node == root)
                {
                    root.Fail = root;
                    continue;
                }

                var fail = node.Parent.Fail;

                while (fail[node.Word] == null && fail != root)
                    fail = fail.Fail;

                node.Fail = fail[node.Word] ?? root;
                if (node.Fail == node)
                    node.Fail = root;
            }
        }

        /// <summary>
        /// Finds all added words in a text.
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <returns>The values that were added for the found words.</returns>
        public IEnumerable<TValue> Find(IEnumerable<T> text)
        {
            var node = root;

            foreach (T c in text)
            {
                while (node[c] == null && node != root)
                    node = node.Fail;

                node = node[c] ?? root;

                for (var t = node; t != root; t = t.Fail)
                {
                    foreach (TValue value in t.Values)
                        yield return value;
                }
            }
        }

        /// <summary>
        /// Node in a trie.
        /// </summary>
        /// <typeparam name="TNode">The same as the parent type.</typeparam>
        /// <typeparam name="TNodeValue">The same as the parent value type.</typeparam>
        private class Node<TNode, TNodeValue> : IEnumerable<Node<TNode, TNodeValue>>
        {
            private readonly TNode word;
            private readonly Node<TNode, TNodeValue> parent;
            private readonly Dictionary<TNode, Node<TNode, TNodeValue>> children = new Dictionary<TNode, Node<TNode, TNodeValue>>();
            private readonly List<TNodeValue> values = new List<TNodeValue>();

            /// <summary>
            /// Constructor for the root node.
            /// </summary>
            public Node()
            {
            }

            /// <summary>
            /// Constructor for a node with a word
            /// </summary>
            /// <param name="word"></param>
            /// <param name="parent"></param>
            public Node(TNode word, Node<TNode, TNodeValue> parent)
            {
                this.word = word;
                this.parent = parent;
            }

            /// <summary>
            /// Word (or letter) for this node.
            /// </summary>
            public TNode Word
            {
                get { return word; }
            }

            /// <summary>
            /// Parent node.
            /// </summary>
            public Node<TNode, TNodeValue> Parent
            {
                get { return parent; }
            }

            /// <summary>
            /// Fail or fall node.
            /// </summary>
            public Node<TNode, TNodeValue> Fail
            {
                get;
                set;
            }

            /// <summary>
            /// Children for this node.
            /// </summary>
            /// <param name="c">Child word.</param>
            /// <returns>Child node.</returns>
            public Node<TNode, TNodeValue> this[TNode c]
            {
                get { return children.ContainsKey(c) ? children[c] : null; }
                set { children[c] = value; }
            }

            /// <summary>
            /// Values for words that end at this node.
            /// </summary>
            public List<TNodeValue> Values
            {
                get { return values; }
            }

            /// <inherit/>
            public IEnumerator<Node<TNode, TNodeValue>> GetEnumerator()
            {
                return children.Values.GetEnumerator();
            }

            /// <inherit/>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            /// <inherit/>
            public override string ToString()
            {
                return Word.ToString();
            }
        }
    }
}
