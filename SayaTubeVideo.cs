using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int playCount;
    private string title;

    public SayaTubeVideo(string title)
    {
        
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul video tidak boleh null atau kosong.");
        Debug.Assert(title.Length <= 200, "Judul video maksimal 200 karakter.");

        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        
        Debug.Assert(count > 0, "Play count harus bilangan positif.");
        Debug.Assert(count <= 25000000, "Penambahan play count maksimal 25.000.000.");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("ERROR: Terjadi overflow saat menambahkan play count.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Judul Video: {this.title}");
        Console.WriteLine($"Jumlah Play Count: {this.playCount}");
    }

    
    public void PrintAllVideoPlaycount()
    {
        Debug.Assert(this.playCount >= 0, "Jumlah play count tidak boleh negatif.");
        Console.WriteLine($"Total Play Count: {this.playCount}");
    }
}
