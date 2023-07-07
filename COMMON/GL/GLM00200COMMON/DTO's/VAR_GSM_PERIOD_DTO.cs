using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLM00200Common.DTO_s
{
    public class VAR_GSM_PERIOD_DTO : R_APIResultBaseDTO
    {
       public VAR_GSM_PERIOD data { get; set; } 
    }

    public class VAR_GSM_PERIOD
    {
        public int IMIN_YEAR { get; set; }
        public int IMAX_YEAR { get; set; }
    }
}
