namespace HackingNews.Api.Dtos
{
    public class HackingNewsResponse
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string PostedBy { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }
        public int CommentCount { get; set; }
    }
}
