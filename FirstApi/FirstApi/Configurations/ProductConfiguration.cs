using FirstApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApi.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property("Name").IsRequired(true).HasMaxLength(20);
            builder.Property(p => p.SalePrice).IsRequired(true).HasDefaultValue(50);
            builder.Property(p=>p.CostPrice).IsRequired(true).HasDefaultValue(10);

        }
    }
}
