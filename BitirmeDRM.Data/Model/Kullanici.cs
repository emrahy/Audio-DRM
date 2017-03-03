using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Data.Model
{
    public class Kullanici
    {
        public int kulId { get; set; }
        public string kulAdi { get; set; }
        public string kulTamAdi { get; set; }
        public string kulEposta { get; set; }
        public string kulSifre { get; set; }
        public bool kulDurum { get; set; }
    }
}
