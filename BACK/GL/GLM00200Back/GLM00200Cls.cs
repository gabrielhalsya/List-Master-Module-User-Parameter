using GLM00200Common;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using System.Data.Common;
using System.Data;
using GLM00200Common.DTO_s;

namespace GLM00200Back
{
    public class GLM00200Cls : R_BusinessObject<JournalDTO>
    {
        protected override void R_Deleting(JournalDTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override JournalDTO R_Display(JournalDTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override void R_Saving(JournalDTO poNewEntity, eCRUDMode poCRUDMode)
        {
            throw new NotImplementedException();
        }

        public List<JournalGridDTO> GetRecurringList(RecurringJournalListParamDTO poParam)
        {
            R_Exception loEx = new R_Exception();
            List<JournalGridDTO> loRtn = null;
            R_Db loDB;
            DbConnection loConn;
            DbCommand loCmd;
            string lcQuery;
            try
            {
                loDB = new R_Db();
                loConn = loDB.GetConnection();
                loCmd = loDB.GetCommand();

                lcQuery = "RSP_GS_GET_DEPT_LIST";
                loCmd.CommandType = CommandType.StoredProcedure;
                loCmd.CommandText = lcQuery;

                //loDB.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                //loDB.R_AddCommandParameter(loCmd, "@CUSER_ID", DbType.String, 50, poParam.CUSER_LOGIN_ID);

                var loRtnTemp = loDB.SqlExecQuery(loConn, loCmd, true);
                loRtn = R_Utility.R_ConvertTo<JournalGridDTO>(loRtnTemp).ToList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
            return loRtn;

        }

        #region Init var
        public VAR_GSM_COMPANY GetVAR_GSM_COMPANY(INIT_VAR_DB_PARAM poParam)
        {

            R_Exception loException = new R_Exception();
            VAR_GSM_COMPANY loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT CCOGS_METHOD,LENABLE_CENTER_IS,LENABLE_CENTER_BS,LPRIMARY_ACCOUNT,CBASE_CURRENCY_CODE ,CLOCAL_CURRENCY_CODE FROM GSM_COMPANY (NOLOCK) WHERE CCOMPANY_ID = @CCOMPANY_ID";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_GSM_COMPANY>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;

        }
        public VAR_GL_SYSTEM_PARAM GetVAR_GL_SYSTEM_PARAM(INIT_VAR_DB_PARAM poParam)
        {

            R_Exception loException = new R_Exception();
            VAR_GL_SYSTEM_PARAM loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "EXEC RSP_GL_GET_SYSTEM_PARAM @CCOMPANY_ID,''";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_GL_SYSTEM_PARAM>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;

        }
        public VAR_CCURRENT_PERIOD_START_DATE GetCCURRENT_PERIOD_START_DATE(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            VAR_CCURRENT_PERIOD_START_DATE loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT CSTART_DATE FROM GSM_PERIOD_DT (NOLOCK) WHERE CCOMPANY_ID=@CCOMPANY_ID AND CCYEAR=@CCURRENT_PERIOD_YY AND CPERIOD_NO= @CCURRENT_PERIOD_MM";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                loDb.R_AddCommandParameter(loCmd, "@CCURRENT_PERIOD_YY", DbType.String, 50, poParam.CCURRENT_PERIOD_YY);
                loDb.R_AddCommandParameter(loCmd, "@CCURRENT_PERIOD_MM", DbType.String, 50, poParam.CCURRENT_PERIOD_MM);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_CCURRENT_PERIOD_START_DATE>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        public VAR_CSOFT_PERIOD_START_DATE GetCSOFT_PERIOD_START_DATE(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            VAR_CSOFT_PERIOD_START_DATE loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT CSTART_DATE FROM GSM_PERIOD_DT (NOLOCK) WHERE CCOMPANY_ID=@CCOMPANY_ID AND CCYEAR=@CCURRENT_PERIOD_YY AND CPERIOD_NO= @CCURRENT_PERIOD_MM";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                loDb.R_AddCommandParameter(loCmd, "@CSOFT_PERIOD_YY", DbType.String, 50, poParam.CSOFT_PERIOD_YY);
                loDb.R_AddCommandParameter(loCmd, "@CSOFT_PERIOD_MM", DbType.String, 50, poParam.CSOFT_PERIOD_MM);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_CSOFT_PERIOD_START_DATE>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        public VAR_IUNDO_COMMIT_JRN GetIUNDO_COMMIT_JRN(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            VAR_IUNDO_COMMIT_JRN loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT IOPTION FROM GLM_SYSTEM_ENABLE_OPTION (NOLOCK) WHERE CCOMPANY_ID=@CCOMPANY_ID AND COPTION_CODE='GL014001'";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_IUNDO_COMMIT_JRN>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        public VAR_GSM_TRANSACTION_CODE GetGSM_TRANSACTION_CODE(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            VAR_GSM_TRANSACTION_CODE loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT LINCREMENT_FLAG LAPPROVAL_FLAG FROM GSM_TRANSACTION_CODE (NOLOCK) WHERE CCOMPANY_ID = @CCOMPANY_ID AND CTRANSACTION_CODE='000000'";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_GSM_TRANSACTION_CODE>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        public VAR_GSM_PERIOD GetGSM_PERIOD(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            VAR_GSM_PERIOD loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT IMIN_YEAR=CAST(MIN(CYEAR) AS INT),IMAX_YEAR=CAST(MAX(CYEAR) AS INT) FROM GSM_PERIOD (NOLOCK) WHERE CCOMPANY_ID = @CCOMPANY_ID";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_GSM_PERIOD>(loRtnTemp).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        public List<VAR_STATUS_DTO> GetSTATUS_DTO(INIT_VAR_DB_PARAM poParam)
        {
            R_Exception loException = new R_Exception();
            List<VAR_STATUS_DTO> loResult = null;
            try
            {
                R_Db loDb = new R_Db();
                DbConnection loConn = loDb.GetConnection("R_DefaultConnectionString");
                string lcQuery = "SELECT IMIN_YEAR=CAST(MIN(CYEAR) AS INT),IMAX_YEAR=CAST(MAX(CYEAR) AS INT) FROM GSM_PERIOD (NOLOCK) WHERE CCOMPANY_ID = @CCOMPANY_ID";
                DbCommand loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 50, poParam.CCOMPANY_ID);
                var loRtnTemp = loDb.SqlExecQuery(loConn, loCmd, true);
                loResult = R_Utility.R_ConvertTo<VAR_STATUS_DTO>(loRtnTemp).ToList();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return loResult;
        }
        #endregion Init Var
    }
}
