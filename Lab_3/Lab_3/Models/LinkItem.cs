namespace Lab_3.Models
{
    public class LinkItem
    {
        public static string BasePath = "http://localhost:8080/";

        public string Rel { get; set; }

        public string Href { get; set; }

        public LinkItem()
        {
            Rel = "href";
            Href = string.Empty;
        }
    }
}