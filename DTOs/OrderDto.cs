namespace Company_CFM.DTOs
{
    public class OrderDto
    {
        public string Order_Id { get; set; }
        public int Amount { get; set; }
        public int? Product_Id { get; set; }
        public string Product_Name { get; set; }
        public decimal? Total_Cost { get; set; }
    }
}
