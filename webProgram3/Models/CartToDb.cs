namespace webProgram3.Models
{
    public class CartToDb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<Product> Product { get; set; }

        public int AdressId { get; set; }
        public IEnumerable<Adress> Adress { get; set; }
        public string DiliveryTypeName { get; set; }
        public IEnumerable<DiliveryType> DiliveryType { get; set; }
    }
}
