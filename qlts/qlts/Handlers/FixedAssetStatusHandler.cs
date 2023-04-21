using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.FixedAssetStatus;
using System;
using System.Collections.Generic;

namespace qlts.Handlers
{
    public interface IFixedAssetStatusHandler
    {
        FixedAssetStatus CreateUpdateFixedAssetStatus(FixedAssetStatusCreateUpdateViewModel model);
        FixedAssetStatusCreateUpdateViewModel GetFixedAssetStatusById(Guid? id);
        List<FixedAssetStatusIndexViewModel> GetAllFixedAssetStatuss();
        bool DeleteFixedAssetStatus(Guid? id);

    }

    public class FixedAssetStatusHandler : IFixedAssetStatusHandler
    {
        private readonly IFixedAssetStatusStore _FixedAssetStatusStore;

        public FixedAssetStatusHandler(IFixedAssetStatusStore FixedAssetStatusStore)
        {
            this._FixedAssetStatusStore = FixedAssetStatusStore;
        }

        public FixedAssetStatus CreateUpdateFixedAssetStatus( FixedAssetStatusCreateUpdateViewModel model )
        {
            var fixedAssetStatus = MapperConfig.Factory.Map<FixedAssetStatusCreateUpdateViewModel, FixedAssetStatus> ( model );

            try
            {
                if ( fixedAssetStatus != null && fixedAssetStatus.Id != null )
                    fixedAssetStatus.ModifiedDate = DateTime.Now;

                fixedAssetStatus = fixedAssetStatus != null && fixedAssetStatus.Id != null ?
                                       _FixedAssetStatusStore.UpdateFixedAssetStatus ( fixedAssetStatus ) : 
                                       _FixedAssetStatusStore.CreateFixedAssetStatus ( fixedAssetStatus );
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
            return _FixedAssetStatusStore.DeleteFixedAssetStatus(id);
        }

        public List<FixedAssetStatusIndexViewModel> GetAllFixedAssetStatuss()
        {
            var FixedAssetStatuss = _FixedAssetStatusStore.GetAllFixedAssetStatuss();
            return MapperConfig.Factory.Map<List<FixedAssetStatus>, List<FixedAssetStatusIndexViewModel>>(FixedAssetStatuss);
        }

        public FixedAssetStatusCreateUpdateViewModel GetFixedAssetStatusById(Guid? id)
        {
            if (id == null)
                return new FixedAssetStatusCreateUpdateViewModel();

            var fixedAssetStatus = _FixedAssetStatusStore.GetFixedAssetStatusById(id);
            return fixedAssetStatus == null ? null : MapperConfig.Factory.Map<FixedAssetStatus, FixedAssetStatusCreateUpdateViewModel>(fixedAssetStatus);
        }

    }
}