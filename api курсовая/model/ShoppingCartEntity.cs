namespace api_курсовая.model
{
    public class ShoppingCartEntity
    {
        public string UserId { get; set; }
        public string SupplyId { get; set; }
        public int Amount { get; set; }

        public ShoppingCartEntity(string userid, string supid,int amount) {
            UserId = userid;
            SupplyId = supid;
            Amount = amount;
        }

        public static ShoppingCartEntity Create(string userid, string supid, int amount)
        {
            return new ShoppingCartEntity(userid, supid, amount);
        }
    }
}
