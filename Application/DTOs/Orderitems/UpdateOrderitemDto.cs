namespace Application.DTOs.Orderitems;

public class UpdateOrderitemDto
{
    public int Orderid { get; set; }
    public int Menuitemid { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
