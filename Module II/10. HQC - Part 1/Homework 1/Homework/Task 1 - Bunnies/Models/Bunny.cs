using System.Text;

using Enums;
using Extensions;
using Interfaces;

namespace Models
{
    public class Bunny
    {
        private const int StringBuilderSize = 200;

        private int age;

        private string name;

        private FurType furType;

        private string furTypeString;

        public Bunny(string name, int age, FurType furType)
        {
            this.Name = name;
            this.Age = age;
            this.FurType = furType;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                //add validation if needed
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                //add validation if needed
                this.age = value;
            }
        }

        public FurType FurType
        {
            get
            {
                return this.furType;
            }
            set
            {
                this.furType = value;
                this.furTypeString = this.furType.ToString().SplitToSeparateWordsByUppercaseLetter();
            }
        }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine($"{this.Name} - \"I am {this.Age} years old!\"");
            writer.WriteLine($"{this.Name} - \"And I am {this.furTypeString}");
        }

        public override string ToString()
        {
            var builder = new StringBuilder(StringBuilderSize);

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {this.furTypeString}");

            return builder.ToString();
        }
    }
}