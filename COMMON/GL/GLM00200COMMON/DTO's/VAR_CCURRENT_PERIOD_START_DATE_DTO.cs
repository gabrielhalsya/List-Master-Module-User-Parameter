﻿using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLM00200Common.DTO_s
{
    public class VAR_CCURRENT_PERIOD_START_DATE_DTO : R_APIResultBaseDTO
    {
        public VAR_CCURRENT_PERIOD_START_DATE data { get; set; }
    }

    public class VAR_CCURRENT_PERIOD_START_DATE
    {
        public string CSTART_DATE { get; set; }
    }
}
