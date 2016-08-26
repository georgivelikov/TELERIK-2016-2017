using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.HasStarted = false;
        }
    }
}
