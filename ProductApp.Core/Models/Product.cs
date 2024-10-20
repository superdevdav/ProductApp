namespace ProductApp.Core.Models
{
    public class Product
    {
        public const int MAX_NAME_LENGTH = 25;
        public const int MAX_DESCRIPTION_LENGTH = 500;

        private Product(int Id, string Name, string Description, decimal Price, int CategoryId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.CategoryId = CategoryId;
        }

        public int Id { get; private set; }
        
        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public int CategoryId { get; }

        public static Product Create(string Name, string Description, decimal Price, int CategoryId, int id = 0)
        {
            var product = new Product(id, Name, Description, Price, CategoryId);

            return product;
        }

        public static string ValidateData(string Name, string Description, decimal Price)
        {
            if (Description.Length > MAX_DESCRIPTION_LENGTH || string.IsNullOrEmpty(Description))
            {
                return $"Description can not be empty or longer than {MAX_DESCRIPTION_LENGTH} symbols";
            }
            else
            {
                if (Name.Length > MAX_NAME_LENGTH || string.IsNullOrEmpty(Name))
                {
                    return $"Name can not be empty or longer than {MAX_NAME_LENGTH} symbols";
                }
            }

            if (Price <= 0)
            {
                return "Price must be greater than zero";
            }

            return string.Empty;
        }
    }
}
