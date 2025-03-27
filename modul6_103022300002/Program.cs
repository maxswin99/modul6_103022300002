using System;
using System.Collections.Generic;
using System.Diagnostics;

class VideoSayaTube
{
    private int id;
    private string judul;
    private int jumlahTayang;

    
    public VideoSayaTube(string judul)
    {
        Debug.Assert(judul != null, "Judul tidak boleh null");
        Debug.Assert(judul.Length <= 100, "Judul tidak boleh lebih dari 100 karakter");

        this.id = new Random().Next(10000, 99999); 
        this.judul = judul;
        this.jumlahTayang = 0;
    }

    
    public void TambahJumlahTayang(int jumlah)
    {
        Debug.Assert(jumlah > 0 && jumlah <= 1000000, "Jumlah harus antara 1 dan 1.000.000");

        try
        {
            checked
            {
                this.jumlahTayang += jumlah;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Kesalahan: jumlah tayangan melebihi batas maksimum.");
        }
    }

    
    public void CetakDetailVideo()
    {
        Console.WriteLine($"ID Video     : {this.id}");
        Console.WriteLine($"Judul Video  : {this.judul}");
        Console.WriteLine($"Jumlah Tayang: {this.jumlahTayang}");
        Console.WriteLine("------------------------------------");
    }

    public int GetJumlahTayang()
    {
        return jumlahTayang;
    }
}

class PenggunaSayaTube
{
    private string namaPengguna;
    private List<VideoSayaTube> daftarVideo;

    
    public PenggunaSayaTube(string nama)
    {
        Debug.Assert(nama != null, "Nama pengguna tidak boleh null");
        Debug.Assert(nama.Length <= 100, "Nama pengguna tidak boleh lebih dari 100 karakter");

        this.namaPengguna = nama;
        this.daftarVideo = new List<VideoSayaTube>();
    }

    
    public void UnggahVideo(VideoSayaTube video)
    {
        Debug.Assert(video != null, "Video tidak boleh null");
        this.daftarVideo.Add(video);
    }

    
    public void CetakDetailAkun()
    {
        Console.WriteLine($"Nama Pengguna: {this.namaPengguna}");
        Console.WriteLine("Video yang diunggah:");
        foreach (var video in daftarVideo)
        {
            video.CetakDetailVideo();
        }
    }

    
    public int HitungTotalTayangan()
    {
        int total = 0;
        foreach (var video in daftarVideo)
        {
            total += video.GetJumlahTayang();
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        
        PenggunaSayaTube pengguna = new PenggunaSayaTube("Budi Santoso");

        
        VideoSayaTube video1 = new VideoSayaTube("Tutorial C# untuk Pemula");
        VideoSayaTube video2 = new VideoSayaTube("Cara Membuat Aplikasi di C#");

        
        pengguna.UnggahVideo(video1);
        pengguna.UnggahVideo(video2);

        
        video1.TambahJumlahTayang(500);
        video2.TambahJumlahTayang(1200);

        
        pengguna.CetakDetailAkun();
        Console.WriteLine($"Total Tayangan Semua Video: {pengguna.HitungTotalTayangan()}");
    }
}
