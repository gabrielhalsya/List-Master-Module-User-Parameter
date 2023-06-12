using LMM03700Common.DTO_s;
using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;

namespace LMM03700Common
{
    public interface ILMM03710:R_IServiceCRUDBase<TenantClassificationDTO>
    {
        IAsyncEnumerable<TenantClassificationDTO> GetTenantClassificationList();
        IAsyncEnumerable<TenantDTO> GetAssignedTenantList();
        IAsyncEnumerable<TenantToAssignDTO> GetTenantList();
        AssignTenantResultDTO AssignTenant();
    }

}
