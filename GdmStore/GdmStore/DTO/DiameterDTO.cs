﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.DTO
{
    public class DiameterDTO
    {
        public int DiameterId { get; set; }
        public string DiameterValue { get; set; }
        public string Param { get; set; }
        public int ParamId { get; set; }
        public int ProductTypeId { get; set; }
    }
}
