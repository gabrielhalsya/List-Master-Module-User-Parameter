using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;
using GSM04000Common;
using GSM04000Model;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Helpers;
using System;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd;
using Microsoft.AspNetCore.Components.Forms;
using R_BlazorFrontEnd.Controls.Enums;
using System.Collections.ObjectModel;
using R_BlazorFrontEnd.Controls.Grid;

namespace GSM04000Front
{
    public partial class GSM04000PopupUpload : R_Page
    {
        private GSM04000ViewModel _deptViewModel = new GSM04000ViewModel();
        private R_Grid<GSM04000DTO> _gridDeptExcelRef;
        private R_ConductorGrid _conGridDeptExcelRef;
        [Inject] private R_IExcel _excelProvider { get; set; }
        private R_eFileSelectAccept[] _accepts = { R_eFileSelectAccept.Excel };
        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridDeptExcelRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

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

        private async Task UploadExcel (InputFileChangeEventArgs eventArgs)
        {
            var loMS = new MemoryStream();
            await eventArgs.File.OpenReadStream().CopyToAsync(loMS);
            var loByteFile = loMS.ToArray();

            //import from excel
            var loDataSet = _excelProvider.R_ReadFromExcel(loByteFile);

            var resultEmployee = R_FrontUtility.R_ConvertTo<GSM04000DTO>(loDataSet.Tables[0]);
            ObservableCollection<GSM04000DTO> listEmployee = new ObservableCollection<GSM04000DTO>(resultEmployee);
            _deptViewModel.DepartmentExcelList = listEmployee;
        }

        private void R_RowRender(R_GridRowRenderEventArgs eventArgs)
        {
            var loData = (GSM04000DTO)eventArgs.Data;

            if (loData.LACTIVE)
            {
                eventArgs.RowStyle = new R_GridRowRenderStyle
                {
                    FontColor = "red"
                };
            }
        }
    }
}
