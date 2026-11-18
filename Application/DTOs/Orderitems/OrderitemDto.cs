namespace Application.DTOs.Orderitems;

public class OrderitemDto
{
    public int id { get; set; }
    public int Orderid { get; set; }
    public int Menuitemid { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updatedat { get; set; }
}
