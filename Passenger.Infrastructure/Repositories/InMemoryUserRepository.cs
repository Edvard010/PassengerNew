using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@email.com", "user1", "password1", "salt"),
            new User("user2@email.com", "user2", "password2", "salt"),
            new User("user3@email.com", "user3", "password3", "salt"),
        };
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        => _users.SingleOrDefault(x => x.Id == id);

        public User Get(string email)
       => _users.SingleOrDefault(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
        => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
