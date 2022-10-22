﻿using Trattori.DAL;
using Trattori.Models;

namespace Trattori.Services
{
    public class TractorService : ITractorService
    {
        private readonly IList<Tractor> _tractors;
       
        public TractorService(IList<Tractor> tractors)
        {
            _tractors = tractors;
        }

        public Tractor Create(PostTractorModel tractor)
        {
            var tractorToAdd = MappingTwoTractors(tractor);
            _tractors.Add(tractorToAdd);
            return tractorToAdd;
        }

        public void Delete(int id)
        {
            var tractroToDelete = _tractors.FirstOrDefault(tractor => tractor.Id == id);
            if(tractroToDelete == null)
            {
                throw new ArgumentException("no tractor found with such id");
            }
            _tractors.Remove(tractroToDelete);
        }

        public List<Tractor> GetAll(TractorQueryModel tractorQueryModel)
        {
            var filteredTractorList = new List<Tractor>(_tractors);

            if(tractorQueryModel.Id != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Id == tractorQueryModel.Id)
                                      .OrderBy(tractor => tractor.Id)
                                      .ToList();
            }
            if(tractorQueryModel.Model != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Model.Equals(tractorQueryModel.Model))
                                      .OrderBy(tractor => tractor.Model)
                                      .ToList();
            }
            if(tractorQueryModel.Color != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Color == tractorQueryModel.Color)
                                      .ToList();

            }
            if(tractorQueryModel.Brand != null)
            {
                filteredTractorList = filteredTractorList.Where
                                      (tractor => tractor.Brand.Equals(tractorQueryModel.Brand))
                                      .ToList();
            }

            return filteredTractorList;
        }

        public Tractor GetDetails(int id)
        {
           var tractorToFind = _tractors.FirstOrDefault(tractor => tractor.Id == id);
            if(tractorToFind == null)
            {
                throw new ArgumentException("no tractor found with such id");
            }
            return tractorToFind;
        }

        public List<Tractor> GetTractorsByGadgets(int idGadget)
        {
            var tractor = _tractors.ToList();
            var gadgets = tractor.Where(tractor => tractor.Gadgets.Any(gadget => gadget.Id == idGadget));
            return gadgets.ToList();
        }

        public Tractor Update(int id,PostTractorModel newTractor)
        {
            var tractorToUpdate = _tractors.FirstOrDefault(tractor => tractor.Id == id);
            if(tractorToUpdate == null)
            {
                throw new ArgumentException("no tractor found with such id");
            }

            tractorToUpdate.Color = newTractor.Color;
            tractorToUpdate.Brand = newTractor.Brand;
            tractorToUpdate.Model = newTractor.Model;
            tractorToUpdate.Gadgets = newTractor.Gadgets;

            return tractorToUpdate;
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

        private int GetId()
        {
            if(_tractors.Count == 0)
            {
                return 1;
            }

            return _tractors.Max(tractor => tractor.Id) + 1;
        }
    }
}
