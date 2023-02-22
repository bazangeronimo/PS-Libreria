using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interface
{
    public interface IFeaturesCommands
    {
        public Response CreateFeature(int id, string skill);
        public Response UpdateFeature(Features features, string newInfo);
        public Response DeleteFeature(Features features);
    }
}
