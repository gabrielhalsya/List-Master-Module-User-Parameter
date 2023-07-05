using GLM00200Common;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using System.Data.Common;
using System.Data;

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
    }
}