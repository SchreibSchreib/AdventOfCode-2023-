using Day16.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16.Signs
{
    internal class SplitterUpDown : FieldSign
    {
        protected override Dictionary<string, string> GetDirections()
        {
            return new Dictionary<string, string>
            {
                { ">", "^,v" },
                { "^", "^" },
                { "v", "v" },
                { "<", "^,v" }
            };
        }
    }
}
