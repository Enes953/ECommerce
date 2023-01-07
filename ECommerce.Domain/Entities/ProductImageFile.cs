namespace ECommerce.Domain.Entities
{
    public class ProductImageFile:ImageFile
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}


//ctrl r+g  siler