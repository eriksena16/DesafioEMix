using ConsultaCEP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultaCEP.Mapper
{
    public class CepMapper : IEntityTypeConfiguration<CEP>
    {
        public void Configure(EntityTypeBuilder<CEP> builder)
        {
            builder.HasNoKey();
        }
    }
}
