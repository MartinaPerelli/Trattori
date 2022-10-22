using Trattori.Models;

namespace Trattori.Services
{
    public interface ITractorOnFileService
    {
        //create // put //delete
        public Tractor AddTractor(PostTractorModel tractor);
        public List<Tractor> GetAll(TractorQueryModel tractorQueryModel);

        public Tractor Update(int id, PostTractorModel newTractor);

        public void Delete(int id);

    }
}
