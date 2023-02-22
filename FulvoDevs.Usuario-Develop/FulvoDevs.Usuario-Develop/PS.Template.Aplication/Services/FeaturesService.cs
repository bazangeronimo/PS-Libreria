using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;

namespace PS.Template.Aplication.Services
{
    public class FeaturesService : IFeaturesService
    {
        private readonly IFeaturesQueries _featuresQueries;
        private readonly IFeaturesCommands _featuresCommands;
        public FeaturesService(IFeaturesQueries que,IFeaturesCommands com)
        {
            _featuresQueries = que;
            _featuresCommands = com;
        }
        public Response CreateFeature(int user, dtoCreateFeatured featured)
        {
            var response = new Response(true,"Feature creado con exito"); response.StatusCode=200;
            var verification = this.ValidateCreateFeature(featured);
            if(!verification.succes)
            {
                response.StatusCode = verification.StatusCode;
                response.content = verification.content;
                response.succes = verification.succes;
                return response;
            }
            var featureFound = _featuresQueries.AskExistingFeatures(user,featured.skill);
            if (featureFound != null)
            {
                response.StatusCode = 400;
                response.content = "Feature ya existente";
                response.succes = false;
                return response;
            }
            var created = _featuresCommands.CreateFeature(user,featured.skill);
            response.StatusCode = created.StatusCode;
            response.content = created.content;
            response.succes = created.succes;
            return response;
        }
        private Response ValidateCreateFeature(dtoCreateFeatured featured)
        {
            var response = new Response(true, "Valicacion correcta");
            response.StatusCode = 200;
            if(featured.skill==null|| featured.skill=="")
            {
                response.StatusCode = 400;
                response.content = "La descripcion de la skill esta vacia";
                response.succes = false;
                return response;
            }
            if (featured.skill.Length>255)
            {
                response.StatusCode = 400;
                response.content = "Descripcion de Skill demaciado larga";
                response.succes = false;
                return response;
            }
            return response;
        }
        public Response UpdateFeature(int user, dtoUpdateFeature newFeature)
        {
            var response = new Response(true, "Feature actualizado con exito"); response.StatusCode = 200;
            var verification = this.ValidateUpdateFeature(newFeature);
            if (!verification.succes)
            {
                response.StatusCode = verification.StatusCode;
                response.content = verification.content;
                response.succes = verification.succes;
                return response;
            }
            var featureFound = _featuresQueries.AskExistingFeatures(user, newFeature.skill);
            if (featureFound == null)
            {
                response.StatusCode = 400;
                response.content = "Feature no existe";
                response.succes = false;
                return response;
            }
            var updated = _featuresCommands.UpdateFeature(featureFound, newFeature.newSkill);
            response.StatusCode = updated.StatusCode;
            response.content = updated.content;
            response.succes = updated.succes;
            return response;
        }
        private Response ValidateUpdateFeature(dtoUpdateFeature updateFeature)
        {
            var response = new Response(true, "Valicacion correcta"); response.StatusCode = 200;
            if (updateFeature.skill == null || updateFeature.skill == "")
            {
                response.StatusCode = 400;
                response.content = "La descripcion de la skill esta vacia";
                response.succes = false;
                return response;
            }
            if (updateFeature.newSkill == null || updateFeature.newSkill == "")
            {
                response.StatusCode = 400;
                response.content = "La descripcion de la nueva skill esta vacia";
                response.succes = false;
                return response;
            }
            if (updateFeature.skill.Length > 255)
            {
                response.StatusCode = 400;
                response.content = "Descripcion de Skill demaciado larga";
                response.succes = false;
                return response;
            }
            if (updateFeature.newSkill.Length > 255)
            {
                response.StatusCode = 400;
                response.content = "Descripcion de la nueva Skill es demaciado larga";
                response.succes = false;
                return response;
            }
            return response;
        }
        public Response DeleteFeature(int user, dtoDeleteFeature Feature)
        {
            var response = new Response(true, "Feature Eliminado con exito"); response.StatusCode = 200;
            var verification = this.ValidateDeleteFeature(Feature);
            if (!verification.succes)
            {
                response.StatusCode = verification.StatusCode;
                response.content = verification.content;
                response.succes = verification.succes;
                return response;
            }
            var featureFound = _featuresQueries.AskExistingFeatures(user, Feature.skill);
            if (featureFound == null)
            {
                response.StatusCode = 400;
                response.content = "Feature no existe";
                response.succes = false;
                return response;
            }
            var updated = _featuresCommands.DeleteFeature(featureFound);
            response.StatusCode = updated.StatusCode;
            response.content = updated.content;
            response.succes = updated.succes;
            return response;
        }
        private Response ValidateDeleteFeature(dtoDeleteFeature featured)
        {
            var response = new Response(true, "Valicacion correcta");
            response.StatusCode = 200;
            if (featured.skill == null || featured.skill == "")
            {
                response.StatusCode = 400;
                response.content = "La descripcion de la skill esta vacia";
                response.succes = false;
                return response;
            }
            if (featured.skill.Length > 255)
            {
                response.StatusCode = 400;
                response.content = "Descripcion de Skill demaciado larga";
                response.succes = false;
                return response;
            }
            return response;
        }
    }
}
