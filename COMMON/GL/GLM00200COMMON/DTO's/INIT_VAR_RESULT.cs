using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLM00200Common.DTO_s
{

    public class INIT_VAR_RESULT_DTO : R_APIResultBaseDTO
    {
        public INIT_VAR_RESULT data { get;set; }
    }
    public class INIT_VAR_RESULT : R_APIResultBaseDTO
    {
        public VAR_TODAY_DTO CTODAY { get; set; }
        public VAR_CCURRENT_PERIOD_START_DATE_DTO CCURRENT_PERIOD_START_DATE { get; set; }
        public VAR_CSOFT_PERIOD_START_DATE_DTO CSOFT_PERIOD_START_DATE { get; set; }
        public VAR_CURRENCY  CURRENCY { get; set; }
        public VAR_GL_SYSTEM_PARAM_DTO GL_SYSTEM_PARAM { get; set; }
        public VAR_GSM_COMPANY_DTO GSM_COMPANY { get; set; }
        public VAR_GSM_PERIOD_DTO GSM_PERIOD { get; set; }
        public VAR_GSM_TRANSACTION_CODE_DTO GSM_TRANSACTION_CODE { get; set; }
        public VAR_IUNDO_COMMIT_JRN_DTO IUNDO_COMMIT_JRN { get; set; }
        public List<VAR_STATUS_DTO> LIST_STATUS { get; set; }
    }


}
