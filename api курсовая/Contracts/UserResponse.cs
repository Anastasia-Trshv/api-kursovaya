namespace api_курсовая.Contracts
{
    public record UserResponse
    (
        Guid id,
        string Name,
        string Email,
        string Role
        );
}
