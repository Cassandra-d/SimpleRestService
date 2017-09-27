namespace DataLayer.Contract.Models
{
    public class Album
    {
        public int Id { get; internal set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string CoverUrl { get; set; }
    }
}
