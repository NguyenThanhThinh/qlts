using qlts.Datas;
using System;
using toys.Extensions;

namespace qlts.Extensions
{
    public static class ExceptionExtensions
    {
        public static bool IsDuplicateEntity(this Exception ex)
        {
            return ex.Message.Contains("Cannot insert duplicate key row in object");
        }
        public static bool IsDuplicateCode(this Exception ex)
        {
            return ex.Message.Contains("An error occurred while updating the entries. See the inner exception for details.");
        }
        public static string GetErrorMessage(this Exception ex)
        {
            if (ex is BusinessException)
                return ex.Message;

            return ex.ToErrorMessage();
        }
    }
}