﻿using R_BlazorFrontEnd.Controls;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Excel;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using GSM04000Common;
using GSM04000Model;
using R_BlazorFrontEnd.Helpers;
using R_BlazorFrontEnd;
using BlazorClientHelper;
using Lookup_GSCOMMON;
using Lookup_GSFRONT;
using Lookup_GSCOMMON.DTOs;
using R_BlazorFrontEnd.Controls.Grid.Columns;
using R_BlazorFrontEnd.Controls.MessageBox;
using System.Diagnostics.Tracing;

namespace GSM04000Front
{
    public partial class GSM04000 : R_Page
    {
        private GSM04000ViewModel _deptViewModel = new GSM04000ViewModel();
        private R_Grid<GSM04000DTO> _gridDeptRef;
        private R_ConductorGrid _conGridDeptRef;

        private GSM04100ViewModel _deptUserViewModel = new GSM04100ViewModel();
        private R_Grid<GSM04100StreamDTO> _gridDeptUserRef;
        private R_ConductorGrid _conGridDeptUserRef;

        [Inject] private R_IExcel _excelProvider { get; set; }
        [Inject] IClientHelper _clientHelper { get; set; }

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridDeptRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        #region Department(PARENT)
        private string loLabelActiveInactive = "";
        private R_Popup R_PopupCheck;
        private async Task DeptGrid_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _deptViewModel.GetDepartmentList();
                eventArgs.ListEntityResult = _deptViewModel.DepartmentList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        private async Task DeptGrid_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                var loParam = (GSM04000DTO)eventArgs.Data;

                var loDeptode = (GSM04100DTO)_conGridDeptUserRef.R_GetCurrentData();
                loDeptode.CDEPT_CODE = loParam.CDEPT_CODE;
                loDeptode.CDEPT_NAME = loParam.CDEPT_NAME;
                //set to viewmodel parent
                _deptViewModel.DepartmentCode = loParam.CDEPT_CODE;
                _deptViewModel.ActiveDept = loParam.LACTIVE;

                if (loParam.LACTIVE)
                {
                    loLabelActiveInactive = "Inactive";
                    _deptViewModel.ActiveDept = false;
                }
                else
                {
                    loLabelActiveInactive = "Activate";
                    _deptViewModel.ActiveDept = true;
                }


                //set to view model child
                _deptUserViewModel.DepartmentCode = loParam.CDEPT_CODE;
                if (loParam.LEVERYONE == true)
                {
                    R_PopupCheck.Enabled = false;
                }
                else
                {
                    R_PopupCheck.Enabled = true;
                }

                await _gridDeptUserRef.R_RefreshGrid(loParam);
            }

