using DRM.VeriGizleme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitirmeDRM.PlayerList
{
    public partial class Form1 : Form
    {
        WMPLib.IWMPPlaylist playlist;
        WMPLib.IWMPMedia media;
        public List<WaveSplit> waveList;
        public Form1()
        {
            InitializeComponent();
        }
        string[] f, p;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Uygulama kapatılınca playlisti sil
            axWindowsMediaPlayer1.playlistCollection.remove(playlist);
            DeleteTempFile();
        }

        private void DeleteTempFile()
        {
            foreach (WaveSplit item in waveList)
            {
                try { File.Delete(item.newFilePath); }
                catch { } // best effort
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WMP playlist oluştur
            playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("playlistDRM");

        }

        private void oynatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void durdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();

        }

        private void yukleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] fPaths;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fPaths = openFileDialog1.FileNames;
                //WaveKontrol(WaveKontrol(fPaths));
                PlayListOlustur(fPaths);

            }
        }
        WaveIslem waveIslem = new WaveIslem();
        GetHWID hwid = new GetHWID();
        //DRM Kontrol 
        public List<WaveSplit> WaveKontrol(string[] list)
        {
            List<WaveSplit> newList = new List<WaveSplit>();
            try
            {
                string LocalHwid = hwid.Value();
                foreach (string item in list)
                {
                    WaveSplit ws = new WaveSplit();
                    Byte[] bytes = File.ReadAllBytes(item);
                    string mesaj = waveIslem.MesajOku(bytes);
                    string[] mList = mesaj.Split(',');
                    if (mList[0] == LocalHwid)
                    {
                        MemoryStream waveData = new MemoryStream();
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            waveData = WaveDosya.CreateStream(ms);
                        }
                        byte[] dataByte = waveData.ToArray();
                      
                        ws.filePath = item;
                        ws.muzikAdi = mList[1];
                        ws.muzikUzunluk = mList[2];
                        ws.muzikSanatci = mList[3];
                        string myTempFile = Path.ChangeExtension(Path.GetTempPath() + ws.muzikAdi + " - " + ws.muzikSanatci, ".wav");
                        File.WriteAllBytes(myTempFile, dataByte);
                        ws.newFilePath = myTempFile;
                        newList.Add(ws);
                    }
                    //DRM EŞLEŞME HATASI, UYARI MESAJI
                    else
                        MessageBox.Show("Dosya: " + item + "\nDRM içermeyen dosya oynatılamadı!");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return newList;
        }

        private void listeyiTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.playlistCollection.remove(playlist);
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.currentPlaylist.clear();
            listView1.Clear();
            DeleteTempFile();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int listIndex = listView1.SelectedIndices[0];
            axWindowsMediaPlayer1.Ctlcontrols.playItem(playlist.Item[listIndex]);
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    item.ForeColor = Color.Black;
            //}
            //listView1.Items[listIndex].ForeColor = Color.Blue;
        }


        public void PlayListOlustur(string[] list)
        {
            waveList = WaveKontrol(list);
            int plCount = playlist.count;
            //playlist daha önce oluşturuldu ise
            if (plCount > 0)
            {
                
                foreach (WaveSplit file in waveList)
                {
                    media = axWindowsMediaPlayer1.newMedia(file.newFilePath);
                    axWindowsMediaPlayer1.currentPlaylist.insertItem(playlist.count, media);
                    string[] parca = { file.muzikAdi,file.muzikSanatci,media.durationString };
                    
                    listView1.Items.Add(new ListViewItem(parca));
                }
            }
            //yeni playlist
            else
            {
                foreach (WaveSplit file in waveList)
                {
                    media = axWindowsMediaPlayer1.newMedia(file.newFilePath);
                    playlist.appendItem(media);
                    string[] parca = { file.muzikAdi, file.muzikSanatci, media.durationString };
                    listView1.Items.Add(new ListViewItem(parca));
                }
                axWindowsMediaPlayer1.currentPlaylist = playlist;

            }

        }
    }
}
