namespace Application.DTOs.Subscriptions;

public class SubscriptionDto
{
    public int id { get; set; }
    public int Companyid { get; set; }
    public string Plantype { get; set; } = null!;
    public int Mealsperday { get; set; }
    public decimal Price { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public bool isactive { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updatedat { get; set; }
}
