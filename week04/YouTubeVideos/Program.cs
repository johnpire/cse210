using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Alpha", "John", 120);
        video1.AddComment(new Comment("Camille", "The video is great!"));
        video1.AddComment(new Comment("Mike", "The presentation is cool!"));
        video1.AddComment(new Comment("Justin", "The video is inspiring."));

        Video video2 = new Video("Beta", "Carlo", 115);
        video2.AddComment(new Comment("Austin", "I think so too!"));
        video2.AddComment(new Comment("Sarrah", "I agree!"));
        video2.AddComment(new Comment("David", "It's what on my mind lately."));

        Video video3 = new Video("Gamma", "Kitongan", 180);
        video3.AddComment(new Comment("Brent", "I would argue that is the only appropirate solution."));
        video3.AddComment(new Comment("Justin", "It could be solved differently as well, but that is probably the best method."));
        video3.AddComment(new Comment("Paula", "Thank you. I've been reviewing for tomorrow's Math exam."));

        List<Video> videos = new List<Video> { video1, video2, video3 };
        int i = 1;
        foreach (Video video in videos)
        {
            Console.WriteLine($"Video {i++}");
            video.DisplayAll();
        }
    }
}