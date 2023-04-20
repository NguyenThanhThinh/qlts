using qlts.Models;

namespace qlts.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsSuccess(this BaseEntity entity) => entity != null && entity.Id != null;
    }
}