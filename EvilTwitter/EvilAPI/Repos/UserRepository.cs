using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Minitwit.Entities;
using static System.Net.HttpStatusCode;


namespace EvilAPI.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IMinitwitContext _context;

        public UserRepository(IMinitwitContext context)
        {
            _context = context;
        }

        public HttpStatusCode AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return NoContent;
        }

        public User GetUserFromID(int userID)
        {
            var user = _context.User.Find(userID);
            if (user == null) 
                return null;

            return user;
        }

        public int GetUserIDFromUsername(string username)
        {
            var user = _context.User
                            .Where(u => u.username == $"{username}")
                            .FirstOrDefault<User>();
            if (user == null)
                return -1;

            return user.user_id;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.AsEnumerable();
        }

    }
}