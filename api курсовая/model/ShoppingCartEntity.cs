namespace api_курсовая.model
{
    public class ShoppingCartEntity
    {
        public Guid UserId { get; set; }
        public int SupplyId { get; set; }
        public int Amount { get; set; }

    }
}
