using System.IdentityModel.Tokens.Jwt;

namespace api_курсовая.model
{
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public bool IsAktive { get; set; }

        public RefreshTokenEntity(Guid id, string token) {
        Id= Guid.NewGuid();
            UserId = id;
            Token= token;
            IsAktive= true;
                }
    }
}
