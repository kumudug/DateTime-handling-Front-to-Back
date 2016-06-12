﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeFrontToBack.API.Data.Entities
{
    public class DataPoc
    {
        public int Id { get; set; }
        // ReSharper disable once InconsistentNaming
        public DateTime StoredDateTimeUTC { get; set; }
        public DateTimeOffset StoredDateTimeOffset { get; set; }
    }
}