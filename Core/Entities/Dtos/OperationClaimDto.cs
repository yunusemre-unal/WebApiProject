﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos
{
    public class OperationClaimDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
