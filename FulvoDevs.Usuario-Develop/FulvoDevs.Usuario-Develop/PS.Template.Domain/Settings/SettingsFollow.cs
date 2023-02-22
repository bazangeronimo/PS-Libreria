using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Template.Domain.Models;


namespace PS.Template.Domain.Settings
{
    public class SettingsFollow
    {
        public SettingsFollow(EntityTypeBuilder<Follow> BuilderFollow)
        {
            BuilderFollow.HasKey(X => X.FollowKey);


            BuilderFollow.HasOne(X => X.Usuario_Id).WithMany(Z => Z.follows).HasForeignKey(X => X.usuario_Fk);
            BuilderFollow.HasOne(X => X.Seguido).WithMany(Z => Z.followers).HasForeignKey(X => X.seguido_Fk);
        }
    }
}
