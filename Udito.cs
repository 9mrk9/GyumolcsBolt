using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyumolcsBolt
{
    public class Udito : Aru
    {
        public int GyumolcsTartalomSzazalek { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Gyümölcstartalom: {GyumolcsTartalomSzazalek}%";
        }

        public decimal GetGyumolcsMennyiseg()
        {
            return  (decimal) (Mennyiseg * GyumolcsTartalomSzazalek / 100);
        }
    }
}
