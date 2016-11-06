﻿using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public abstract class Command : ICommand
    {
        public abstract string Execute(IList<string> commandArgs, ISchoolSystemData data);
    }
}
