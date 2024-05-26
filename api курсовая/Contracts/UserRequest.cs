namespace api_курсовая.Contracts
{
    public record UserRequest
    (
            string Name,
            string Email,
            string Role,
            string Password
    );
}
