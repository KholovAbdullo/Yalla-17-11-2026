namespace Domain.Models;

public class Menus
{
    public int id { get; set; }
    public DateTime menudate { get; set; }
    public bool isactive { get; set; }=true;
    public DateTime createdat { get; set; }
    public DateTime updatedat { get; set; }
}
