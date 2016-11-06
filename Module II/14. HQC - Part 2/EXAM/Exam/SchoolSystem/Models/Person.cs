using System;
using System.Text.RegularExpressions;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public abstract class Person : IPerson
    {
        private const int MinFirstNameLength = 2;
        private const int MaxFirstNameLength = 31;
        private const int MinLastNameLength = 2;
        private const int MaxLastNameLength = 31;
        private const string NamePattern = "^[A-Za-z]+$";
        private const string InvalidNameLenghtMessage = "Invalid name lenght!";
        private const string InvalidNameSymbolsMessage = "Invalid name symbols!";

        private readonly string firstName;
        private readonly string lastName;

        public Person(string firstName, string lastName)
        {
            this.ValidateNameLenght(firstName, MinFirstNameLength, MaxFirstNameLength);
            this.ValidateNameLenght(lastName, MinLastNameLength, MaxLastNameLength);
            this.ValidateNameSymbols(firstName, NamePattern);
            this.ValidateNameSymbols(lastName, NamePattern);

            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        private void ValidateNameLenght(string name, int min, int max)
        {
            if (name.Length < min || name.Length > max)
            {
                throw new ArgumentException(InvalidNameLenghtMessage);
            }
        }

        private void ValidateNameSymbols(string name, string pattern)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                throw new ArgumentException(InvalidNameSymbolsMessage);
            }
        }
    }
}
