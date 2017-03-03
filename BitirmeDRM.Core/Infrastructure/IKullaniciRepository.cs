using BitirmeDRM.Data.Model;
using System.Collections.Generic;

namespace BitirmeDRM.Core.Infrastructure
{
    interface IKullaniciRepository : IRepository<Kullanici>
    {
        NIslemSonuc<Kullanici> Giris(string kulAdi, string sifre);
        NIslemSonuc<bool> UyeOl(Kullanici k);
        NIslemSonuc<bool> SifremiUnuttum(string ePosta);
        NIslemSonuc<bool> SiparisKaydet(KulIslem ki);
        NIslemSonuc<IList<KulIslem>> Siparisler(int kulId);
    }
}
