namespace Company_CFM.DTOs
{
    public class CustomerDto
    {
        public string Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
