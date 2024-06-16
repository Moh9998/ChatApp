namespace ChatApp.HUbs
{
    public class Rooms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Users> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}
