using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;

namespace EmployeeInheritance
{
    public class ChildEmployee : Employee
    {
        public EntitySet Territories
        {
            get
            {
                return (EntitySet)base.Territories;
            }
        }
    }
}
