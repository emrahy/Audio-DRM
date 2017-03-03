using BitirmeDRM.Core.Infrastructure;
using BitirmeDRM.Data.Model;
using DRM.VeriGizleme;
using System;
using System.IO;
using System.Web.Mvc;

namespace BitirmeDRM.UI.Controllers
{
    public class HomeController : Controller
    {
        WaveIslem waveIslem = new WaveIslem();

        private readonly IMuzikRepository _muzikRepository;
        private readonly IKategoriRepository _kategoriRepository;
        public HomeController(IMuzikRepository muzikRepository, IKategoriRepository kategoriRespository)
        {
            _muzikRepository = muzikRepository;
            _kategoriRepository = kategoriRespository;
        }
        public ActionResult Index()
        {
            var MuzikList = _muzikRepository.GetAll();
            ViewData["Kategori"] = _kategoriRepository.GetAll();
            return View(MuzikList);
        }
        GetHWID _getHwid = new GetHWID();
        public ActionResult DownloadFile(string hwid,int mid)
        {
            Muzik m = _muzikRepository.GetById(mid);

            string fileName = m.MuzikAdi + ".drm";
            MesajGizle _mesajG = new MesajGizle();

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(m.MuzikDosya));

            string pathFile = HttpContext.Server.MapPath(m.MuzikDosya);
            string pathSaveFile = Server.MapPath("~/Content/wave/result");


            //Dosyayı byte olarak oku
            Byte[] bytes = System.IO.File.ReadAllBytes(pathFile);
            WaveDosya waveStream = new WaveDosya(bytes);
            //donanım bilgisini md5 koda dönüştür
            hwid = _getHwid.GetHash(hwid);
            string gizlenecekMesaj = hwid + "," + m.MuzikAdi + "," + m.MuzikUzunluk + "," + m.MuzikSanatci;
            //mesaj içeriği ve uzunluk(max 2.147.483.647(int))
            //Wave ses dosyasına mesaj gizleme işlemi
            Byte[] sonuc = _mesajG.Gizle(gizlenecekMesaj, waveStream.Data, pathSaveFile);
            Byte[] waveSonuc = ByteArrayBirlestir(waveStream.WaveReadFormat(bytes), sonuc);
            return File(sonuc, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public byte[] ByteArrayBirlestir(byte[] a, byte[] b)
        {
            byte[] bytes = new byte[a.Length + b.Length];

            Array.Copy(a, 0, bytes, 0, a.Length);
            Array.Copy(b, 0, bytes, a.Length, b.Length);
            return bytes;
        }
        public ActionResult ActiveX()
        {
            return View();
        }
    }

}