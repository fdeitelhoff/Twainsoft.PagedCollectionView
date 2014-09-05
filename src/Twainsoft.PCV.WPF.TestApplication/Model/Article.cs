namespace Twainsoft.PCV.WPF.TestApplication.Model
{
    public class Article
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public float Pages { get; set; }

        public Article(string name, string author, float pages)
        {
            Name = name;
            Author = author;
            Pages = pages;
        }
    }
}
