using LMM03700Common;
using LMM03700Common.DTO_s;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LMM03700Model
{
    public class LMM03710ViewModel : R_ViewModel<TenantClassificationDTO>
    {
        private LMM03710Model _model = new LMM03710Model();
        private LMM03700Model _modelTenantClassGrp = new LMM03700Model();
        public ObservableCollection<TenantClassificationGroupDTO> TenantClassGrpList { get; set; } = new ObservableCollection<TenantClassificationGroupDTO>();
        public ObservableCollection<TenantClassificationDTO> TenantClassList { get; set; } = new ObservableCollection<TenantClassificationDTO>();
        public ObservableCollection<TenantDTO> AssignedTenantList { get; set; } = new ObservableCollection<TenantDTO>();
        public ObservableCollection<TenantToAssignDTO> TenantList { get; set; } = new ObservableCollection<TenantToAssignDTO>();
        public TenantClassificationGroupDTO TenantClassiGrp { get; set; } = new TenantClassificationGroupDTO();
        public TenantClassificationDTO TenantClass { get; set; } = new TenantClassificationDTO();

        public string _propertyId { get; set; } = "";
        public bool _Tab2IsActive { get; set; } = false;
        public string _tenantClassificationId = "";
        public string _tenantClassificationGroupId = "";

        #region TenantClassificaiton
        public async Task GetTenantClassList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CPROPERTY_ID, _propertyId);
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID, _tenantClassificationGroupId);
                var loResult = await _model.GetTenantClassificationListAsync();
                TenantClassList = new ObservableCollection<TenantClassificationDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        public async Task GetTenantClassRecord(TenantClassificationDTO loParam)
        {
            loParam.CPROPERTY_ID = _propertyId;
            loParam.CTENANT_CLASSIFICATION_GROUP_ID = _tenantClassificationGroupId;
            var loResult = await _model.R_ServiceGetRecordAsync(loParam);
            TenantClass = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(loResult);
        }
        public async Task SaveTenantClass(TenantClassificationDTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();
            try
            {
                poNewEntity.CPROPERTY_ID = _propertyId;
                poNewEntity.CTENANT_CLASSIFICATION_GROUP_ID = _tenantClassificationGroupId;
                var loResult = await _model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);
                TenantClass = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        public async Task DeleteTenantClass(TenantClassificationDTO loParam)
        {
            var loEx = new R_Exception();

            try
            {
                loParam.CPROPERTY_ID = _propertyId;
                loParam.CTENANT_CLASSIFICATION_GROUP_ID = _tenantClassificationGroupId;
                await _model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region TenantClassGroup
        public async Task GetTenantClassGroupList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CPROPERTY_ID, _propertyId);
                var loResult = await _modelTenantClassGrp.GetUserParamListAsync();
                TenantClassGrpList = new ObservableCollection<TenantClassificationGroupDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetTenantClassGroupRecord(TenantClassificationGroupDTO loParam)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                loParam.CPROPERTY_ID = _propertyId;
                var loResult = await _modelTenantClassGrp.R_ServiceGetRecordAsync(loParam);
                TenantClassiGrp = R_FrontUtility.ConvertObjectToObject<TenantClassificationGroupDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Tenant
        public async Task GetAssignedTenantList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CPROPERTY_ID, _propertyId);
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID, _tenantClassificationId);
                var loResult = await _model.GetAssignedTenantListAsync();
                AssignedTenantList = new ObservableCollection<TenantDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetTenantList(TenantToAssignDTO poParam)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CPROPERTY_ID, poParam.CPROPERTY_ID);
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID, poParam.CTENANT_CLASSIFICATION_ID);
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CTENANT_CLASSIFICATION_GROUP_ID, poParam.CTENANT_CLASSIFICATION_GROUP_ID);
                var loResult = await _model.GetTenantListAsync();
                TenantList = new ObservableCollection<TenantToAssignDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveMoveTenantCategory()
        {
            R_Exception loException = new R_Exception();
            var loTenantList = new List<TenantForMove>();
            string lcTenantId = "";
            try
            {
                foreach (TenantForMove item in loTenantList)
                {
                    if (item.LCHECKED == true)
                    {
                        lcTenantId += "(" + item + "), ";
                    }
                }

                if (!string.IsNullOrEmpty(lcTenantId))
                {
                    lcTenantId = lcTenantId.Substring(0, lcTenantId.Length - 2); // Remove the last comma and space
                }

                //R_FrontContext.R_SetContext(ContextConstant.LMM03001_TENANT_ID_CONTEXT, lcTenantId);
                //R_FrontContext.R_SetContext(ContextConstant.LMM03001_PROPERTY_ID_CONTEXT, loProperty.CPROPERTY_ID);
                //R_FrontContext.R_SetContext(ContextConstant.LMM03001_FROM_TENANT_CATEGORY_ID_CONTEXT, loFromTenantCategory.CTENANT_CATEGORY_ID);
                //R_FrontContext.R_SetContext(ContextConstant.LMM03001_TO_TENANT_CATEGORY_ID_CONTEXT, loToTenantCategory.CTENANT_CATEGORY_ID);
                //await loModel.SaveMoveTenantCategoryAsync();
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
        }
        #endregion
    }
}
