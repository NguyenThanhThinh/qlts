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
        WareHouseAssetsTransfer CreateWareHouseAssetsTransfer(WareHouseAssetsTransfer WareHouseAssetsTransfer);
        WareHouseAssetsTransfer UpdateWareHouseAssetsTransfer(WareHouseAssetsTransfer WareHouseAssetsTransfer);
        bool DeleteWareHouseAssetsTransfer(Guid? id);


    }

    public class WareHouseAssetsTransferStore : IWareHouseAssetsTransferStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<WareHouseAssetsTransfer> WareHouseAssetsTransferRepo;

        public WareHouseAssetsTransferStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            WareHouseAssetsTransferRepo = unitOfWork.Get<WareHouseAssetsTransfer>();
        }

        public WareHouseAssetsTransfer CreateWareHouseAssetsTransfer(WareHouseAssetsTransfer WareHouseAssetsTransfer)
        {
            var result = WareHouseAssetsTransferRepo.Create(WareHouseAssetsTransfer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteWareHouseAssetsTransfer(Guid? id)
        {
            WareHouseAssetsTransferRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<WareHouseAssetsTransfer> GetAllWareHouseAssetsTransfers()
        {
            return WareHouseAssetsTransferRepo.GetAll(null);
        }

        public WareHouseAssetsTransfer GetWareHouseAssetsTransferById(Guid? id)
        {
            return WareHouseAssetsTransferRepo.Get(n => n.Id == id);
        }

       
        public WareHouseAssetsTransfer UpdateWareHouseAssetsTransfer(WareHouseAssetsTransfer WareHouseAssetsTransfer)
        {
            var result = WareHouseAssetsTransferRepo.Update(WareHouseAssetsTransfer);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}