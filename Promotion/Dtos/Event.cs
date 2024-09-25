namespace Promotion.Dtos;

public record class Event{
    public int Score { get; set; }
    public required List<Promotion> Promotions { get; set; }
}