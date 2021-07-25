﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Name { get; set; }

       
        public virtual Concept Concept { get; set; }
    }
}
