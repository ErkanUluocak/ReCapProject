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
    public class CarCFG : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new Car() { CarId = 1, BrandId = 1, ColorId=3, ModelYear = 2021,DailyPrice = 500,Description = "Sahibinden temiz araç" });
            builder.HasData(new Car() { CarId = 2, BrandId = 3, ColorId = 2, ModelYear = 2021, DailyPrice = 500, Description = "İstanbul çevresi için kiralık" });
            builder.HasData(new Car() { CarId = 3, BrandId = 2, ColorId = 3, ModelYear = 2021, DailyPrice = 800, Description = "Kiralamak için doğru tercih" });
            builder.HasData(new Car() { CarId = 4, BrandId = 2, ColorId = 3, ModelYear = 2021, DailyPrice = 400, Description = "Kiralamak için doğru tercih" });

        }
    }
}
