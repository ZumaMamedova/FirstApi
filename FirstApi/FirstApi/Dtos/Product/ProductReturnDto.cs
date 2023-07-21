namespace FirstApi.Dtos.Product
{
    public class ProductReturnDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsDeleted { get; set; }
        public CategoryInProductDto Category { get; set; }
       
    }
    public class CategoryInProductDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCount { get; set; }
    }

}
