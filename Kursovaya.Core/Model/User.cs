using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Model
{
    internal class User
    {

        public User( string name, string email, string password, int role)
        {
           
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public int Id { get;  }
        public string Name { get;  }
        public string Email { get;  }
        public string Password { get;  }
        public int Role { get;  }

        public static (User user, string Error) Create(string name, string email, string password, int role)
        {
            string error = string.Empty;
            if(string.IsNullOrEmpty(name))
            {
                error = "Name can not be empty";
                
            }
            var user = new User(name, email, password, role);
            return (user, error);
        }
    }
}
