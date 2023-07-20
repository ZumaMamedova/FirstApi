﻿namespace FirstApi.Dtos.Product
{
    public class ProductReturnDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
    }
}
