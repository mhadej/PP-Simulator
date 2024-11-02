using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min = 1, int max = 10) 
        {
            return (value >= min && value <= max) ? value : (value < min ? min : max);
        }

        public static string Shortener(string value, int min = 3, int max = 25, char placeholder = '#')
        {
            string name = value;

            name = string.IsNullOrEmpty(value) ? "Unknown" : value.Trim();
            name = name.Length >= min ? name : name + new string(placeholder, (min - name.Length));
            name = name.Length > max ? name[..max] : name;
            name = name.Trim();
            name = name.Length >= min ? name : name + new string(placeholder, (min - name.Length));
            name = name.ToUpper()[0] + name[1..name.Length];

            return name;
        }
    }
}


