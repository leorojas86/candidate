using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public abstract class ServiceResultBase
    {
        #region Properties

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}