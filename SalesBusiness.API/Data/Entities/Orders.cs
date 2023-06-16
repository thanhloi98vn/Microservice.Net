namespace SalesBusiness.API.Data.Entities
{
	public class Orders
	{
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
