namespace Kursovaya.Core.Model
{
    public class Supply
    {
        public Supply( string name, string description, string picture, int type, double price)
        {
            
            Name = name;
            Description = description;
            Picture = picture;
            Type = type;
            Price = price;
        }

        public int Id { get;  }
        public string Name { get;  }
        public string Description { get;  }
        public string Picture { get;  }
        public int Type { get;  }
        public double Price { get;  }

        public static (Supply sup, string Error) Create(string name, string description, string picture, int type, double price)
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                error = "Name can not be empty";

            }
            var sup = new Supply(name, description, picture, type,price);
            return (sup, error);
        }
    }
}
