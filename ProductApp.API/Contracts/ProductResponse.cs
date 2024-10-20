namespace ProductApp.API.Contracts
{
    public record ProductResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int CategoryId
        );
}
