namespace ProductApp.API.Contracts
{
    public record ProductRequest (
        string Name,
        string Description,
        decimal Price,
        int CategoryId
        );
}
