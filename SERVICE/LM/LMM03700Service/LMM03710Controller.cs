using LMM03700Back;
using LMM03700Common;
using LMM03700Common.DTO_s;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace LMM03700Service
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LMM03710Controller : ControllerBase, ILMM03710
    {
        [HttpPost]
        public IAsyncEnumerable<TenantDTO> GetAssignedTenantList()
        {
            R_Exception loException = new R_Exception();
            List<TenantDTO> loRtnTemp = null;
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls();
                loRtnTemp = loCls.GetAssignedTenantList(new TenantClassificationDBListMaintainParamDTO()
                {

                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID),
                    CTENANT_CLASSIFICATION_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID),
                    CUSER_ID = R_BackGlobalVar.USER_ID,
                });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return TenantAssignedStreamHelper(loRtnTemp);
        }
        private async IAsyncEnumerable<TenantDTO> TenantAssignedStreamHelper(List<TenantDTO> poList)
        {
            foreach (TenantDTO loEntity in poList)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public IAsyncEnumerable<TenantClassificationDTO> GetTenantClassificationList()
        {
            R_Exception loException = new R_Exception();
            List<TenantClassificationDTO> loRtnTemp = null;
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls();
                loRtnTemp = loCls.GetTCList(new TenantClassificationDBListMaintainParamDTO()
                {
                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    CTENANT_CLASSIFICATION_GROUP_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID),
                    CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID),
                    CUSER_ID = R_BackGlobalVar.USER_ID
                });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return TCStreamListHelper(loRtnTemp);
        }
        private async IAsyncEnumerable<TenantClassificationDTO> TCStreamListHelper(List<TenantClassificationDTO> poList)
        {
            foreach (TenantClassificationDTO loEntity in poList)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<TenantClassificationDTO> poParameter)
        {
            R_ServiceDeleteResultDTO loRtn = null;
            R_Exception loException = new R_Exception();
            LMM03710Cls loCls;
            try
            {
                loRtn = new R_ServiceDeleteResultDTO();
                loCls = new LMM03710Cls(); //create cls class instance
                //poParameter.Entity.CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID);
                //poParameter.Entity.CTENANT_CLASSIFICATION_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID);
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
        public R_ServiceGetRecordResultDTO<TenantClassificationDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<TenantClassificationDTO> poParameter)
        {
            R_ServiceGetRecordResultDTO<TenantClassificationDTO> loRtn = null;
            R_Exception loException = new R_Exception();
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls(); //create cls class instance
                poParameter.Entity.CUSER_ID = R_BackGlobalVar.USER_ID;
                //poParameter.Entity.CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID);
                //poParameter.Entity.CTENANT_CLASSIFICATION_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID);
                //poParameter.Entity.CTENANT_CLASSIFICATION_GROUP_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID);
                loRtn = new R_ServiceGetRecordResultDTO<TenantClassificationDTO>();
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
        public R_ServiceSaveResultDTO<TenantClassificationDTO> R_ServiceSave(R_ServiceSaveParameterDTO<TenantClassificationDTO> poParameter)
        {
            R_ServiceSaveResultDTO<TenantClassificationDTO> loRtn = null;
            R_Exception loException = new R_Exception();
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls();
                loRtn = new R_ServiceSaveResultDTO<TenantClassificationDTO>();
                poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                poParameter.Entity.CUSER_ID = R_BackGlobalVar.USER_ID;
                poParameter.Entity.CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID);
                poParameter.Entity.CTENANT_CLASSIFICATION_GROUP_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID);
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
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
        public IAsyncEnumerable<TenantToAssignDTO> GetTenantList()
        {
            R_Exception loException = new R_Exception();
            List<TenantToAssignDTO> loRtnTemp = null;
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls();
                loRtnTemp = loCls.GetTenantList(new TenantClassificationDBListMaintainParamDTO()
                {
                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    CTENANT_CLASSIFICATION_GROUP_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID),
                    CTENANT_CLASSIFICATION_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID),
                    CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID),
                    CUSER_ID = R_BackGlobalVar.USER_ID
                });
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return TenantStreamHelper(loRtnTemp);
        }

        private async IAsyncEnumerable<TenantToAssignDTO> TenantStreamHelper(List<TenantToAssignDTO> poList)
        {
            foreach (TenantToAssignDTO loEntity in poList)
            {
                yield return loEntity;
            }
        }

        [HttpPost]
        public AssignTenantResultDTO AssignTenant()
        {
            AssignTenantResultDTO loRtn= null;
            R_Exception loException = new R_Exception();
            LMM03710Cls loCls;
            try
            {
                loCls = new LMM03710Cls();
                loRtn = new AssignTenantResultDTO();
                loRtn= loCls.AssignTenant(new AssignTenantDBParamDTO()
                {
                    CPROPERTY_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CPROPERTY_ID),
                    CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID,
                    CUSER_ID = R_BackGlobalVar.USER_ID,
                    CTENANT_CLASSIFICATION_GROUP_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID),
                    CTENANT_CLASSIFICATION_ID = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID),
                    CTENANTID_LIST = R_Utility.R_GetStreamingContext<string>(LMM03700ContextConstant.CTENANTIDLIST)
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
