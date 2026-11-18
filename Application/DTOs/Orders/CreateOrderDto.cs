namespace Application.DTOs.Orders;

public class CreateOrderDto
{
    public int Companyid { get; set; }
    public DateTime Orderdate { get; set; }
    public string Status { get; set; } = null!;
    public decimal Totalamount { get; set; }
}
