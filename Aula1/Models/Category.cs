﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}