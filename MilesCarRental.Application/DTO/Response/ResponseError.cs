﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.DTO.Response
{
    public class ResponseError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
