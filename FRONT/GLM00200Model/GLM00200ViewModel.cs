using GLM00200Common;
using GLM00200Common.DTO_s;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GLM00200Model
{
    public class GLM00200ViewModel : R_ViewModel<JournalGridDTO>
    {
        public GLM00200Model _model = new GLM00200Model();
        public ObservableCollection<JournalGridDTO> JournalList { get; set; } = new ObservableCollection<JournalGridDTO>();
        public ObservableCollection<JournalDetailGridDTO> JournaDetailList { get; set; } = new ObservableCollection<JournalDetailGridDTO>();
        public JournalDTO Journal { get; set; } = new JournalDTO();
        public RecurringJournalListParamDTO _SearchParam { get; set; } = new RecurringJournalListParamDTO();
        public VAR_CCURRENT_PERIOD_START_DATE _CCURRENT_PERIOD_START_DATE { get; set; } = new VAR_CCURRENT_PERIOD_START_DATE();
        public VAR_CSOFT_PERIOD_START_DATE _CSOFT_PERIOD_START_DATE { get; set; } = new VAR_CSOFT_PERIOD_START_DATE();
        public VAR_GL_SYSTEM_PARAM _GL_SYSTEM_PARAM { get; set; } = new VAR_GL_SYSTEM_PARAM();
        public VAR_GSM_COMPANY _GSM_COMPANY { get; set; } = new VAR_GSM_COMPANY();
        public VAR_GSM_PERIOD _GSM_PERIOD { get; set; } = new VAR_GSM_PERIOD();
        public VAR_GSM_TRANSACTION_CODE _GSM_TRANSACTION_CODE { get; set; } = new VAR_GSM_TRANSACTION_CODE();
        public VAR_IUNDO_COMMIT_JRN _IUNDO_COMMIT_JRN { get; set; } = new VAR_IUNDO_COMMIT_JRN();
        public List<VAR_STATUS_DTO> _STATUS_LIST { get; set; } =new List<VAR_STATUS_DTO>();


        public List<string> Period = new List<string>() { "01","02","03","04","05","06","07","08","09","10","11","12"};
        public async Task GetJournal(JournalDTO loParam)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);
                Journal = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetJournalList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loResult = new List<JournalGridDTO>();
                loResult = await _model.GetAllRecurringListAsync();
                JournalList = new ObservableCollection<JournalGridDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCCURRENT_PERIOD_START_DATEAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetContext(RecurringJournalContext.CCURRENT_PERIOD_YY, _GL_SYSTEM_PARAM.CCURRENT_PERIOD_YY);
                R_FrontContext.R_SetContext(RecurringJournalContext.CCURRENT_PERIOD_MM, _GL_SYSTEM_PARAM.CCURRENT_PERIOD_MM);
                var rtnTemp= await _model.GetCCURRENT_PERIOD_START_DATEAsync();
                _CCURRENT_PERIOD_START_DATE = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCSOFT_PERIOD_START_DATEAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetContext(RecurringJournalContext.CSOFT_PERIOD_MM, _GL_SYSTEM_PARAM.CSOFT_PERIOD_MM);
                R_FrontContext.R_SetContext(RecurringJournalContext.CSOFT_PERIOD_YY, _GL_SYSTEM_PARAM.CSOFT_PERIOD_YY);
                var rtnTemp = await _model.GetCSOFT_PERIOD_START_DATEAsync();
                _CSOFT_PERIOD_START_DATE = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetVAR_GL_SYSTEM_PARAMAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetVAR_GL_SYSTEM_PARAMAsync();
                _GL_SYSTEM_PARAM = rtnTemp.data;
                _SearchParam.CPERIOD_MM = _GL_SYSTEM_PARAM.CSOFT_PERIOD_MM;
                _SearchParam.CPERIOD_YYYY = int.Parse(_GL_SYSTEM_PARAM.CSOFT_PERIOD_YY);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetVAR_GSM_COMPANY_DTOAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetVAR_GSM_COMPANY_DTOAsync();
                _GSM_COMPANY = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetGSM_PERIODAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetGSM_PERIODAsync();
                _GSM_PERIOD = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetGSM_TRANSACTION_CODEAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetGSM_TRANSACTION_CODEAsync();
                _GSM_TRANSACTION_CODE = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetIUNDO_COMMIT_JRNAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetIUNDO_COMMIT_JRNAsync();
                _IUNDO_COMMIT_JRN = rtnTemp.data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetSTATUS_DTOAsync()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var rtnTemp = await _model.GetSTATUS_DTOAsync();
                _STATUS_LIST = new List<VAR_STATUS_DTO>(rtnTemp);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
    }
}
