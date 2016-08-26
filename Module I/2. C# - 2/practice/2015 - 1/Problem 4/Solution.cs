﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodCalls
{
    class Program
    {
        // taken from https://msdn.microsoft.com/en-us/library/x53a06bb.aspx - remove all known keywords which can invoke methods (primitive data types) - example int.Parse
        private static string[] keywords = new string[] 
        {
            "abstract",
            "as",
            "base",
            "break",
            "case",
            "catch",
            "checked",
            "class",
            "const",
            "continue",
            "default",
            "delegate",
            "do",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "interface",
            "internal",
            "is",
            "lock",
            "namespace",
            "new",
            "null",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sealed",
            "sizeof",
            "stackalloc",
            "static",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "unchecked",
            "unsafe",
            "using",
            "virtual",
            "void",
            "volatile",
            "while"
        };

        static bool CheckForMethodCall(string line, int position)
        {
            for (int i = position; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    continue;
                }

                if (line[i] == '(')
                {
                    return true;
                }

                break;
            }

            return false;
        }

        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<string> methodCalls = new List<string>();

            int foundMethods = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                var currentReadLine = Console.ReadLine();

                currentReadLine = currentReadLine.Trim();
                int indexOfMethodDeclaration = 0;

                if (currentReadLine.IndexOf("static ") == 0)
                {
                    if (methodCalls.Count > 0)
                    {
                        Console.Write(methodCalls.Count);
                        Console.Write(" -> ");
                        Console.WriteLine(string.Join(", ", methodCalls));
                    }

                    if (foundMethods > 0 && methodCalls.Count == 0)
                    {
                        Console.WriteLine("None");
                    }

                    methodCalls.Clear();

                    int indexOfOpenBracket = currentReadLine.IndexOf("(");
                    int indexOfWhiteSpace = indexOfOpenBracket;

                    while (!char.IsLetter(currentReadLine[indexOfWhiteSpace]))
                    {
                        indexOfWhiteSpace--;
                    }

                    int indexOfSpaceBeforeBracket = currentReadLine.LastIndexOf(" ", indexOfWhiteSpace);
                    indexOfMethodDeclaration = indexOfOpenBracket;

                    Console.Write(currentReadLine.Substring(indexOfSpaceBeforeBracket + 1, indexOfOpenBracket - indexOfSpaceBeforeBracket - 1).Trim());
                    Console.Write(" -> ");
                    foundMethods++;
                }

                var currentWord = new StringBuilder();

                bool isKeyWord = false;
                string lastKeyword = string.Empty;

                for (int j = indexOfMethodDeclaration; j < currentReadLine.Length; j++)
                {
                    if (char.IsLetter(currentReadLine[j]))
                    {
                        currentWord.Append(currentReadLine[j]);
                        continue;
                    }

                    if (!char.IsLetter(currentReadLine[j]) && currentWord.Length > 0)
                    {
                        var currentWordString = currentWord.ToString();
                        if (Array.IndexOf(keywords, currentWordString) > -1)
                        {
                            isKeyWord = true;
                            currentWord.Clear();
                            lastKeyword = currentWordString;
                            continue;
                        }
                        else if (lastKeyword != "new")
                        {
                            isKeyWord = false;
                        }

                        if (CheckForMethodCall(currentReadLine, j))
                        {
                            if (isKeyWord)
                            {
                                isKeyWord = false;
                                currentWord.Clear();
                                continue;
                            }

                            isKeyWord = false;

                            methodCalls.Add(currentWordString);
                        }

                        currentWord.Clear();
                    }
                }
            }

            if (methodCalls.Count > 0)
            {
                Console.Write(methodCalls.Count);
                Console.Write(" -> ");
                Console.WriteLine(string.Join(", ", methodCalls));
            }

            if (foundMethods > 0 && methodCalls.Count == 0)
            {
                Console.WriteLine("None");
            }
        }
    }
}
