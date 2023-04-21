using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IFieldStore
    {
        List<Field> GetAllFields();
        Field GetFieldById(Guid? id);
        Field CreateField(Field field);
        Field UpdateField(Field field);
        bool DeleteField(Guid? id);

        List<DropdownModel> GetFieldDropdown();

    }

    public class FieldStore : IFieldStore
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Field> _fieldRepo;

        public FieldStore(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _fieldRepo = unitOfWork.Get<Field>();
        }

        public Field CreateField(Field Field)
        {
            var result = _fieldRepo.Create(Field);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteField(Guid? id)
        {
            _fieldRepo.Delete(n => n.Id == id);
            return _unitOfWork.SaveChanges() > 0;
        }

        public List<Field> GetAllFields()
        {
            return _fieldRepo.GetAll(null);
        }

        public Field GetFieldById(Guid? id)
        {
            return _fieldRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFieldDropdown()
        {
            return _fieldRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Field UpdateField(Field field)
        {
            var result = _fieldRepo.Update(field);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}