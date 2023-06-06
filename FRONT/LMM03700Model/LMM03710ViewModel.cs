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
        public ObservableCollection<TenantClassificationDTO> TenantClassificationList { get; set; } = new ObservableCollection<TenantClassificationDTO>();
        public TenantClassificationDTO TenantClassification { get; set; } = new TenantClassificationDTO();

        public List<PropertyDTO> PropertyList { get; set; } = new List<PropertyDTO>();
        public List<TenantDTO> TenantList{ get; set; } = new List<TenantDTO>();

        public PropertyDTO Propertiy { get; set; } = new PropertyDTO();
        public string _propertyId = "";
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
                TenantClassificationList = new ObservableCollection<TenantClassificationDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        public async Task GetTenantClassGroupRecord(TenantClassificationDTO loParam)
        {
            loParam.CPROPERTY_ID= _propertyId;
            loParam.CTENANT_CLASSIFICATION_GROUP_ID = _tenantClassificationGroupId;
            var loResult = await _model.R_ServiceGetRecordAsync(loParam);
            TenantClassification= R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(loResult);
        }
        public async Task SaveTenantClassGroup(TenantClassificationDTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();
            try
            {
                poNewEntity.CPROPERTY_ID = _propertyId;
                poNewEntity.CTENANT_CLASSIFICATION_GROUP_ID= _tenantClassificationGroupId;
                var loResult = await _model.R_ServiceSaveAsync(poNewEntity, peCRUDMode);
                TenantClassification = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        public async Task DeleteTenantClassGroup(TenantClassificationDTO loParam)
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

        #region Tenant
        public async Task GetAssignedTenantList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CPROPERTY_ID, _propertyId);
                R_FrontContext.R_SetStreamingContext(LMM03700ContextConstant.CTENANT_CLASSIFICATION_ID, _tenantClassificationId);
                var loResult = await _model.GetAssignedTenantListAsync();
                TenantList = new List<TenantDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #endregion
    }
}
