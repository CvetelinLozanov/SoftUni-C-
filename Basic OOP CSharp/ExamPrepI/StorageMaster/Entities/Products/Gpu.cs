﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public class Gpu : Product
    {
        private const double GpuWeight = 0.7;

        public Gpu(double price)
            : base(price, GpuWeight)
        {
        }
    }
}
