using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Data.Model
{
    public class KulIslem
    {
        public int kiId { get; set; }
        public int kiKulId { get; set; }
        public int kiMuzikId { get; set; }
        public string kiTarih { get; set; }
        public bool kiOdeme { get; set; }
    }
}
