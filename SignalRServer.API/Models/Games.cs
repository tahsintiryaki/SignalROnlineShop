namespace SignalRServer.API.Models
{
    public class Games
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime CreatedDate { get; set; }
        public string ImgPath { get; set; }
    }
}
