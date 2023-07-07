using GLM00200Back;
using GLM00200Common;
using GLM00200Common.DTO_s;
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
        [HttpPost]
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
        
        [HttpPost]
        private async IAsyncEnumerable<JournalGridDTO> JournalListStreamListHelper(List<JournalGridDTO> loRtnTemp)
        {
            foreach (JournalGridDTO loEntity in loRtnTemp)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public R_ServiceGetRecordResultDTO<JournalDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<JournalDTO> R_ServiceSave(R_ServiceSaveParameterDTO<JournalDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IAsyncEnumerable<JournalGridDTO> GetFilteredRecurringList()
        {
            throw new NotImplementedException();
        }

        //INIT DATA
        [HttpPost]
        public VAR_GL_SYSTEM_PARAM_DTO GetVAR_GL_SYSTEM_PARAM()
        {
            VAR_GL_SYSTEM_PARAM_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_GL_SYSTEM_PARAM_DTO();
                loRtn.data = loCls.GetVAR_GL_SYSTEM_PARAM(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public VAR_CCURRENT_PERIOD_START_DATE_DTO GetCCURRENT_PERIOD_START_DATE()
        {
            VAR_CCURRENT_PERIOD_START_DATE_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_CCURRENT_PERIOD_START_DATE_DTO();
                loRtn.data = loCls.GetCCURRENT_PERIOD_START_DATE(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                        CCURRENT_PERIOD_MM = R_Utility.R_GetContext<string>(RecurringJournalContext.CCURRENT_PERIOD_MM),
                        CCURRENT_PERIOD_YY = R_Utility.R_GetContext<string>(RecurringJournalContext.CCURRENT_PERIOD_YY),
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public VAR_CSOFT_PERIOD_START_DATE_DTO GetCSOFT_PERIOD_START_DATE()
        {
            VAR_CSOFT_PERIOD_START_DATE_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_CSOFT_PERIOD_START_DATE_DTO();
                loRtn.data = loCls.GetCSOFT_PERIOD_START_DATE(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                        CSOFT_PERIOD_YY = R_Utility.R_GetContext<string>(RecurringJournalContext.CSOFT_PERIOD_YY),
                        CSOFT_PERIOD_MM = R_Utility.R_GetContext<string>(RecurringJournalContext.CSOFT_PERIOD_MM),
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public VAR_IUNDO_COMMIT_JRN_DTO GetIUNDO_COMMIT_JRN()
        {
            VAR_IUNDO_COMMIT_JRN_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_IUNDO_COMMIT_JRN_DTO();
                loRtn.data = loCls.GetIUNDO_COMMIT_JRN(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public VAR_GSM_TRANSACTION_CODE_DTO GetGSM_TRANSACTION_CODE()
        {
            VAR_GSM_TRANSACTION_CODE_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_GSM_TRANSACTION_CODE_DTO();
                loRtn.data = loCls.GetGSM_TRANSACTION_CODE(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public VAR_GSM_PERIOD_DTO GetGSM_PERIOD()
        {
            VAR_GSM_PERIOD_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_GSM_PERIOD_DTO();
                loRtn.data = loCls.GetGSM_PERIOD(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public IAsyncEnumerable<VAR_STATUS_DTO> GetSTATUS_DTO()
        {
            R_Exception loException = new R_Exception();
            List<VAR_STATUS_DTO> loRtnTemp = null;
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls();
                loRtnTemp = loCls.GetSTATUS_DTO(new INIT_VAR_DB_PARAM()
                {
                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return StreamVAR_STATUS_DTOHelper(loRtnTemp);
        }

        [HttpPost]
        private async IAsyncEnumerable<VAR_STATUS_DTO> StreamVAR_STATUS_DTOHelper(List<VAR_STATUS_DTO> loRtnTemp)
        {
            foreach (VAR_STATUS_DTO loEntity in loRtnTemp)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public VAR_GSM_COMPANY_DTO GetVAR_GSM_COMPANY()
        {
            VAR_GSM_COMPANY_DTO loRtn = null;
            R_Exception loException = new R_Exception();
            GLM00200Cls loCls;
            try
            {
                loCls = new GLM00200Cls(); //create cls class instance
                loRtn = new VAR_GSM_COMPANY_DTO();
                loRtn.data = loCls.GetVAR_GSM_COMPANY(
                    new INIT_VAR_DB_PARAM()
                    {
                        CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID
                    });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }
    }
}