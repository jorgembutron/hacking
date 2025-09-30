namespace HackingNews.Infrastructure.Views;

public class HackingNewsView
{
    public HackingNewsDetailsView[] HackingNewsDetailsView { get; set; }
}



public class HackingNewsDetailsView
{
    public string Title { get; set; }
    public string Uri { get; set; }
    public string PostedBy { get; set; }
    public DateTime Time { get; set; }
    public int Score { get; set; }
    public int CommentCount { get; set; }
}