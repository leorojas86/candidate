using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ServiceResult<T> : ServiceResultBase
    {
        #region Properties

        public T Data { get; set; }

        #endregion

        #region Constructors

        public ServiceResult(bool success, T data, string errorMessage)
        {
            Success         = success;
            Data            = data;
            ErrorMessage    = errorMessage;
        }

        #endregion
    }
}