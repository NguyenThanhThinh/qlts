using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.Fields;
using System;
using System.Collections.Generic;

namespace qlts.Handlers
{
    public interface IFieldHandler
    {
        Field CreateUpdateField(FieldCreateUpdateViewModel model);
        FieldCreateUpdateViewModel GetFieldById(Guid? id);
        List<FieldIndexViewModel> GetAllFields();
        bool DeleteField(Guid? id);

    }

    public class FieldHandler : IFieldHandler
    {
        private readonly IFieldStore _fieldStore;

        public FieldHandler(IFieldStore fieldStore)
        {
            this._fieldStore = fieldStore;
        }

        public Field CreateUpdateField(FieldCreateUpdateViewModel model)
        {
            var field = MapperConfig.Factory.Map<FieldCreateUpdateViewModel, Field>(model);

            try
            {
                if (field != null && field.Id != Guid.Empty) field.ModifiedDate = DateTime.Now;
                field = field != null && field.Id != Guid.Empty ? _fieldStore.UpdateField(field) : _fieldStore.CreateField(field);
            }
            catch (Exception ex)
            {
                if (ex.IsDuplicateEntity())
                    throw new BusinessException("Tên quyền đã bị trùng");
                else if (ex.IsDuplicateCode())
                    throw new BusinessException("Tên quyền đã bị trùng");

                throw ex;
            }

            return field;
        }

        public bool DeleteField(Guid? id)
        {
            return _fieldStore.DeleteField(id);
        }

        public List<FieldIndexViewModel> GetAllFields()
        {
            var fields = _fieldStore.GetAllFields();
            return MapperConfig.Factory.Map<List<Field>, List<FieldIndexViewModel>>(fields);
        }

        public FieldCreateUpdateViewModel GetFieldById(Guid? id)
        {
            if (id == null)
                return new FieldCreateUpdateViewModel();

            var field = _fieldStore.GetFieldById(id);
            return field == null ? null : MapperConfig.Factory.Map<Field, FieldCreateUpdateViewModel>(field);
        }

    }
}