namespace PartTwo.Entities.Entities;

public class CustomerBasket
{
    public CustomerBasket() { }
    public CustomerBasket(string id, List<BasetItems> items)
    {
        Id = id;
    }

    public string Id { get; set; }
    public List<BasetItems> Items { get; set; } = new List<BasetItems>();
}
