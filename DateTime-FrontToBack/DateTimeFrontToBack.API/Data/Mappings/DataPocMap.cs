using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DateTimeFrontToBack.API.Data.Entities;

namespace DateTimeFrontToBack.API.Data.Mappings
{
    public class DataPocMap : EntityTypeConfiguration<DataPoc>
    {
        public DataPocMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}