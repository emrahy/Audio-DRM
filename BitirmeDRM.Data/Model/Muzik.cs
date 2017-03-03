using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Data.Model
{
    public class Muzik
    {
        public int MuzikId { get; set; }
        public string MuzikAdi { get; set; }
        public string MuzikSanatci { get; set; }
        public string MuzikUzunluk { get; set; }
        public int MuzikBoyut { get; set; }
        public int KategoriId { get; set; }
        public int MuzikIndirme { get; set; }
        public string MuzikGorsel { get; set; }
        public bool MuzikYayin { get; set; }
        public string MuzikDosya { get; set; }

    }
}
