using GSM04000Common;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSM04000Model
{
    public class GSM04000Model : R_BusinessObjectServiceClientBase<GSM04000DTO>, IGSM04000
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_CHECKPOINT_NAME = "api/GSM04000";

        public GSM04000Model(
            string pcHttpClientName =DEFAULT_HTTP_NAME, 
            string pcRequestServiceEndPoint=DEFAULT_CHECKPOINT_NAME, 
            bool plSendWithContext = true,
            bool plSendWithToken = true
            ) : base(
                pcHttpClientName, 
                pcRequestServiceEndPoint, 
                plSendWithContext, 
                plSendWithToken)
        {
        }

        #region GetDepartmentList
        public IAsyncEnumerable<GSM04000DTO> GetGSM04000List()
        {
            throw new NotImplementedException();
        }

        public async Task<List<GSM04000DTO>> GetGSM04000ListAsync()

        {
            var loEx = new R_Exception();
            List<GSM04000DTO> loResult = null;
            
            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<GSM04000DTO>(
                    _RequestServiceEndPoint,
                    nameof(IGSM04000.GetGSM04000List),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;

        }

        public GSM04000ActiveInactiveDTO RSP_GS_ACTIVE_INACTIVE_DEPTMethod()
        {
            throw new NotImplementedException();
        }

        public async Task RSP_GS_ACTIVE_INACTIVE_DEPTMethodAsync()
        {
            R_Exception loEx = new R_Exception();
            GSM04000ActiveInactiveDTO loRtn = new GSM04000ActiveInactiveDTO();
            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;

                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<GSM04000ActiveInactiveDTO>(
                    _RequestServiceEndPoint,
                    nameof(IGSM04000.RSP_GS_ACTIVE_INACTIVE_DEPTMethod),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

        EndBlock:
            loEx.ThrowExceptionIfErrors();

        }

        #endregion
    }
}
