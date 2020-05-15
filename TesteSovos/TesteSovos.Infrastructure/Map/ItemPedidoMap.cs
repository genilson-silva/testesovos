using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteSovos.Domain.Models;

namespace TesteSovos.Infrastructure.Map
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido", "dbo");
            builder.HasKey(c => c.ItemPedidoId).HasName("ItemPedidoId");
            builder.Property(c => c.ItemPedidoId).HasColumnName("ItemPedidoId").ValueGeneratedOnAdd();
            builder.Property(c => c.PedidoId).HasColumnName("PedidoId").IsRequired();
            builder.Property(c => c.Preco).HasColumnName("Preco").IsRequired();
            builder.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(255).IsRequired();
            builder.Property(c => c.DataInclusao).HasColumnName("DataInclusao").IsRequired();
            builder.Property(c => c.DataAlteracao).HasColumnName("DataAlteracao");
            builder.HasOne(s => s.Pedido)
                .WithMany(c => c.Itens)
                .HasForeignKey(s => s.PedidoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
