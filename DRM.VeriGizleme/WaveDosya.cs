using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DRM.VeriGizleme
{
    public class WaveDosya
    {
        //Parça kimliği 4 byte "RIFF"  karakterlerinin ascii kodunu içerir
        //Boyut 4 Byte - Başlangıç Posizyonu 0
        public string ChunkId { get; set; }

        //ChunkID(4 Byte) ve ChunkSize(4 Byte) den sonra gelen verinin boyutunu tutar.(Tüm veri - 8 Byte)
        //Boyut 4 Byte - Başlangıç Posizyonu 4
        public int ChunkSize { get; set; }

        //Dosya formatı "WAVE" karakterlerinin ascii kodunu içerir
        //Boyut 4 Byte - Başlangıç Posizyonu 8
        public string Format { get; set; }

        //Alt parça1 kimliği "fmt " karakterlerinin ascii kodunu içerir
        //Boyut 4 Byte - Başlangıç Posizyonu 12
        public string SubChunk1Id { get; set; }

        //Alt parça1 boyutu PCM( Pulse-code Modulation (Darbe Kod Modülasyonu)) dosyaları için bu değer 16 dır.
        //Boyut 4 Byte - Başlangıç Posizyonu 16
        public int SubChunk1Size { get; set; }

        //Sıkıştırılmamış dosyalar için bu değer 1dir. Eğer 1den farklı bir değer okursanız, okuyacağınız değer dosyanın hangi formatta sıkıştırılmış olduğunu gösterir.
        //Boyut 2 Byte - Başlangıç Posizyonu 20
        public int AudioFormat { get; set; }

        //Kanal Sayısı Mono = 1, Stereo = 2, vb.
        //Boyut 2 Byte - Başlangıç Posizyonu 22
        public int NumChannels { get; set; }

        //Örnekleme frekansı, örnekleme frekansının değerini tutar 8000, 44100, vb.
        //Boyut 4 Byte - Başlangıç Posizyonu 
        public int SampleRate { get; set; }

        //Bayt oranı Saniyede kaç bayt okunması gerektiğini gösterir.
        //Değeri (ÖrneklemeFrekansı*KanalSayısı*ÖrnekBaşınaBit/8) işlemiyle hesaplanır.
        //Boyut 4 Byte - Başlangıç Posizyonu 28
        public int ByteRate { get; set; }

        //Blok boyutu. Blok, tüm kanallarda anlık olarak sese dönüştürülmeye hazırlanan örneklerden oluşur. Yani her blokta kanal sayısı kadar örnek bulunur. 
        //Değeri (KanalSayısı*ÖrnekBaşınaBit/8) işlemiyle hesaplanır.
        //Boyut 2 Byte - Başlangıç Posizyonu 32
        public int BlockAlign { get; set; }

        //Örnek başına bit. Her örneğin kaç bit ile ifade edildiğini gösterir. 8, 16, 24 ... değererini alabilir.
        //Boyut 2 Byte - Başlangıç Posizyonu 34
        public int BitPerSample { get; set; }

        //Alt parça2 kimliği "data" karakterlerinin ascii kodlarını içerir
        //Boyut 2 Byte - Başlangıç Posizyonu 36
        public string SubChunk2Id { get; set; }

        //Bu kısımdan sonra gelecek veri boyutunu yani aslında ses verisinin boyutunu gösterir.
        //Boyut 4 Byte - Başlangıç Posizyonu 40
        public int SubChunk2Size { get; set; }

        //Ses dosyası
        //Boyut SubChunk2Size kadar - Başlangıç Posizyonu 44
        public Byte[] Data { get; set; }

        public Byte[] WaveFormatBilgisi { get; set; }

        public WaveDosya(Byte[] waveKaynak)
        {
            Stream stream = new MemoryStream(waveKaynak);
            BinaryReader Reader = new BinaryReader(stream);
            ChunkId = GetReaderString(0, 4, Reader);
            ChunkSize = GetReaderInt(4, 4, Reader);
            Format = GetReaderString(8, 4, Reader);
            SubChunk1Id = GetReaderString(12, 4, Reader);
            SubChunk1Size = GetReaderInt(16, 4, Reader);
            AudioFormat = GetReaderInt(20, 2, Reader);
            NumChannels = GetReaderInt(22, 2, Reader);
            SampleRate = GetReaderInt(24, 4, Reader);
            ByteRate = GetReaderInt(28, 4, Reader);
            BlockAlign = GetReaderInt(32, 2, Reader);
            BitPerSample = GetReaderInt(34, 2, Reader);
            SubChunk2Id = GetReaderString(36, 4, Reader);
            SubChunk2Size = GetReaderInt(40, 4, Reader);
            Data = GetReaderByte(44, SubChunk2Size, Reader);
            //Wave dosya formatı kontrolü
            //WaveFormatKontrol();
        }

        public void WaveDosya2(Byte[] waveKaynak)
        {
            Stream stream = new MemoryStream(waveKaynak);
            BinaryReader Reader = new BinaryReader(stream);
            ChunkId = "RIFF";
            ChunkSize = waveKaynak.Length + 2752;
            Format = "WAVE";
            SubChunk1Id = "fmt ";
            SubChunk1Size = 16;
            AudioFormat = 1;
            NumChannels = 2;
            SampleRate = 44100;
            ByteRate = 176400;
            BlockAlign = 4;
            BitPerSample = 16;
            SubChunk2Id = "data";
            SubChunk2Size = waveKaynak.Length;
            Data = waveKaynak;
            //Wave dosya formatı kontrolü
            string myTempFile = Path.Combine(Path.GetTempPath(), "test.wav");
            using (StreamWriter sw = new StreamWriter(myTempFile))
            {
                sw.WriteLine(ChunkId);
                sw.WriteLine(ChunkSize);
                sw.WriteLine(Format);
                sw.WriteLine(SubChunk1Id);
                sw.WriteLine(SubChunk1Size);
                sw.WriteLine(AudioFormat);
                sw.WriteLine(NumChannels);
                sw.WriteLine(SampleRate);
                sw.WriteLine(ByteRate);
                sw.WriteLine(BlockAlign);
                sw.WriteLine(BitPerSample);
                sw.WriteLine(SubChunk2Id);
                sw.WriteLine(SubChunk2Size);
                sw.WriteLine(Data);

            }
        }

        public static MemoryStream CreateStream(Stream waveData)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF".ToCharArray()));

            writer.Write((Int32)(waveData.Length + 36)); //File length minus first 8 bytes of RIFF description

            writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVEfmt ".ToCharArray()));

            writer.Write((Int32)16); //length of following chunk: 16

            writer.Write((Int16)1);
            writer.Write((Int16)2);
            writer.Write((Int32)44100);
            writer.Write((Int32)176400);
            writer.Write((Int16)4);
            writer.Write((Int16)16);

            writer.Write(System.Text.Encoding.ASCII.GetBytes("data".ToCharArray()));

            writer.Write((Int32)waveData.Length);

            waveData.Seek(0, SeekOrigin.Begin);
            byte[] b = new byte[waveData.Length];
            waveData.Read(b, 0, (int)waveData.Length);
            writer.Write(b);

            writer.Seek(0, SeekOrigin.Begin);
            return stream;
        }


        //Dosya format kontrolü, hatalı değer bulunur ise işlem iptal edilir.
        public void WaveFormatKontrol()
        {
            if (ChunkId != "RIFF")
                throw new Exception("Geçersiz dosya formatı.");
            if (Format != "WAVE")
                throw new Exception("Geçersiz dosya formatı.");
            if (SubChunk1Id != "fmt ")
                throw new Exception("Geçersiz dosya formatı.");
            //PCM( Pulse-code Modulation (Darbe Kod Modülasyonu)) dosyaları için bu değer 16 dır.
            if (SubChunk1Size < 16)
                throw new Exception("Geçersiz dosya formatı.");
            if (AudioFormat != 1)
                throw new Exception("Geçersiz dosya formatı.");
            if (SubChunk2Id != "data")
                throw new Exception("Geçersiz dosya formatı.");
        }
        public Byte[] WaveReadFormat(Byte[] waveKaynak)
        {
            Stream stream = new MemoryStream(waveKaynak);
            BinaryReader Reader = new BinaryReader(stream);
            return GetReaderByte(0, 44, Reader);
        }

        private string GetReaderString(int baslangicAdresi, int boyut, BinaryReader reader)
        {
            byte[] ch = new byte[boyut];
            reader.Read(ch, 0, ch.Length);
            return Encoding.ASCII.GetString(ch);
        }
        private int GetReaderInt(int baslangicAdresi, int boyut, BinaryReader reader)
        {
            int result;
            try
            {
                byte[] ch = new byte[4];
                reader.Read(ch, 0, boyut);
                result = BitConverter.ToInt32(ch, 0);
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }

        private Byte[] GetReaderByte(int baslangicAdresi, int boyut, BinaryReader reader)
        {
            byte[] ch = new byte[boyut];
            reader.Read(ch, 0, ch.Length);
            return ch;
        }
    }
}
