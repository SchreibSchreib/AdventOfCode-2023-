﻿using Day16.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16.Signs
{
    internal class EmptySpace : FieldSign
    {


        protected override Dictionary<char, string> GetDirections()
        {
            return new Dictionary<char, string>
            {
                { '>', ">" },
                { '^', "^" },
                { 'v', "v" },
                { '<', "<" }
            };
        }
    }
}
