namespace ChatApp.HUbs
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateSent { get; set; }
        = DateTime.Now;
        public int RoomId { get; set; }

    }
}
