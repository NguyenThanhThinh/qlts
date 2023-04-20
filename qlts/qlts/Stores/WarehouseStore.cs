using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IWarehouseStore
    {
        List<Warehouse> GetAllWarehouses();
        Warehouse GetWarehouseById(Guid? id);
        Warehouse CreateWarehouse(Warehouse Warehouse);
        Warehouse UpdateWarehouse(Warehouse Warehouse);
        bool DeleteWarehouse(Guid? id);

        List<DropdownModel> GetWarehouseDropdown();

    }

    public class WarehouseStore : IWarehouseStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Warehouse> WarehouseRepo;

        public WarehouseStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            WarehouseRepo = unitOfWork.Get<Warehouse>();
        }

        public Warehouse CreateWarehouse(Warehouse Warehouse)
        {
            var result = WarehouseRepo.Create(Warehouse);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteWarehouse(Guid? id)
        {
            WarehouseRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return WarehouseRepo.GetAll(null);
        }

        public Warehouse GetWarehouseById(Guid? id)
        {
            return WarehouseRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetWarehouseDropdown()
        {
            return WarehouseRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Warehouse UpdateWarehouse(Warehouse Warehouse)
        {
            var result = WarehouseRepo.Update(Warehouse);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}