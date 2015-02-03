using MongoDB.Bson;

namespace Saxo.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Label { get; set; }
        public int RatingCount { get; set; }
        public bool IsChecked { get; set; }
        public string Url { get; set; }
    }
}