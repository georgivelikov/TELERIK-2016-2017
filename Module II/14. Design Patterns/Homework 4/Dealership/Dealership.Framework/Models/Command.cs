using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Dealership.Contracts;

namespace Dealership.Models
{
    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private string name;
        private IList<string> parameters;

        public Command(string inputLine)
        {
            this.parameters = new List<string>();
            this.TranslateInput(inputLine);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
            var indexOfOpenComment = input.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = input.IndexOf(CommentCloseSymbol);
            Regex regex = new Regex("{{.+(?=}})}}");

            if (indexOfFirstSeparator < 0)
            {
                this.Name = input;
                return;
            }

            this.Name = input.Substring(0, indexOfFirstSeparator);

            if (indexOfOpenComment >= 0)
            {
                this.parameters.Add(input.Substring(indexOfOpenComment + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                input = regex.Replace(input, string.Empty);
            }

            ((List<string>)this.parameters).AddRange(input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));
        }


    }
}
