using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductApp.Core.Models
{
    public class ProductCategory
    {
        public const int MAX_NAME_LENGTH = 25;
        public const int MAX_DESCRIPTION_LENGTH = 500;

        private ProductCategory(int Id, string Name, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }

        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public static ProductCategory Create(string Name, string Description, int Id = 0)
        {
            var productCategory = new ProductCategory(Id, Name, Description);

            return productCategory;
        }

        public static string ValidateData(string Name, string Description)
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

            return string.Empty;
        }
    }
}
