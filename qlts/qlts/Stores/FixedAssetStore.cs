using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IFixedAssetStore
    {
        List<FixedAsset> GetAllFixedAssets();
        FixedAsset GetFixedAssetById(Guid? id);
        FixedAsset CreateFixedAsset(FixedAsset fixedAsset);
        FixedAsset UpdateFixedAsset(FixedAsset fixedAsset);
        bool DeleteFixedAsset(Guid? id);

        List<DropdownModel> GetFixedAssetDropdown();

    }

    public class FixedAssetStore : IFixedAssetStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<FixedAsset> _fixedAssetRepo;

        public FixedAssetStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _fixedAssetRepo = unitOfWork.Get<FixedAsset>();
        }

        public FixedAsset CreateFixedAsset(FixedAsset fixedAsset)
        {
            var result = _fixedAssetRepo.Create(fixedAsset);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteFixedAsset(Guid? id)
        {
            _fixedAssetRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<FixedAsset> GetAllFixedAssets()
        {
            return _fixedAssetRepo.GetAll(null);
        }

        public FixedAsset GetFixedAssetById(Guid? id)
        {
            return _fixedAssetRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFixedAssetDropdown()
        {
            return _fixedAssetRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public FixedAsset UpdateFixedAsset(FixedAsset fixedAsset)
        {
            var result = _fixedAssetRepo.Update(fixedAsset);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}