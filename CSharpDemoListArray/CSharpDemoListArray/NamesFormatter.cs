using System;
using System.Collections.Generic;

namespace DataAccess
{
    class NamesFormatter
    {
        public string Format(List<string> names)
        {
            return string.Join(Environment.NewLine, names);
        }
    }
}
