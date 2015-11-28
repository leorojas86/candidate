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

        public T Data { get; set;}

        #endregion

        #region Constructors

        public ServiceResult(bool success, T data = null)
        {
            Success = success;
            Data    = data;
        }

        #endregion
    }
}