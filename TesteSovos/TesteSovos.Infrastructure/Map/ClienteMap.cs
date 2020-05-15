using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteSovos.Domain.Models;

namespace TesteSovos.Infrastructure.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", "dbo");
            builder.HasKey(c => c.ClienteId).HasName("ClienteId");
            builder.Property(c => c.ClienteId).HasColumnName("ClienteId").ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(255).IsRequired();
            builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
            builder.Property(c => c.DataInclusao).HasColumnName("DataInclusao").IsRequired();
            builder.Property(c => c.DataAlteracao).HasColumnName("DataAlteracao");
        }
    }
}
