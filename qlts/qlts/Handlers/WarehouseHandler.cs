using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.FixedAssetStatus;
using System;
using System.Collections.Generic;

namespace qlts.Handlers
{
    public interface IWarehouseHandler
    {
        FixedAssetStatus CreateUpdateFixedAssetStatus(FixedAssetStatusCreateUpdateViewModel model);
        FixedAssetStatusCreateUpdateViewModel GetFixedAssetStatusById(Guid? id);
        List<FixedAssetStatusIndexViewModel> GetAllFixedAssetStatuss();
        bool DeleteFixedAssetStatus(Guid? id);

    }

    public class WarehouseHandler : IFixedAssetStatusHandler
    {
        private readonly IFixedAssetStatusStore _fixedAssetStatusStore;

        public WarehouseHandler(IFixedAssetStatusStore fixedAssetStatusStore)
        {
            this._fixedAssetStatusStore = fixedAssetStatusStore;
        }

        public FixedAssetStatus CreateUpdateFixedAssetStatus( FixedAssetStatusCreateUpdateViewModel model )
        {
            var fixedAssetStatus = MapperConfig.Factory.Map<FixedAssetStatusCreateUpdateViewModel, FixedAssetStatus> ( model );

            try
            {
                if ( fixedAssetStatus != null && fixedAssetStatus.Id != null )
                    fixedAssetStatus.ModifiedDate = DateTime.Now;

                fixedAssetStatus = fixedAssetStatus != null && fixedAssetStatus.Id != null ?
                                       _fixedAssetStatusStore.UpdateFixedAssetStatus ( fixedAssetStatus ) : 
                                       _fixedAssetStatusStore.CreateFixedAssetStatus ( fixedAssetStatus );
            }
            catch ( Exception ex )
            {
                if ( ex.IsDuplicateEntity() )
                    throw new BusinessException ( "Có lỗi xảy ra" );
                throw ex;
            }

            return fixedAssetStatus;
        }

        public bool DeleteFixedAssetStatus(Guid? id)
        {
            return _fixedAssetStatusStore.DeleteFixedAssetStatus(id);
        }

        public List<FixedAssetStatusIndexViewModel> GetAllFixedAssetStatuss()
        {
            var fixedAssetStatuss = _fixedAssetStatusStore.GetAllFixedAssetStatuss();
            return MapperConfig.Factory.Map<List<FixedAssetStatus>, List<FixedAssetStatusIndexViewModel>>(fixedAssetStatuss);
        }

        public FixedAssetStatusCreateUpdateViewModel GetFixedAssetStatusById(Guid? id)
        {
            if (id == null)
                return new FixedAssetStatusCreateUpdateViewModel();

            var fixedAssetStatus = _fixedAssetStatusStore.GetFixedAssetStatusById(id);
            return fixedAssetStatus == null ? null : MapperConfig.Factory.Map<FixedAssetStatus, FixedAssetStatusCreateUpdateViewModel>(fixedAssetStatus);
        }

    }
}