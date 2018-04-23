using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Repository
{
    public static class Configuration
    {
        public static readonly string Database;

        static Configuration()
        {
            Database = "Mental.db";
        }
    }
}
