namespace api_курсовая.model
{
    public class UserEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role {  get; set; }

        public UserEntity(string name,string email,string password, int role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
           
    }
}
