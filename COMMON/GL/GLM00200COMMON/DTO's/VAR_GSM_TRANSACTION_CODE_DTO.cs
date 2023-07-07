using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLM00200Common.DTO_s
{
    public class VAR_GSM_TRANSACTION_CODE_DTO : R_APIResultBaseDTO
    {
        public VAR_GSM_TRANSACTION_CODE data { get;set; }
    }
    public class VAR_GSM_TRANSACTION_CODE
    {
        public bool LINCREMENT_FLAG { get; set; }
        public bool LAPPROVAL_FLAG { get; set; }
    }
}
