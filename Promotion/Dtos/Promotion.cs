namespace Promotion.Dtos;

public record class Promotion{
    public  required string Id {get; set;}
    public DateOnly Start_date {get;set;}
};
