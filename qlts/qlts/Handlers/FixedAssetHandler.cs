using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.ViewModels.Accounts;
using qlts.ViewModels.FixedAssets;
using System;
using System.Collections.Generic;
using qlts.Helpers;
using qlts.Stores;
using System.Configuration;

namespace qlts.Handlers
{
    public interface IFixedAssetHandler
    {
        FixedAsset CreateUpdateFixedAsset(FixedAssetCreateUpdateViewModel model);

        FixedAssetCreateUpdateViewModel GetFixedAssetById(Guid? id);

        List<FixedAssetIndexViewModel> GetAllFixedAssets();
        bool DeleteFixedAsset(Guid? id);

        FixedAssetCreateUpdateViewModel FixedAssetWithDropdown(FixedAssetCreateUpdateViewModel model);

    }

    public class FixedAssetHandler : IFixedAssetHandler
    {
        private readonly IFixedAssetStore _FixedAssetStore;
        private readonly IFieldStore _fieldStore;
        private readonly IFixedAssetStatusStore _fixedAssetStatusStore;
        private readonly IManufacturerStore _manufacturerStore;

        public FixedAssetHandler(IFixedAssetStore FixedAssetStore,
            IFieldStore fieldStore,
            IFixedAssetStatusStore fixedAssetStatusStore,
            IManufacturerStore manufacturerStore)
        {
            this._FixedAssetStore = FixedAssetStore;
            _fieldStore = fieldStore;
            _fixedAssetStatusStore = fixedAssetStatusStore;
            _manufacturerStore = manufacturerStore;
        }

        public FixedAsset CreateUpdateFixedAsset(FixedAssetCreateUpdateViewModel model)
        {
            var FixedAsset = MapperConfig.Factory.Map<FixedAssetCreateUpdateViewModel, FixedAsset>(model);

            try
            {
                if (FixedAsset != null && FixedAsset.Id != null)
                {
                    FixedAsset.ModifiedDate = DateTime.Now;
                }

                FixedAsset = FixedAsset != null && FixedAsset.Id != null ? _FixedAssetStore.UpdateFixedAsset(FixedAsset) : _FixedAssetStore.CreateFixedAsset(FixedAsset);
            }
            catch (Exception ex)
            {
                if (ex.IsDuplicateEntity())
                    throw new BusinessException("Tài sản đã bị trùng");
                else if (ex.IsDuplicateCode())
                    throw new BusinessException("Tài sản đã bị trùng");

                throw ex;
            }

            return FixedAsset;
        }



        public bool DeleteFixedAsset(Guid? id)
        {
            return _FixedAssetStore.DeleteFixedAsset(id);
        }

        public List<FixedAssetIndexViewModel> GetAllFixedAssets()
        {
            var FixedAssets = _FixedAssetStore.GetAllFixedAssets();
            return MapperConfig.Factory.Map<List<FixedAsset>, List<FixedAssetIndexViewModel>>(FixedAssets);
        }

        public FixedAssetCreateUpdateViewModel GetFixedAssetById(Guid? id)
        {
            if (id == null)
                return FixedAssetWithDropdown(new FixedAssetCreateUpdateViewModel());

            var FixedAsset = _FixedAssetStore.GetFixedAssetById(id);

            if (FixedAsset == null) return null;

            var model = MapperConfig.Factory.Map<FixedAsset, FixedAssetCreateUpdateViewModel>(FixedAsset);

            return FixedAssetWithDropdown(model);
        }


        public FixedAssetCreateUpdateViewModel FixedAssetWithDropdown(FixedAssetCreateUpdateViewModel model)
        {
            if (model == null)
                throw new BusinessException("Không có dữ liệu");

            model.Fields = _fieldStore.GetFieldDropdown();
            model.FixedAssetStatus = _fixedAssetStatusStore.GetFixedAssetStatusDropdown();
            model.Manufacturers = _manufacturerStore.GetManufacturerDropdown();
            return model;
        }
    }
}