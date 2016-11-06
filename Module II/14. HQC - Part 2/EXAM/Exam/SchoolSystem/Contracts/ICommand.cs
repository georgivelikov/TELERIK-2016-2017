using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Holds abstract information about how Command Object should look.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute command in a specific way.
        /// </summary>
        /// <param name="commandArgs">List of string holding command args.</param>
        /// <param name="data">SchoolSystem data holds information about teaches and students in the system</param>
        /// <returns>Retursns string with a message describing execution result.</returns>
        string Execute(IList<string> commandArgs, ISchoolSystemData data);
    }
}
