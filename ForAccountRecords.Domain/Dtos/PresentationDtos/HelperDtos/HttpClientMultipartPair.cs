﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.PresentationDtos.HelperDtos
{
    public class HttpClientMultipartPair
    {


        public string FormName { get; set; }

        public object FormContent { get; set; }


        public string? FileName { get; set; }


        public int FormContentTypeId { get; set; }

    }
}
