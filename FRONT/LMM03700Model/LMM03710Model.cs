using LMM03700Common;
using LMM03700Common.DTO_s;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMM03700Model
{
    public class LMM03710Model : R_BusinessObjectServiceClientBase<TenantClassificationDTO>, ILMM03710
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrlLM";
        private const string DEFAULT_CHECKPOINT_NAME = "api/LMM03700";
        private const string DEFAULT_MODULE = "LM";
        public LMM03710Model(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_CHECKPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true
            ) : base(
                pcHttpClientName,
                pcRequestServiceEndPoint,
                DEFAULT_MODULE,
                plSendWithContext,
                plSendWithToken)
        {
        }

        public IAsyncEnumerable<TenantDTO> GetAssignedTenantList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TenantDTO>> GetAssignedTenantListAsync()
        {
            var loEx = new R_Exception();
            List<TenantDTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<TenantDTO>(
                    _RequestServiceEndPoint,
                    nameof(ILMM03710.GetAssignedTenantList),
                    DEFAULT_MODULE, _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;

        }

        public IAsyncEnumerable<TenantClassificationDTO> GetTenantClassificationList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TenantClassificationDTO>> GetTenantClassificationListAsync()
        {
            var loEx = new R_Exception();
            List<TenantClassificationDTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<TenantClassificationDTO>(
                    _RequestServiceEndPoint,
                    nameof(ILMM03710.GetTenantClassificationList),
                    DEFAULT_MODULE, _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;

        }
    }
}
