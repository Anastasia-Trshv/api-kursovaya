namespace api_курсовая.model
{
    public class SupplyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Type { get; set; }
        public double Price {  get; set; }  

        public SupplyEntity(Guid id,string name, string description, string picture, int type, double price)
        {
            Id= id;
            Name = name;
            Description = description;
            Picture = picture;
            Type = type;
            Price = price;
        }
    }
}
