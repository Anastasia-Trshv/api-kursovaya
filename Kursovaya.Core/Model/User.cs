using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Model
{
    public class User
    {

        public User(Guid id, string name, string email, string password, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public Guid Id { get;  }
        public string Name { get;  }
        public string Email { get;  }
        public string Password { get;  }
        public string Role { get;  }

        public static User Create(Guid id,string name, string email, string password, string role)
        {
            
            var user = new User(id,name, email, password, role);
            return (user);
        }
        public User() { }
    }
}
