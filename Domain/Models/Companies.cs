namespace Domain.Models;

public class Companies
{
    public int id { get; set; }
    public string Name { get; set; }=null!;
    public string Address { get; set; }=null!;
    public string Phone { get; set; }=null!;
    public string Email { get; set; }=null!;
    public DateTime createdat { get; set; }
    public DateTime updatedat { get; set; }
}
