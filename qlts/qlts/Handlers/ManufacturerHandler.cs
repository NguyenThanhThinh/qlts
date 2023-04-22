using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using System;
using System.Collections.Generic;
using qlts.ViewModels.Manufacturers;

namespace qlts.Handlers
{
    public interface IManufacturerHandler
    {
        Manufacturer CreateUpdateManufacturer(ManufacturerCreateUpdateViewModel model);
        ManufacturerCreateUpdateViewModel GetManufacturerById(Guid? id);
        List<ManufacturerIndexViewModel> GetAllManufacturers();
        bool DeleteManufacturer(Guid? id);

    }

    public class ManufacturerHandler : IManufacturerHandler
    {
        private readonly IManufacturerStore _manufacturerStore;

        public ManufacturerHandler(IManufacturerStore manufacturerStore)
        {
            this._manufacturerStore = manufacturerStore;
        }

        public Manufacturer CreateUpdateManufacturer( ManufacturerCreateUpdateViewModel model )
        {
            var manufacturer = MapperConfig.Factory.Map<ManufacturerCreateUpdateViewModel, Manufacturer> ( model );

            try
            {
                if ( manufacturer != null && manufacturer.Id != Guid.Empty )
                    manufacturer.ModifiedDate = DateTime.Now;

                manufacturer = manufacturer != null && manufacturer.Id != Guid.Empty ?
                                       _manufacturerStore.UpdateManufacturer ( manufacturer ) : 
                                       _manufacturerStore.CreateManufacturer ( manufacturer );
            }
            catch ( Exception ex )
            {
                if ( ex.IsDuplicateEntity() )
                    throw new BusinessException ( "Có lỗi xảy ra" );
                throw ex;
            }

            return manufacturer;
        }

        public bool DeleteManufacturer(Guid? id)
        {
            return _manufacturerStore.DeleteManufacturer(id);
        }

        public List<ManufacturerIndexViewModel> GetAllManufacturers()
        {
            var Manufacturers = _manufacturerStore.GetAllManufacturers();
            return MapperConfig.Factory.Map<List<Manufacturer>, List<ManufacturerIndexViewModel>>(Manufacturers);
        }

        public ManufacturerCreateUpdateViewModel GetManufacturerById(Guid? id)
        {
            if (id == null)
                return new ManufacturerCreateUpdateViewModel();

            var manufacturer = _manufacturerStore.GetManufacturerById(id);
            return manufacturer == null ? null : MapperConfig.Factory.Map<Manufacturer, ManufacturerCreateUpdateViewModel>(manufacturer);
        }

    }
}