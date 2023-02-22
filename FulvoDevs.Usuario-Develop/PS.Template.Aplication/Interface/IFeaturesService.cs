using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;

namespace PS.Template.Aplication.Interface
{
    public interface IFeaturesService
    {
        public Response CreateFeature(int user, dtoCreateFeatured featured);
        public Response UpdateFeature(int user, dtoUpdateFeature newFeature);
        public Response DeleteFeature(int user, dtoDeleteFeature newFeature);
    }
}
