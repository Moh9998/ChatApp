using ChatApp.HUbs;

namespace ChatApp.Repositories
{
    public interface IChat
    {
        Task<IEnumerable<Message>> GetMessages();
        Task<Message> GetMessage(int id);
        Task<Message> AddMessage(Message message , int roomId);
        Task<Message> UpdateMessage(Message message , int Id);
        Task<Message> DeleteMessage(int id);
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUser(int id);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> DeleteUser(int id);
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms> GetRoom(int id);
        Task<Rooms> AddRoom(Rooms room);
        Task<Rooms> UpdateRoom(Rooms room);
        Task<Rooms> DeleteRoom(int id);
        Task<IEnumerable<Users>> GetUsersInRoom(int roomId);
        Task<IEnumerable<Message>> GetMessagesInRoom(int roomId);
        Task<IEnumerable<Rooms>> GetRoomsForUser(int userId);
        Task<Rooms> JoinRoom(int userId, int roomId);

    }
}
