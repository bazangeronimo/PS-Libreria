using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Template.Domain.Models;

namespace PS.Template.Domain.Settings
{
    public class SettingFeatures
    {
        public SettingFeatures(EntityTypeBuilder<Features> BuilderFeature)
        {
            BuilderFeature.HasKey(X => X.Caracteristica_Id);
            BuilderFeature.HasOne(x => x.Usuario).WithMany(Z => Z.features).HasForeignKey(X => X.Caracteristica_Id);
            BuilderFeature.Property(X => X.Skills).HasMaxLength(255);
        }
    }
}
