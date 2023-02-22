using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Template.Aplication.Interface
{
    public interface IFeaturesCommands
    {
        public Response CreateFeature(int id, string skill);
        public Response UpdateFeature(Features features, string newInfo);
        public Response DeleteFeature(Features features);
    }
}
