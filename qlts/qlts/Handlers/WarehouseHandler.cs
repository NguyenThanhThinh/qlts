using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using System;
using System.Collections.Generic;
using qlts.ViewModels.Warehouses;

namespace qlts.Handlers
{
    public interface IWarehouseHandler
    {
        Warehouse CreateUpdateWarehouse(WarehouseCreateUpdateViewModel model);
        WarehouseCreateUpdateViewModel GetWarehouseById(Guid? id);
        List<WarehouseIndexViewModel> GetAllWarehouses();
        bool DeleteWarehouse(Guid? id);

    }

    public class WarehouseHandler : IWarehouseHandler
    {
        private readonly IWarehouseStore _WarehouseStore;

        public WarehouseHandler(IWarehouseStore WarehouseStore)
        {
            this._WarehouseStore = WarehouseStore;
        }

        public Warehouse CreateUpdateWarehouse( WarehouseCreateUpdateViewModel model )
        {
            var Warehouse = MapperConfig.Factory.Map<WarehouseCreateUpdateViewModel, Warehouse> ( model );

            try
            {
                if ( Warehouse != null && Warehouse.Id != null )
                    Warehouse.ModifiedDate = DateTime.Now;

                Warehouse = Warehouse != null && Warehouse.Id != null ?
                                       _WarehouseStore.UpdateWarehouse ( Warehouse ) : 
                                       _WarehouseStore.CreateWarehouse ( Warehouse );
            }
            catch ( Exception ex )
            {
                if ( ex.IsDuplicateEntity() )
                    throw new BusinessException ( "Có lỗi xảy ra" );
                throw ex;
            }

            return Warehouse;
        }

        public bool DeleteWarehouse(Guid? id)
        {
            return _WarehouseStore.DeleteWarehouse(id);
        }

        public List<WarehouseIndexViewModel> GetAllWarehouses()
        {
            var Warehouses = _WarehouseStore.GetAllWarehouses();
            return MapperConfig.Factory.Map<List<Warehouse>, List<WarehouseIndexViewModel>>(Warehouses);
        }

        public WarehouseCreateUpdateViewModel GetWarehouseById(Guid? id)
        {
            if (id == null)
                return new WarehouseCreateUpdateViewModel();

            var Warehouse = _WarehouseStore.GetWarehouseById(id);
            return Warehouse == null ? null : MapperConfig.Factory.Map<Warehouse, WarehouseCreateUpdateViewModel>(Warehouse);
        }

    }
}