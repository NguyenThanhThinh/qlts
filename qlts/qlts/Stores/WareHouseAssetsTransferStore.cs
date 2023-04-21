using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IWareHouseAssetsTransferStore
    {
        List<WareHouseAssetsTransfer> GetAllWareHouseAssetsTransfers();
        WareHouseAssetsTransfer GetWareHouseAssetsTransferById(Guid? id);
        WareHouseAssetsTransfer CreateWareHouseAssetsTransfer(WareHouseAssetsTransfer wareHouseAssetsTransfer);
        WareHouseAssetsTransfer UpdateWareHouseAssetsTransfer(WareHouseAssetsTransfer wareHouseAssetsTransfer);
        bool DeleteWareHouseAssetsTransfer(Guid? id);


    }

    public class WareHouseAssetsTransferStore : IWareHouseAssetsTransferStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<WareHouseAssetsTransfer> _wareHouseAssetsTransferRepo;

        public WareHouseAssetsTransferStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _wareHouseAssetsTransferRepo = unitOfWork.Get<WareHouseAssetsTransfer>();
        }

        public WareHouseAssetsTransfer CreateWareHouseAssetsTransfer(WareHouseAssetsTransfer wareHouseAssetsTransfer)
        {
            var result = _wareHouseAssetsTransferRepo.Create(wareHouseAssetsTransfer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteWareHouseAssetsTransfer(Guid? id)
        {
            _wareHouseAssetsTransferRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<WareHouseAssetsTransfer> GetAllWareHouseAssetsTransfers()
        {
            return _wareHouseAssetsTransferRepo.GetAll(null);
        }

        public WareHouseAssetsTransfer GetWareHouseAssetsTransferById(Guid? id)
        {
            return _wareHouseAssetsTransferRepo.Get(n => n.Id == id);
        }

       
        public WareHouseAssetsTransfer UpdateWareHouseAssetsTransfer(WareHouseAssetsTransfer wareHouseAssetsTransfer)
        {
            var result = _wareHouseAssetsTransferRepo.Update(wareHouseAssetsTransfer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}