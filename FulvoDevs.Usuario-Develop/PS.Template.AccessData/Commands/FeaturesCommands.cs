using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;

namespace PS.Template.AccessData.Commands
{
    public class FeaturesCommands : IFeaturesCommands
    {
        private readonly ProyectoSoftwareContext _context;
        public FeaturesCommands(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }
        public Response CreateFeature(int id, string skill)
        {
            try
            {
                var feature = new Features
                {
                    UsuarioId = id,
                    Skills = skill,
                    softDelete = false
                };
                _context.features.Add(feature);
                _context.SaveChanges();

                var responseCreated = new Response(true, "creacion del Feature completada"); responseCreated.StatusCode = 200;
                responseCreated.objects = feature;
                return responseCreated;
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
        public Response UpdateFeature(Features features, string newInfo)
        {
            try
            {
                features.Skills = newInfo;
                _context.SaveChanges();

                var responseCreated = new Response(true, "actualizacion del Feature completada"); responseCreated.StatusCode = 200;
                responseCreated.objects = features;
                return responseCreated;
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
        public Response DeleteFeature(Features features)
        {
            try
            {
                features.softDelete = true;
                _context.SaveChanges();

                var responseCreated = new Response(true, "Delete del Feature completada"); responseCreated.StatusCode = 200;
                responseCreated.objects = features;
                return responseCreated;
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
    }
}



