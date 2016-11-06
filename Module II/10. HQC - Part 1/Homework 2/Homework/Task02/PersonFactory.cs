using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class PersonFactory
    {
        public Person CreatePerson(string name, int age)
        {
            if (age % 2 == 0)
            {
                return this.CreateMale(name, age);
            }
            else
            {
                return this.CreateFemale(name, age);
            }

        }

        private Person CreateMale(string name, int age)
        {
            return new Person(name, age, GenderType.Male);
        }

        private Person CreateFemale(string name, int age)
        {
            return new Person(name, age, GenderType.Female);
        }
    }
}
