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
        FixedAssetStatus CreateFixedAssetStatus(FixedAssetStatus fixedAssetStatus);
        FixedAssetStatus UpdateFixedAssetStatus(FixedAssetStatus fixedAssetStatus);
        bool DeleteFixedAssetStatus(Guid? id);

        List<DropdownModel> GetFixedAssetStatusDropdown();

    }

    public class FixedAssetStatusStore : IFixedAssetStatusStore
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<FixedAssetStatus> _fixedAssetStatusRepo;

        public FixedAssetStatusStore(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _fixedAssetStatusRepo = unitOfWork.Get<FixedAssetStatus>();
        }

        public FixedAssetStatus CreateFixedAssetStatus(FixedAssetStatus fixedAssetStatus)
        {
            var result = _fixedAssetStatusRepo.Create(fixedAssetStatus);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteFixedAssetStatus(Guid? id)
        {
            _fixedAssetStatusRepo.Delete(n => n.Id == id);
            return _unitOfWork.SaveChanges() > 0;
        }

        public List<FixedAssetStatus> GetAllFixedAssetStatuss()
        {
            return _fixedAssetStatusRepo.GetAll(null);
        }

        public FixedAssetStatus GetFixedAssetStatusById(Guid? id)
        {
            return _fixedAssetStatusRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFixedAssetStatusDropdown()
        {
            return _fixedAssetStatusRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
        }

        public FixedAssetStatus UpdateFixedAssetStatus(FixedAssetStatus fixedAssetStatus)
        {
            var result = _fixedAssetStatusRepo.Update(fixedAssetStatus);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}