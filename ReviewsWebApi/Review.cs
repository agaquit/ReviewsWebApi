namespace ReviewsWebApi
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int ProducId { get; set; }

    }
}
