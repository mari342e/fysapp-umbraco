﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fysapp_umbraco.Models
{
    public class Accordion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserGroupID { get; set; }
    }
}