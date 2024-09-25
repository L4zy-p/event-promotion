using System.Text.Json;
using Promotion.Dtos;

class Program
{
    static void Main(string[] args)
    {
        // get mock data from file
        var mockData = File.ReadAllText("mock.json");
        // parse json to list
        List<Event> events = JsonSerializer.Deserialize<List<Event>>(mockData) ?? [];

        // sort event order by high score to low score
        events = events.OrderByDescending((ev) => ev.Score).ToList() ?? [];

        // sort promotion order by date & alphabet
        for (var i = 0; i < events.Count; i++)
        {
            events[i].Promotions = events[i].Promotions.OrderBy((pr) => pr.Start_date).ThenBy((pr) => pr.Id).ToList() ?? [];
        }

        List<string> promotions = [];
        bool foundPromotion = true;
        
        // loop until not found promotion
        while (foundPromotion)
        {
            // set for not found promotion each round if found promotion in event loop it set found 
            foundPromotion = false;
            for(var i = 0; i < events.Count; i++){
                if(events[i].Promotions.Count > 0){
                    // add first promotion into promotion list
                    promotions.Add(events[i].Promotions[0].Id);
                    // remove first promotion for not used again
                    events[i].Promotions.RemoveAt(0);
                    foundPromotion = true;
                }
            }
        }

        Console.WriteLine(string.Join(",", promotions));
    }
}