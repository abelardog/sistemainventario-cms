using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemainventariocms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemainventariocms.Data.Configuracion
{
    public class AlmacenConfiguracion : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(a => a.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Estado).IsRequired();
        }
    }
}
