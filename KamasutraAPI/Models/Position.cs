namespace KamasutraAPI.Models
{
    public class Position
    {
        public int Id { get; set; }
        public KamasutraAction? Action { get; set; }
        public BodyPart? BodyPart { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
