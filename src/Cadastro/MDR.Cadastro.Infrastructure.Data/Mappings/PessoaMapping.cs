using MDR.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDR.Cadastro.Infrastructure.Data.Mappings;

internal class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(60)");

        builder.Property(p => p.Sobrenome)
            .IsRequired()
            .HasColumnType("varchar(60)");

        builder.Property(p => p.Idade)
            .IsRequired()
            .HasColumnType("integer");

        builder.HasOne(o => o.Departamento)
            .WithMany(m => m.Pessoas)
            .HasForeignKey(fk => fk.DepartamentoId);

        builder.ToTable("Pessoas");
    }
}
