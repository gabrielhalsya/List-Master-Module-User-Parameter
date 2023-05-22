using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSM04000Common
{
    public interface IGSM04100 : R_IServiceCRUDBase<GSM04100DTO>
    {
        GSM04100ListDTO GetGSM04100ListByDeptCode();
        IAsyncEnumerable<GSM04100DTO> GetUserToAssignList();

    }
}
