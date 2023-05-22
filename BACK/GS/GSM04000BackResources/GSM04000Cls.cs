using GSM04000Common;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSM04000Back
{
    public class GSM04000Cls : R_BusinessObject<GSM04000DTO>
    {
        protected override void R_Deleting(GSM04000DTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override GSM04000DTO R_Display(GSM04000DTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override void R_Saving(GSM04000DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            throw new NotImplementedException();
        }

        public List<GSM04000DTO> GetList(string CCOMPANY_ID, string CUSER_LOGIN_ID)
        {
            List<GSM04000DTO> loRtn = null;
            R_Exception loEx = new R_Exception();
            R_Db loDB;
            try
            {
                loDB = new R_Db();
                var loConn = loDB.GetConnection("R_DefaultConnectionString");
                var loCmd = loDB.GetCommand();
                var lcQuery = "EXEC RSP_GS_GET_DEPT_LIST @CCOMPANY_ID, @CUSER_LOGIN_ID";

                loDB.R_AddCommandParameter.

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
