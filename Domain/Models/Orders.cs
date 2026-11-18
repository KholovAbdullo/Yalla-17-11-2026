namespace Domain.Models;

public class Orders
{
    public int id { get; set; }
    public int Companyid { get; set; }
    public DateTime Orderdate { get; set; }
    public string Status { get; set; }=null!;
    public decimal Totalamount { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updatedat { get; set; }
}
