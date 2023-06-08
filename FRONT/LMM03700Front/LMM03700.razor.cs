using LMM03700Common;
using LMM03700Common.DTO_s;
using LMM03700Model;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.Grid.Columns;
using R_BlazorFrontEnd.Controls.Menu.Tab;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;

namespace LMM03700Front
{
    public partial class LMM03700 : R_Page
    {
        private LMM03700ViewModel _viewTCGModel = new();
        private LMM03710ViewModel _viewTCModel = new();

        private R_ConductorGrid _conT1_TCGRef;
        private R_Conductor _conT2_TCGRef;
        private R_ConductorGrid _conTCRef;
        private R_ConductorGrid _conTRef;

        private R_Grid<TenantClassificationGroupDTO> _gridT1_TCGRef;
        private R_Grid<TenantClassificationGroupDTO> _gridT2_TCGRef;
        private R_Grid<TenantClassificationDTO> _gridTCRef;
        private R_Grid<TenantDTO> _gridTRef;

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
                _viewTCModel._propertyId = _viewTCGModel._propertyId;
                await _gridT1_TCGRef.R_RefreshGrid(null);
                await _gridT2_TCGRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        #endregion

        #region Tab
        private async Task ChangeTab(R_TabStripTab eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                if (eventArgs.Id == "TC")
                {
                    await _gridT2_TCGRef.R_RefreshGrid(null);
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
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
                eventArgs.ListEntityResult = _viewTCModel.TenantClassificationGroupList;
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
                eventArgs.Result = _viewTCModel.TenantClassificationGroup;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task T2_TGC_Display(R_DisplayEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                _viewTCModel._tenantClassificationGroupId = loParam.CTENANT_CLASSIFICATION_GROUP_ID;
                await _gridTCRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
                throw;
            }
        }
        #endregion

        #region Tab2-TenantClassification
        private async Task TC_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _viewTCModel.GetTenantClassList();
                eventArgs.ListEntityResult = _viewTCModel.TenantClassificationList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);

        }
        private async Task TC_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                await _viewTCModel.GetTenantClassRecord(loParam);
                eventArgs.Result = _viewTCModel.TenantClassification;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task TC_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
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
        private async Task TC_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantClassificationDTO>(eventArgs.Data);
                await _viewTCModel.SaveTenantClass(loParam, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = _viewTCGModel.TenantClassificationGroup;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        #endregion

        #region Tab2-TenantList
        private async Task T_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
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
        #endregion
    }

}
