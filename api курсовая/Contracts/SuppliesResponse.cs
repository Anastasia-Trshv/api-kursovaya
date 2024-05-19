namespace api_курсовая.Contracts
{
    public record SuppliesResponse
        (
         Guid Id,
         string Name,
         string Description,
         string Picture,
         int Type,
         double Price);
       


}
