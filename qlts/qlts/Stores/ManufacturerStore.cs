using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IManufacturerStore
    {
        List<Manufacturer> GetAllManufacturers();
        Manufacturer GetManufacturerById(Guid? id);
        Manufacturer CreateManufacturer(Manufacturer manufacturer);
        Manufacturer UpdateManufacturer(Manufacturer manufacturer);
        bool DeleteManufacturer(Guid? id);

        List<DropdownModel> GetManufacturerDropdown();

    }

    public class ManufacturerStore : IManufacturerStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Manufacturer> _manufacturerRepo;

        public ManufacturerStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _manufacturerRepo = unitOfWork.Get<Manufacturer>();
        }

        public Manufacturer CreateManufacturer(Manufacturer manufacturer)
        {
            var result = _manufacturerRepo.Create(manufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteManufacturer(Guid? id)
        {
            _manufacturerRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _manufacturerRepo.GetAll(null);
        }

        public Manufacturer GetManufacturerById(Guid? id)
        {
            return _manufacturerRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetManufacturerDropdown()
        {
            return _manufacturerRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Manufacturer UpdateManufacturer(Manufacturer manufacturer)
        {
            var result = _manufacturerRepo.Update(manufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}