﻿using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}