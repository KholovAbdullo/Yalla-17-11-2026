namespace Application.DTOs.Menuitems;

public class CreateMenuitemDto
{
    public int MenuId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
}
