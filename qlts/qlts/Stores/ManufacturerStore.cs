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
        Manufacturer CreateManufacturer(Manufacturer Manufacturer);
        Manufacturer UpdateManufacturer(Manufacturer Manufacturer);
        bool DeleteManufacturer(Guid? id);

        List<DropdownModel> GetManufacturerDropdown();

    }

    public class ManufacturerStore : IManufacturerStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Manufacturer> ManufacturerRepo;

        public ManufacturerStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ManufacturerRepo = unitOfWork.Get<Manufacturer>();
        }

        public Manufacturer CreateManufacturer(Manufacturer Manufacturer)
        {
            var result = ManufacturerRepo.Create(Manufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteManufacturer(Guid? id)
        {
            ManufacturerRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return ManufacturerRepo.GetAll(null);
        }

        public Manufacturer GetManufacturerById(Guid? id)
        {
            return ManufacturerRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetManufacturerDropdown()
        {
            return ManufacturerRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Manufacturer UpdateManufacturer(Manufacturer Manufacturer)
        {
            var result = ManufacturerRepo.Update(Manufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}