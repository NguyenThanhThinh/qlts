using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IFixedAssetStatusStore
    {
        List<FixedAssetStatus> GetAllFixedAssetStatuss();
        FixedAssetStatus GetFixedAssetStatusById(Guid? id);
        FixedAssetStatus CreateFixedAssetStatus(FixedAssetStatus FixedAssetStatus);
        FixedAssetStatus UpdateFixedAssetStatus(FixedAssetStatus FixedAssetStatus);
        bool DeleteFixedAssetStatus(Guid? id);

        List<DropdownModel> GetFixedAssetStatusDropdown();

    }

    public class FixedAssetStatusStore : IFixedAssetStatusStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<FixedAssetStatus> FixedAssetStatusRepo;

        public FixedAssetStatusStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            FixedAssetStatusRepo = unitOfWork.Get<FixedAssetStatus>();
        }

        public FixedAssetStatus CreateFixedAssetStatus(FixedAssetStatus FixedAssetStatus)
        {
            var result = FixedAssetStatusRepo.Create(FixedAssetStatus);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteFixedAssetStatus(Guid? id)
        {
            FixedAssetStatusRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<FixedAssetStatus> GetAllFixedAssetStatuss()
        {
            return FixedAssetStatusRepo.GetAll(null);
        }

        public FixedAssetStatus GetFixedAssetStatusById(Guid? id)
        {
            return FixedAssetStatusRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFixedAssetStatusDropdown()
        {
            return FixedAssetStatusRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public FixedAssetStatus UpdateFixedAssetStatus(FixedAssetStatus FixedAssetStatus)
        {
            var result = FixedAssetStatusRepo.Update(FixedAssetStatus);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}