using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyumolcsBolt
{
    public class Aru
    {
        public string Nev { get; set; }
        public decimal Ar { get; set; }
        public decimal Mennyiseg { get; set; }
        public Egyseg Mertekegyseg { get; set; }

        public override string ToString()
        {
            return $"Név: {Nev}, Ár: {Ar}, Mennyiség: {Mennyiseg} {Mertekegyseg}";
        }
    }
}
