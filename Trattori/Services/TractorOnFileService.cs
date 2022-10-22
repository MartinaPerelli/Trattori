using Trattori.DAL;
using Trattori.Models;

namespace Trattori.Services
{
    public class TractorOnFileService : ITractorOnFileService
    {
        IDal _tractors;
       

        public TractorOnFileService(IDal tractors)
        {
            _tractors = tractors;
                        
        }

        public Tractor AddTractor(PostTractorModel tractor)
        {
            var tractors = _tractors.ReadAndDeserialize<Tractor>().ToList(); ;
           var tractorToAdd = MappingTwoTractors(tractor);
           tractors.Add(tractorToAdd);
            _tractors.WriteAndSerialize<Tractor>(tractors);
            return tractorToAdd;
        }

        public List<Tractor> GetAll(TractorQueryModel tractorQueryModel) 
        { 
            var filteredTractorList = _tractors.ReadAndDeserialize<Tractor>().ToList();
           
            if (tractorQueryModel.Id != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Id == tractorQueryModel.Id)
                                      .OrderBy(tractor => tractor.Id)
                                      .ToList();
            }
            if (tractorQueryModel.Model != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Model.Equals(tractorQueryModel.Model))
                                      .OrderBy(tractor => tractor.Model)
                                      .ToList();
            }
            if (tractorQueryModel.Color != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Color == tractorQueryModel.Color)
                                      .ToList();

            }
            if (tractorQueryModel.Brand != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Brand.Equals(tractorQueryModel.Brand))
                                      .ToList();
            }

            return filteredTractorList;
        }

        public Tractor Update(int id, PostTractorModel newTractor)
        {
            var tractors = _tractors.ReadAndDeserialize<Tractor>();
            var tractorToUpdate = tractors.FirstOrDefault(tractor => tractor.Id == id);
            if (tractorToUpdate == null)
            {
                throw new ArgumentException("no tractor found with such id");
            }

            tractorToUpdate.Color = newTractor.Color;
            tractorToUpdate.Brand = newTractor.Brand;
            tractorToUpdate.Model = newTractor.Model;
            tractorToUpdate.Gadgets = newTractor.Gadgets;

            _tractors.WriteAndSerialize<Tractor>(tractors);

            return tractorToUpdate;
        }

        public void Delete(int id)
        {
            var tractors = _tractors.ReadAndDeserialize<Tractor>().ToList();
            var tractroToDelete = tractors.FirstOrDefault(tractor => tractor.Id == id);
            if (tractroToDelete == null)
            {
                throw new ArgumentException("no tractor found with such id");
            }
            tractors.Remove(tractroToDelete);
            _tractors.WriteAndSerialize<Tractor>(tractors);
        }
        private int GetId()
        {
            var tractors = _tractors.ReadAndDeserialize<Tractor>().ToList();
            if (tractors.Count == 0)
            {
                return 1;
            }

            return tractors.Max(tractor => tractor.Id) + 1;
        }
        private Tractor MappingTwoTractors(PostTractorModel tractor)
        {
            var tractorMapped = new Tractor();
            tractorMapped.Id = GetId();
            tractorMapped.Model = tractor.Model;
            tractorMapped.Brand = tractor.Brand;
            tractorMapped.Color = tractor.Color;
            tractorMapped.Gadgets = new(tractor.Gadgets);
            return tractorMapped;
        }
    }
}
