namespace Domain.Models;

public class Subscriptions
{
    public int id { get; set; }
    public int Companyid { get; set; }
    public string Plantype { get; set; }=null!;
    public int Mealsperday { get; set; }
    public decimal Price { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public bool isactive { get; set; }=true;
    public DateTime Createdat { get; set; }
    public DateTime Updatedat { get; set; }
}
