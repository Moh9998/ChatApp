namespace ChatApp.HUbs
{
    public class Users
    {
        public int Id { get; set; }
        public Guid UsserId { get; set; } = new Guid();
        public string Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? Room { get; set; }                 
        public List<Message> Messages { get; set; }




    }
}
