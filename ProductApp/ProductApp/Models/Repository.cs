namespace ProductApp.Models
{
    public class Repository
    {
        private static readonly List<Products> _products = new List<Products>();
        private static readonly List<Categories> _categories = new List<Categories>();

        static Repository()
        {
            Categories.Add(new Categories() { CategoryId = 1 , CategoryName = "Telefon"});
            Categories.Add(new Categories() { CategoryId = 2 , CategoryName = "Bilgisayar"});

            Products.Add(new Products() { ProductId = 1, Name ="Macbook Pro" , Description="Açıklama" , Image = "1.jpg" , Price = 4000 , IsActive = true , CategoryId = 2});
            Products.Add(new Products() { ProductId = 2, Name ="iphone 14" , Description="Açıklama" , Image = "2.jpg" , Price = 4000 , IsActive = true , CategoryId = 1});
            Products.Add(new Products() { ProductId = 3, Name ="iphone 15" , Description="Açıklama" , Image = "3.jpg" , Price = 4000 , IsActive = true , CategoryId = 1});
        }

        public static List<Products> Products
        {
            get
            {
                return _products;
            }
        }

        public static void CreateProduct(Products products)
        {
            _products.Add(products);
        }

        public static void UpdateProduct(Products products)
        {
            var update = _products.FirstOrDefault(i => i.ProductId == products.ProductId);
            if (update != null) 
            { 
                update.Name = products.Name;
                update.Description = products.Description;
                update.Image = products.Image;
                update.Price = products.Price;
                update.IsActive = products.IsActive;
                update.CategoryId = products.CategoryId;

            }
        }

        public static void DeleteProduct(Products products)
        {
            var delete = _products.FirstOrDefault(p => p.ProductId == products.ProductId);
            if (delete != null)
            {
                _products.Remove(delete);
            }
        }

        public static List<Categories> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}
