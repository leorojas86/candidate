using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ServiceResult<T> where T : class
    {
        #region Properties

        public bool Success { get; set; }

        public T Data { get; set; }

        public string ErrorMessage { get; set; }

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