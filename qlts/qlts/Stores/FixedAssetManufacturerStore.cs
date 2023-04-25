using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IFixedAssetManufacturerStore
    {
        List<FixedAssetManufacturer> GetAllFixedAssetManufacturers();
        FixedAssetManufacturer GetFixedAssetManufacturerById(Guid? id);
        FixedAssetManufacturer CreateFixedAssetManufacturer(FixedAssetManufacturer FixedAssetManufacturer);
        FixedAssetManufacturer UpdateFixedAssetManufacturer(FixedAssetManufacturer FixedAssetManufacturer);
        bool DeleteFixedAssetManufacturer(Guid? id);

        List<DropdownModel> GetFixedAssetManufacturerDropdown();

    }

    public class FixedAssetManufacturerStore : IFixedAssetManufacturerStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<FixedAssetManufacturer> _FixedAssetManufacturerRepo;

        public FixedAssetManufacturerStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _FixedAssetManufacturerRepo = unitOfWork.Get<FixedAssetManufacturer>();
        }

        public FixedAssetManufacturer CreateFixedAssetManufacturer(FixedAssetManufacturer FixedAssetManufacturer)
        {
            var result = _FixedAssetManufacturerRepo.Create(FixedAssetManufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteFixedAssetManufacturer(Guid? id)
        {
            _FixedAssetManufacturerRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<FixedAssetManufacturer> GetAllFixedAssetManufacturers()
        {
            return _FixedAssetManufacturerRepo.GetAll(null);
        }

        public FixedAssetManufacturer GetFixedAssetManufacturerById(Guid? id)
        {
            return _FixedAssetManufacturerRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFixedAssetManufacturerDropdown()
        {
            return _FixedAssetManufacturerRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.FixedAssetCode,
                    Text = x.FixedAssetCode
                }).ToList();
        }

        public FixedAssetManufacturer UpdateFixedAssetManufacturer(FixedAssetManufacturer FixedAssetManufacturer)
        {
            var result = _FixedAssetManufacturerRepo.Update(FixedAssetManufacturer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}