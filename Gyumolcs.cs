using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyumolcsBolt
{
    public class Gyumolcs : Aru
    {
        public bool Friss { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Friss: {Friss}";
        }
    }
}
