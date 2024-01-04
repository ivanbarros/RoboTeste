﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Core.Configurations.Database
{
    public static class GetMigrationClass
    {
        public static Assembly[] Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x =>
                    typeof(Migration).IsAssignableFrom(x) &&
                    x != typeof(Migration) &&
                    x.GetCustomAttributes(typeof(MigrationAttribute), true).Length > 0)
                .Select(x => x.Assembly).ToArray();
        }
    }
}
