using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeFrontToBack.API.Data.ViewModels
{
    public class DataPocViewModel
    {
        public int Id { get; set; }
        // ReSharper disable once InconsistentNaming
        public DateTime StoredDateTime { get; set; }
    }
}