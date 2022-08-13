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
    public class ColorCFG : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(new Color() { ColorId = 1, ColorName = "Beyaz" });
            builder.HasData(new Color() { ColorId = 2, ColorName = "Siyah" });
            builder.HasData(new Color() { ColorId = 3, ColorName = "Mavi" });
            builder.HasData(new Color() { ColorId = 4, ColorName = "Kırmızı" });

        }
    }
}
