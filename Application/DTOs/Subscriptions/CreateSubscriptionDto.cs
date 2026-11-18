namespace Application.DTOs.Subscriptions;

public class CreateSubscriptionDto
{
    public int Companyid { get; set; }
    public string Plantype { get; set; } = null!;
    public int Mealsperday { get; set; }
    public decimal Price { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
}
