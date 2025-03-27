using System;
using System.Collections.Generic;
using System.Diagnostics;

public class SayaTubeUser
{
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        
        Debug.Assert(!string.IsNullOrEmpty(username), "Username tidak boleh null atau kosong.");
        Debug.Assert(username.Length <= 100, "Panjang username maksimal 100 karakter.");

        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        
        Debug.Assert(video != null, "Video yang ditambahkan tidak boleh null.");
        uploadedVideos.Add(video);
    }

    public void PrintAllVideos()
    {
        Console.WriteLine($"Username: {this.username}");
        foreach (var video in uploadedVideos)
        {
            video.PrintVideoDetails();
        }
    }
}
