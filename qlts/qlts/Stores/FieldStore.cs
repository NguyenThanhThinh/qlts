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
        Field CreateField(Field Field);
        Field UpdateField(Field Field);
        bool DeleteField(Guid? id);

        List<DropdownModel> GetFieldDropdown();

    }

    public class FieldStore : IFieldStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Field> FieldRepo;

        public FieldStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            FieldRepo = unitOfWork.Get<Field>();
        }

        public Field CreateField(Field Field)
        {
            var result = FieldRepo.Create(Field);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteField(Guid? id)
        {
            FieldRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<Field> GetAllFields()
        {
            return FieldRepo.GetAll(null);
        }

        public Field GetFieldById(Guid? id)
        {
            return FieldRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetFieldDropdown()
        {
            return FieldRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public Field UpdateField(Field Field)
        {
            var result = FieldRepo.Update(Field);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}