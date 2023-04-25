using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using System;
using System.Collections.Generic;
using qlts.ViewModels.FixedAssetManufacturers;

namespace qlts.Handlers
{
    public interface IFixedAssetManufacturerHandler
    {
        FixedAssetManufacturer CreateUpdateFixedAssetManufacturer(FixedAssetManufacturerCreateUpdateViewModel model);
        FixedAssetManufacturerCreateUpdateViewModel GetFixedAssetManufacturerById(Guid? id);
        List<FixedAssetManufacturerIndexViewModel> GetAllFixedAssetManufacturers();
        bool DeleteFixedAssetManufacturer(Guid? id);

    }

    public class FixedAssetManufacturerHandler : IFixedAssetManufacturerHandler
    {
        private readonly IFixedAssetManufacturerStore _FixedAssetManufacturerStore;

        public FixedAssetManufacturerHandler(IFixedAssetManufacturerStore FixedAssetManufacturerStore)
        {
            this._FixedAssetManufacturerStore = FixedAssetManufacturerStore;
        }

        public FixedAssetManufacturer CreateUpdateFixedAssetManufacturer( FixedAssetManufacturerCreateUpdateViewModel model )
        {
            var FixedAssetManufacturer = MapperConfig.Factory.Map<FixedAssetManufacturerCreateUpdateViewModel, FixedAssetManufacturer> ( model );

            try
            {
                if ( FixedAssetManufacturer != null && FixedAssetManufacturer.Id != Guid.Empty )
                    FixedAssetManufacturer.ModifiedDate = DateTime.Now;

                FixedAssetManufacturer = FixedAssetManufacturer != null && FixedAssetManufacturer.Id != Guid.Empty ?
                                       _FixedAssetManufacturerStore.UpdateFixedAssetManufacturer ( FixedAssetManufacturer ) : 
                                       _FixedAssetManufacturerStore.CreateFixedAssetManufacturer ( FixedAssetManufacturer );
            }
            catch ( Exception ex )
            {
                if ( ex.IsDuplicateEntity() )
                    throw new BusinessException ( "Có lỗi xảy ra" );
                throw ex;
            }

            return FixedAssetManufacturer;
        }

        public bool DeleteFixedAssetManufacturer(Guid? id)
        {
            return _FixedAssetManufacturerStore.DeleteFixedAssetManufacturer(id);
        }

        public List<FixedAssetManufacturerIndexViewModel> GetAllFixedAssetManufacturers()
        {
            var FixedAssetManufacturers = _FixedAssetManufacturerStore.GetAllFixedAssetManufacturers();
            return MapperConfig.Factory.Map<List<FixedAssetManufacturer>, List<FixedAssetManufacturerIndexViewModel>>(FixedAssetManufacturers);
        }

        public FixedAssetManufacturerCreateUpdateViewModel GetFixedAssetManufacturerById(Guid? id)
        {
            if (id == null)
                return new FixedAssetManufacturerCreateUpdateViewModel();

            var FixedAssetManufacturer = _FixedAssetManufacturerStore.GetFixedAssetManufacturerById(id);
            var model = MapperConfig.Factory.Map<FixedAssetManufacturer, FixedAssetManufacturerCreateUpdateViewModel>(FixedAssetManufacturer);

            model.DateFormattedEdit = model.Date.ToString("dd/MM/yyyy");
            model.WarrantyPeriodDateFormattedEdit = model.WarrantyPeriodDate.ToString("dd/MM/yyyy");

            return model;
        }

    }
}