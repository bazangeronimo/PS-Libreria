using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interface
{
    public interface IFeaturesQueries
    {
        public List<Features> GetUserFeatures(int id);
        public Features AskExistingFeatures(int id, string featured);
    }
}