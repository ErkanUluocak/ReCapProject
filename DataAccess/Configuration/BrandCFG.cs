using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class BrandCFG : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(new Brand() { BrandId = 1, BrandName = "Mercedes" });
            builder.HasData(new Brand() { BrandId = 2, BrandName = "Bmw" });
            builder.HasData(new Brand() { BrandId = 3, BrandName = "Audi" });
            builder.HasData(new Brand() { BrandId = 4, BrandName = "Toyoto" });
        }
    }
}
