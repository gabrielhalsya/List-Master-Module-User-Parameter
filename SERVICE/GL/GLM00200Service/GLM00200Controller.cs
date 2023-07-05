using GLM00200Back;
using GLM00200Common;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace GLM00200Service
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GLM00200Controller : ControllerBase, IGLM00200
    {
        public IAsyncEnumerable<JournalGridDTO> GetAllRecurringList()
        {
            R_Exception loException = new R_Exception();
            List<JournalGridDTO> loRtnTemp = null;
            RecurringJournalListParamDTO loDbParam;
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls();
                loRtnTemp = loCls.GetRecurringList(new RecurringJournalListParamDTO()
                {
                    //CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    //CUSER_LOGIN_ID = R_BackGlobalVar.USER_ID
                });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return JournalListStreamListHelper(loRtnTemp);
        }

        private async IAsyncEnumerable<JournalGridDTO> JournalListStreamListHelper(List<JournalGridDTO> loRtnTemp)
        {
            foreach (JournalGridDTO loEntity in loRtnTemp)
            {
                yield return loEntity;
            }
        }

        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        public R_ServiceGetRecordResultDTO<JournalDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        public R_ServiceSaveResultDTO<JournalDTO> R_ServiceSave(R_ServiceSaveParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<JournalGridDTO> GetFilteredRecurringList()
        {
            throw new NotImplementedException();
        }
    }
}