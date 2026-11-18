namespace Domain.Models;

public class Menuitems
{
    public int id { get; set; }
    public int MenuId { get; set; }
    public string Name { get; set; }=null!;
    public string Description { get; set; }=null!;
    public decimal Price { get; set; }
    public string Category { get; set; }=null!;
    public DateTime Createdat { get; set; }
    public DateTime Updatedat { get; set; }
}
