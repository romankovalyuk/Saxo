namespace Saxo.Flow
{
    public class SaxoFlowResult : FlowResultBase
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Label { get; set; }
        public int RatingCount { get; set; }
        public string Url { get; set; }
    }
}