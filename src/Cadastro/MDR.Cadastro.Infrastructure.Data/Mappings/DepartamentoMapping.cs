using MDR.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDR.Cadastro.Infrastructure.Data.Mappings;

internal class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(60)");

        builder.HasMany(m => m.Pessoas)
            .WithOne(o => o.Departamento)
            .HasForeignKey(fk => fk.DepartamentoId);

        builder.ToTable("Departamentos");
    }
}
