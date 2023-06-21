using LMM03700Common;
using LMM03700Common.DTO_s;
using LMM03700Model;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;

namespace LMM03700Front
{
    public partial class LMM03700 : R_Page
    {
        private LMM03700ViewModel _viewTCGModel = new();
        private LMM03710ViewModel _viewTCModel = new();

        private R_ConductorGrid _conT1_TCGRef; //conductor grid tenantclassgrp tab 1
        private R_ConductorGrid _conT2_TCGRef; //conductor grid tenantclassgrp tab 2
        private R_ConductorGrid _conTCRef; //conductor grid tenantclass tab 2
        private R_ConductorGrid _conTRef; //conductor grid tenant tab 2

        private R_Grid<TenantClassificationGroupDTO> _gridT1_TCGRef; //gridref  tenantclassgrp tab 1 
        private R_Grid<TenantClassificationGroupDTO> _gridT2_TCGRef; //gridref tenantclassgrp tab 2
        private R_Grid<TenantClassificationDTO> _gridTCRef; //gridref tenantclassgrp tab 2
        private R_Grid<TenantDTO> _gridTRef; //gridref tenantclassgrp tab 2

        private R_Popup R_PopupCheck;
        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await Property_ServiceGetListRecord(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }

        #region PropertyDropdown
        private async Task Property_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewTCGModel.GetPropertyList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }
        private async void DpOnchanged()
        {
            var loEx = new R_Exception();
            try
            {
                _viewTCModel._propertyId = _viewTCGModel._propertyId; //assign property_id as param grid
                await _gridT1_TCGRef.R_RefreshGrid(null); //refresh grid tab 1
                if (_viewTCModel._Tab2IsActive) //the status tab Tab2IsActive will true on changed tab
                {
                    await _gridT2_TCGRef.R_RefreshGrid(null);
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        #endregion

        #region TabSet
        private async Task ChangeTab(R_TabStripTab eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                switch (eventArgs.Id)
                {
                    case "TC":
                        _viewTCModel._Tab2IsActive = true;
                        break;
                        //case "TGC":
                        //    await _gridT1_TCGRef.R_RefreshGrid(null);
                        //    break;
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        #endregion

        #region Tab1-TenantClassificationGroup
        private async Task TCG_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _viewTCGModel.GetTenantClassGroupList();
                eventArgs.ListEntityResult = _viewTCGModel.TenantClassificationGroupList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }
        private async Task TCG_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationGroupDTO>(eventArgs.Data);
                await _viewTCGModel.GetTenantClassGroupRecord(loParam);
                eventArgs.Result = _viewTCGModel.TenantClassificationGroup;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task TCG_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationGroupDTO>(eventArgs.Data);
                await _viewTCGModel.DeleteTenantClassGroup(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task TCG_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationGroupDTO>(eventArgs.Data);
                await _viewTCGModel.SaveTenantClassGroup(loParam, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = _viewTCGModel.TenantClassificationGroup;
                await _gridT2_TCGRef.R_RefreshGrid(_viewTCModel._propertyId);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task TGC_Validation(R_ValidationEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loData = (TenantClassificationGroupDTO)eventArgs.Data;

                if (string.IsNullOrWhiteSpace(loData.CTENANT_CLASSIFICATION_GROUP_ID))
                    loEx.Add("", "Please fill Tenant Classification Group Id ");

                if (string.IsNullOrWhiteSpace(loData.CTENANT_CLASSIFICATION_GROUP_NAME))
                    loEx.Add("", "Please fill Tenant Classification Group Name ");
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            if (loEx.HasError)
                eventArgs.Cancel = true;

            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Tab2-TenantClassificationGrp
        private async Task T2_TCG_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _viewTCModel.GetTenantClassGroupList();
                eventArgs.ListEntityResult = _viewTCModel.TenantClassGrpList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }
        private async Task T2_TCG_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationGroupDTO>(eventArgs.Data);
                await _viewTCModel.GetTenantClassGroupRecord(loParam);
                eventArgs.Result = _viewTCModel.TenantClassiGrp;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task T2_TCG_ServiceDisplay(R_DisplayEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                _viewTCModel._tenantClassificationGroupId = loParam.CTENANT_CLASSIFICATION_GROUP_ID;
                await _gridTCRef.R_RefreshGrid(null);
                await _gridTRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
                throw;
            }
        }
        #endregion

        #region Tab2-TenantClassification
        private async Task T2_TC_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewTCModel.GetTenantClassList();
                eventArgs.ListEntityResult = _viewTCModel.TenantClassList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }
        private async Task T2_TC_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                await _viewTCModel.GetTenantClassRecord(loParam);
                eventArgs.Result = _viewTCModel.TenantClass;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task T2_TC_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                await _viewTCModel.DeleteTenantClass(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task T2_TC_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                await _viewTCModel.SaveTenantClass(loParam, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = _viewTCModel.TenantClass;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task T2_TC_ServiceDisplay(R_DisplayEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loEntity = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                _viewTCModel._tenantClassificationId = loEntity.CTENANT_CLASSIFICATION_ID;
                await _gridTRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Tab2-TenantList
        private async Task T2_T_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                //_viewTCModel._tenantClassificationId = (string)eventArgs.Parameter;
                await _viewTCModel.GetAssignedTenantList();
                eventArgs.ListEntityResult = _viewTCModel.AssignedTenantList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }
        private async Task T2_T_GetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                eventArgs.Result = R_FrontUtility.ConvertObjectToObject<TenantDTO>(_gridTRef.GetCurrentData);
                if (eventArgs.Result == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }
        #endregion

        #region Tab2-Assign Tenant
        private void R_Before_Open_PopupAssignTenant(R_BeforeOpenPopupEventArgs eventArgs)
        {
            var loParam = new TenantGridPopupDTO()
            {
                CPROPERTY_ID = _viewTCModel._propertyId,
                CTENANT_CLASSIFICATION_GROUP_ID = _viewTCModel._tenantClassificationGroupId,
                CTENANT_CLASSIFICATION_ID = _viewTCModel._tenantClassificationId
            };
            eventArgs.Parameter = loParam;
            eventArgs.TargetPageType = typeof(PopupAssignTenant);
        }
        private async Task R_After_Open_PopupAssignTenant(R_AfterOpenPopupEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loResult = (TenantGridPopupDTO)eventArgs.Result;
                if (loResult != null)
                {
                    await _viewTCModel.AssignTenantCategory(new List<TenantGridPopupDTO>() { loResult });
                    await _gridTRef.R_RefreshGrid(null);
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Tab2-Move Tenant

        private void R_Before_Open_Popup_MoveTenant(R_BeforeOpenPopupEventArgs eventArgs)
        {
            var loParam = new TenantGridPopupDTO()
            {
                CPROPERTY_ID = _viewTCModel._propertyId,
                CTENANT_CLASSIFICATION_GROUP_ID = _viewTCModel._tenantClassificationGroupId,
                CTENANT_CLASSIFICATION_ID = _viewTCModel._tenantClassificationId,
            };
            eventArgs.Parameter = loParam;
            eventArgs.TargetPageType = typeof(PopupMoveTenant);
        }
        private async Task R_After_Open_Popup_MoveTenant(R_AfterOpenPopupEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                //CARA 1
                //var loResult = (TenantGridPopupDTO)eventArgs.Result;
                //if (loResult != null)
                //{
                //    await _viewTCModel.MoveTenant(new List<string>() { loResult.CTENANT_ID });
                //    await _gridTCRef.R_RefreshGrid(null);
                //    await _gridTRef.R_RefreshGrid(null);
                //}

                //CARA 2 MOVETENANT DARI POPUP.CS
                await _gridTCRef.R_RefreshGrid(null);
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
