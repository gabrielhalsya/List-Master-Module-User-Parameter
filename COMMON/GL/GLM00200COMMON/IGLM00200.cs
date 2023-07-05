using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;

namespace GLM00200Common
{
    public interface IGLM00200 : R_IServiceCRUDBase<JournalDTO>
    {
        IAsyncEnumerable<JournalGridDTO> GetAllRecurringList();
        IAsyncEnumerable<JournalGridDTO> GetFilteredRecurringList();
        IAsyncEnumerable<string> GetStatusJournalList();

    }
}
