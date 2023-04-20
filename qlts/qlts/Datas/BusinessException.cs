using System;

namespace qlts.Models
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}