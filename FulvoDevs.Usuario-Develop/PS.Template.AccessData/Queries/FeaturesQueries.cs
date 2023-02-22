using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Domain.Models;

namespace PS.Template.AccessData.Queries
{
    public class FeaturesQueries : IFeaturesQueries
    {
        private readonly ProyectoSoftwareContext _context;
        public FeaturesQueries(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }
        public List<Features> GetUserFeatures(int id)
        {
            List<Features> list = _context.features.Where(X => X.UsuarioId == id).Where(Y => Y.softDelete == false).ToList();
            return list;
        }
        public Features AskExistingFeatures(int id, string featured)
        {
            var feature = _context.features.Where(X => X.UsuarioId == id).Where(Z => Z.Skills == featured).Where(Y => Y.softDelete == false).FirstOrDefault();
            return feature;
        }
    }
}