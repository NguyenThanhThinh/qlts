using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;
using System.Data.Entity;

namespace qlts.Stores
{
    public interface IWarehouseStore
    {
        List<Warehouse> GetAllWarehouses();
        Warehouse GetWarehouseById(Guid? id);
        Warehouse CreateWarehouse(Warehouse warehouse);
        Warehouse UpdateWarehouse(Warehouse warehouse);
        bool DeleteWarehouse(Guid? id);

        List<DropdownModel> GetWarehouseDropdown();

    }

    public class WarehouseStore : IWarehouseStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Warehouse> _warehouseRepo;

        public WarehouseStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _warehouseRepo = unitOfWork.Get<Warehouse>();
        }

        public Warehouse CreateWarehouse(Warehouse Warehouse)
        {
            var result = _warehouseRepo.Create(Warehouse);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteWarehouse(Guid? id)
        {
            _warehouseRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _warehouseRepo.All.AsNoTracking().ToList();
        }

        public Warehouse GetWarehouseById(Guid? id)
        {
            return _warehouseRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetWarehouseDropdown()
        {
            return _warehouseRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Warehouse UpdateWarehouse(Warehouse Warehouse)
        {
            var result = _warehouseRepo.Update(Warehouse);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}