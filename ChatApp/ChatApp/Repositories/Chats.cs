using ChatApp.Data;
using ChatApp.HUbs;

namespace ChatApp.Repositories
{
    public class Chats(DataContext context) : IChat
    {
        private readonly DataContext _context = context;

        public async Task<Message> AddMessage(Message message , int roomId)
        {
            var newMessage = new Message
            {
                Id = message.Id,
                Text = message.Text,
                DateSent = message.DateSent,
                RoomId = roomId,



            };
            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();
            return newMessage;
        }

        public async Task<Rooms> AddRoom(Rooms room)
        {
           var newRoom = new Rooms
           {
               Name = room.Name
           };
            _context.Rooms.Add(newRoom);
            await _context.SaveChangesAsync();
            return newRoom;
        }

        public async Task<Users> AddUser(Users user)
        {
            var newUser = new Users
            {
                Name = user.Name
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(); 
            return newUser;
        }


        public Task<Message> DeleteMessage(int id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                throw new Exception("Message not found");
            }
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Task.FromResult(message);
        }

        public Task<Rooms> DeleteRoom(int id)
        {
           var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Task.FromResult(room);
        }

        public Task<Users> DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Task.FromResult(user);
        }

        public Task<Message> GetMessage(int id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                throw new Exception("Message not found");
            }
            return Task.FromResult(message);
        }

        public Task<IEnumerable<Message>> GetMessages()
        {
            var messages = _context.Messages.ToList();
            return Task.FromResult(messages.AsEnumerable());
        }

        public Task<IEnumerable<Message>> GetMessagesInRoom(int roomId)
        {
            IEnumerable<Message> messages = _context.Messages.Where(m => m.RoomId == roomId).ToList();
            return Task.FromResult(messages);
        }

        public Task<Rooms> GetRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            return Task.FromResult(room);
        }

        public Task<IEnumerable<Rooms>> GetRooms()
        {
            IEnumerable<Rooms> rooms = _context.Rooms.ToList();
            return Task.FromResult(rooms);
        }

        public Task<IEnumerable<Rooms>> GetRoomsForUser(int userId)
        {
            IEnumerable<Rooms> rooms = _context.Rooms.Where(r => r.Users.Any(u => u.Id == userId)).ToList();
            return Task.FromResult(rooms);
        }

        public Task<Users> GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return Task.FromResult(user);
        }

        public Task<IEnumerable<Users>> GetUsers()
        {
           IEnumerable<Users> users = _context.Users.ToList();
            return Task.FromResult(users);
        }

        public Task<IEnumerable<Users>> GetUsersInRoom(int roomId)
        {
            //Get Room By Id
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            //GEt Users in Romm
            IEnumerable<Users> users = room.Users.ToList();
            return Task.FromResult(users);
        }

        public Task<Rooms> JoinRoom(int userId, int roomId)
        {
            //Get User By Id
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //Get Room By Id
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            //Add User to Room
            room.Users.Add(user);
            _context.SaveChanges();
            return Task.FromResult(room);
        }

        public Task<Message> UpdateMessage(Message message , int Id)
        {
            var messageToUpdate = _context.Messages.FirstOrDefault(m => m.Id == Id);
            if (messageToUpdate == null)
            {
                throw new Exception("Message not found");
            }
            messageToUpdate.Text = message.Text;

            _context.SaveChanges();
            return Task.FromResult(messageToUpdate);

        }

        public Task<Rooms> UpdateRoom(Rooms room)
        {
            var RoomToUpdate= _context.Rooms.FirstOrDefault(r => r.Id == room.Id);
            if (RoomToUpdate == null)
            {
                throw new Exception("Room not found");
            }
            RoomToUpdate.Name = room.Name;
            _context.SaveChanges();
            return Task.FromResult(RoomToUpdate);
        }

        public Task<Users> UpdateUser(Users user)
        {
            var UserToUpdate = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (UserToUpdate == null)
            {
                throw new Exception("User not found");
            }
            UserToUpdate.Name = user.Name;
            _context.SaveChanges();
            return Task.FromResult(UserToUpdate);
        }
    }
}