            if (eventArgs.ConductorMode == R_eConductorMode.Edit)
            {
                var loParam = (GSM04000DTO)eventArgs.Data;
                if (loParam.LEVERYONE!=true)
                {
                    await R_MessageBox.Show("Confirmation", "changing this will delete all assinged user on this dept", R_eMessageBoxButtonType.OKCancel);
                }
            }
        }
        private async Task DeptGrid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<GSM04000DTO>(eventArgs.Data);
                await _deptViewModel.GetDepartment(loParam);

                eventArgs.Result = _deptViewModel.Department;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task DeptGrid_Validation(R_ValidationEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loData = (GSM04000DTO)eventArgs.Data;

                await _deptViewModel.CheckIsUserDeptExist();
                if (_deptViewModel.IsUserDeptExist)
                {
                    R_MessageBox.Show("Delete Confirmation", "Changing Value Everyone will delete User for this Department", R_eMessageBoxButtonType.OKCancel);
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            if (loEx.HasError)
                eventArgs.Cancel = true;
            loEx.ThrowExceptionIfErrors();
        }
        private async Task DeptGrid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                
                R_MessageBox.Show("Confirm", "Change this will delete assigned user on this department", R_eMessageBoxButtonType.OKCancel);
                await _deptViewModel.SaveDepartment((GSM04000DTO)eventArgs.Data, (eCRUDMode)eventArgs.ConductorMode);
                eventArgs.Result = _deptViewModel.Department;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task DeptGrid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loData = (GSM04000DTO)eventArgs.Data;

                await _deptViewModel.DeleteDepartment(loData);
                await _gridDeptRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        //private async Task DeptGrid_OnChecked(R_SetEventArgs eventArgs)
        //{
        //    //var loParam = (GSM04000DTO)eventArgs.
        //    if (eventArgs.Enable)
        //    {
        //        R_MessageBox.Show("Confirm","Change this will delete assigned user on this department",R_eMessageBoxButtonType.OKCancel);
        //    }
        //}


        #endregion

        #region DepartmentUser(CHILD)
        private async Task DeptUserGrid_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<GSM04000DTO>(eventArgs.Parameter);
                _deptUserViewModel.DepartmentCode = loParam.CDEPT_CODE;
                await _deptUserViewModel.GetDepartmentListByDeptCode();
                eventArgs.ListEntityResult = _deptUserViewModel.DepartmentUserList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task DeptUserGrid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<GSM04100DTO>(eventArgs.Data);
                loParam.CDEPT_CODE = _deptUserViewModel.DepartmentCode;
                await _deptUserViewModel.GetDepartmentUser(loParam);
                eventArgs.Result = _deptUserViewModel.UserToAssign;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();

        }
        private async Task DeptUserGrid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loData = (GSM04100StreamDTO)eventArgs.Data;
                await _deptUserViewModel.DeleteUserDepartment(loData);
                await _gridDeptUserRef.R_RefreshGrid(loData);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Assign User
        private void R_Before_Open_PopupAssignUser(R_BeforeOpenPopupEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(GSM04000PopupAssignUser);
        }
        private async Task R_After_Open_PopupAssignUser(R_AfterOpenPopupEventArgs eventArgs)
        {
            var loTempResult = (GSM04100DTO)eventArgs.Result;
            var loDeptode = (GSM04100DTO)_conGridDeptUserRef.R_GetCurrentData();
            if (loTempResult == null)
            {
                return;
            }

            await _deptUserViewModel.AssignUserToDept(new GSM04100DTO()
            {
                CDEPT_CODE = loDeptode.CDEPT_CODE,
                CUSER_ID = loTempResult.CUSER_ID
            },
            eCRUDMode.AddMode);
            await _gridDeptUserRef.R_RefreshGrid(loDeptode);
        }
        #endregion

        #region Active/Inactive
        private void R_Before_Open_Popup_ActivateInactive(R_BeforeOpenPopupEventArgs eventArgs)
        {
            eventArgs.Parameter = "GSM04001";
            eventArgs.TargetPageType = typeof(GFF00900FRONT.GFF00900);
        }
        private async Task R_After_Open_Popup_ActivateInactive(R_AfterOpenPopupEventArgs eventArgs)
        {
            R_Exception loException = new R_Exception();
            try
            {
                bool result = (bool)eventArgs.Result;
                if (result == true)
                {
                    await _deptViewModel.ActiveInactiveProcessAsync();
                }
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            loException.ThrowExceptionIfErrors();
            await _gridDeptRef.R_RefreshGrid(null);
        }
        #endregion

        #region Upload
        private void R_Before_Open_PopupUpload(R_BeforeOpenPopupEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(GSM04000PopupUpload);
        }
        #endregion

        #region GridLookup
        //this think is wait till framerork fixed
        private R_GridLookupColumn LookupColumn;
        private void Dept_Before_Open_Lookup(R_BeforeOpenGridLookupColumnEventArgs eventArgs)
        {
            //eventArgs.ColumnName = "Name";
            var loParam = new GSL00900ParameterDTO();
            eventArgs.Parameter = loParam;
            eventArgs.TargetPageType = typeof(GSL00900);
        }
        private void Dept_After_Open_Lookup(R_AfterOpenGridLookupColumnEventArgs eventArgs)
        {
            var loTempResult = R_FrontUtility.ConvertObjectToObject<GSM04000DTO>(eventArgs.Result);
            ((GSM04000DTO)eventArgs.ColumnData).CCENTER_CODE = loTempResult.CCENTER_CODE;
            ((GSM04000DTO)eventArgs.ColumnData).CCENTER_NAME = loTempResult.CCENTER_NAME;
        }
        #endregion

        #region Template
        private async Task DownloadTemplateAsync()
        {
            var loEx = new R_Exception();
            try
            {
                var loDataTable = R_FrontUtility.R_ConvertTo(new List<GSM04000ExcelDTO>());
                loDataTable.TableName = "Department";

                //export to excel
                var loByteFile = _excelProvider.R_WriteToExcel(loDataTable);
                var saveFileName = $"{_clientHelper.CompanyId}.xlsx";

                await _jsClass.downloadFileFromStreamHandler(saveFileName, loByteFile);
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
