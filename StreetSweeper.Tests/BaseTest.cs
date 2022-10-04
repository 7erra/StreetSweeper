﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Tests
{
    public abstract class BaseTest
    {
        internal readonly EnvironmentVariableTarget target = EnvironmentVariableTarget.Process;

        internal void SetPath(string value)
        {
            Environment.SetEnvironmentVariable("Path", value, target);
        }

        internal string? GetPath()
        {
            return Environment.GetEnvironmentVariable("Path", target);
        }
    }
}