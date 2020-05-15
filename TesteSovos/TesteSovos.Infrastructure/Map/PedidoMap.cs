using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteSovos.Domain.Models;

namespace TesteSovos.Infrastructure.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido", "dbo");
            builder.HasKey(c => c.PedidoId).HasName("PedidoId");
            builder.Property(c => c.PedidoId).HasColumnName("PedidoId").ValueGeneratedOnAdd();
            builder.Property(c => c.ClienteId).HasColumnName("ClienteId").IsRequired();
            builder.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(255).IsRequired();
            builder.Property(c => c.DataInclusao).HasColumnName("DataInclusao").IsRequired();
            builder.Property(c => c.DataAlteracao).HasColumnName("DataAlteracao");
            builder.HasOne(s => s.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(s => s.ClienteId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
