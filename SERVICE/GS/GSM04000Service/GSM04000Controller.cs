﻿using GSM04000Common;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using GSM04000Back;
using System.Drawing.Text;
using System.Xml.Linq;

namespace GSM04000Service
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GSM04000Controller : ControllerBase, IGSM04000
    {
        [HttpPost]
        public IAsyncEnumerable<GSM04000DTO> GetGSM04000List()
        {
            R_Exception loException = new R_Exception();
            List<GSM04000DTO> loRtnTemp= null;
            GSM04000ListDBParameterDTO loDbParam;
            GSM04000Cls loCls;
            try
            {                 
                loCls = new GSM04000Cls();
                loRtnTemp = loCls.GetList(new GSM04000ListDBParameterDTO()
                {
                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    CUSER_LOGIN_ID = R_BackGlobalVar.USER_ID
                });                
            }   
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return GSM0400StreamListHelper(loRtnTemp);
        }

        private async IAsyncEnumerable<GSM04000DTO> GSM0400StreamListHelper(List<GSM04000DTO> loRtnTemp)
        {
            foreach (GSM04000DTO loEntity in loRtnTemp)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM04000DTO> poParameter)
        {
            R_ServiceDeleteResultDTO loRtn = null;
            R_Exception loException = new R_Exception();
            GSM04000Cls loCls;
            try
            {
                loRtn = new R_ServiceDeleteResultDTO();
                loCls = new GSM04000Cls(); //create cls class instance
                poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                poParameter.Entity.CUSER_ID = R_BackGlobalVar.USER_ID;

                loCls.R_Delete(poParameter.Entity);
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
        public R_ServiceGetRecordResultDTO<GSM04000DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<GSM04000DTO> poParameter)
        {

            R_ServiceGetRecordResultDTO<GSM04000DTO> loRtn = null;
            R_Exception loException = new R_Exception();
            GSM04000Cls loCls;
            try
            {
                loCls = new GSM04000Cls(); //create cls class instance
                loRtn = new R_ServiceGetRecordResultDTO<GSM04000DTO>();
                poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                poParameter.Entity.CUSER_ID = R_BackGlobalVar.USER_ID;
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
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
        public R_ServiceSaveResultDTO<GSM04000DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM04000DTO> poParameter)
        {
            R_ServiceSaveResultDTO<GSM04000DTO> loRtn = null;
            R_Exception loException = new R_Exception();
            GSM04000Cls loCls;
            try
            {
                loCls = new GSM04000Cls();
                loRtn = new R_ServiceSaveResultDTO<GSM04000DTO>();
                poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                poParameter.Entity.CUSER_ID = R_BackGlobalVar.USER_ID;
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);//call clsMethod to save
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
        public GSM04000ActiveInactiveDTO RSP_GS_ACTIVE_INACTIVE_DEPTMethod()
        {
            R_Exception loEx = new R_Exception();
            GSM04000ActiveInactiveDTO loRtn = new GSM04000ActiveInactiveDTO();
            GSM04000ActiveInactiveParam loParam = new GSM04000ActiveInactiveParam();
            GSM04000Cls loCls = new GSM04000Cls();
            try
            {
                loParam.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                loParam.CDEPT_CODE = R_Utility.R_GetContext<string>(ContextConstant.CDEPT_CODE);
                loParam.LACTIVE = R_Utility.R_GetContext<bool>(ContextConstant.LACTIVE);
                loParam.CUSER_ID = R_BackGlobalVar.USER_ID;

                loCls.RSP_GS_ACTIVE_INACTIVE_DEPTMethodCls(loParam);

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]
        public GSM04000CheckUserExistResultDTO CheckIsUserDeptExist()
        {

            R_Exception loException = new R_Exception();
            GSM04000CheckUserExistResultDTO loRtn=null;
            GSM04000Cls loCls;
            GSM04000DTO loParameter = null;
            try
            {
                loCls = new GSM04000Cls(); //create cls class instance
                loRtn=new GSM04000CheckUserExistResultDTO();            
                loParameter = new GSM04000DTO();
                loParameter.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                loParameter.CDEPT_CODE = R_Utility.R_GetStreamingContext<string>(ContextConstant.CDEPT_CODE);
                loRtn.UserDeptExist = loCls.CheckIsUserDeptExist(loParameter);
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