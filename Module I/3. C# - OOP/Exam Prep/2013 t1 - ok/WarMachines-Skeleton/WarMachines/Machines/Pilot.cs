namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private readonly string name;

        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.ValidateName(name);
            this.name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "{0} - {1} {2}\n",
                this.Name,
                this.machines.Count == 0 ? "no" : this.machines.Count.ToString(),
                this.machines.Count == 1 ? "machine" : "machines");
            foreach (var m in this.machines)
            {
                sb.AppendLine(m.ToString());
            }

            return sb.ToString().Trim();
        }

        private void ValidateName(string pilotName)
        {
            if (string.IsNullOrWhiteSpace(pilotName))
            {
                throw new ArgumentNullException("Pilot must have name");
            }
        }
    }
}
