using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Firga");

        SayaTubeVideo video1 = new SayaTubeVideo("Belajar Design by Contract di C#");
        SayaTubeVideo video2 = new SayaTubeVideo("Tutorial C# Dasar untuk Pemula");

        user.AddVideo(video1);
        user.AddVideo(video2);

        video1.IncreasePlayCount(10000);
        video2.IncreasePlayCount(25000000);

        user.PrintAllVideos();
        video1.PrintAllVideoPlaycount();
        video2.PrintAllVideoPlaycount();
    }
}
