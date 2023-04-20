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
        FixedAsset CreateFixedAsset(FixedAsset FixedAsset);
        FixedAsset UpdateFixedAsset(FixedAsset FixedAsset);
        bool DeleteFixedAsset(Guid? id);

        List<DropdownModel> GetFixedAssetDropdown();

    }

    public class FixedAssetStore : IFixedAssetStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<FixedAsset> FixedAssetRepo;

        public FixedAssetStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            FixedAssetRepo = unitOfWork.Get<FixedAsset>();
        }

        public FixedAsset CreateFixedAsset(FixedAsset FixedAsset)
        {
            var result = FixedAssetRepo.Create(FixedAsset);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteFixedAsset(Guid? id)
        {
            FixedAssetRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<FixedAsset> GetAllFixedAssets()
        {
            return FixedAssetRepo.GetAll(null);
        }

        public FixedAsset GetFixedAssetById(Guid? id)
        {
            return FixedAssetRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFixedAssetDropdown()
        {
            return FixedAssetRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public FixedAsset UpdateFixedAsset(FixedAsset FixedAsset)
        {
            var result = FixedAssetRepo.Update(FixedAsset);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}