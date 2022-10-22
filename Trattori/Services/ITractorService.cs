using Trattori.Models;

namespace Trattori.Services
{
    public interface ITractorService
    {
        public Tractor Create(PostTractorModel tractor);
        public Tractor GetDetails(int id);

        public List<Tractor> GetAll(TractorQueryModel tractorQueryModel);

        public List<Tractor> GetTractorsByGadgets(int idGadget);


        public Tractor Update(int id, PostTractorModel newTractor);

        public void Delete(int id); 
    }
}
