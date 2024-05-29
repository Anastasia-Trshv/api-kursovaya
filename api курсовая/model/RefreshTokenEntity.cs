using System.IdentityModel.Tokens.Jwt;

namespace api_курсовая.model
{
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public bool IsAktive { get; set; }

        public RefreshTokenEntity(string id, string token) {
            Id= Guid.NewGuid();
            UserId = id;
            Token= token;
            IsAktive= true;
                }
        public RefreshTokenEntity() { }
    }
}
