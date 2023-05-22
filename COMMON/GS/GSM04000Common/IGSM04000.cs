using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSM04000Common
{
    public interface IGSM04000 : R_IServiceCRUDBase<GSM04000DTO>
    {
        IAsyncEnumerable<GSM04000DTO> GetGSM04000List();
        GSM04000ActiveInactiveDTO RSP_GS_ACTIVE_INACTIVE_DEPTMethod();
    }
}
