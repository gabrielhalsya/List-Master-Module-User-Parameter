using R_BlazorFrontEnd.Controls;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using GSM04000Common;
using GSM04000Model;
using R_BlazorFrontEnd.Helpers;

namespace GSM04000Front
{
    public partial class GSM04000Popup : R_Page
    {
        private GSM04100ViewModel _deptUserToAssignViewModel = new GSM04100ViewModel();
        private R_Grid<GSM04100DTO> _gridDeptUserToAssignRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridDeptUserToAssignRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task R_ServiceGetListRecordAsync(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _deptUserToAssignViewModel.GetUserToAssignList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }
        public async Task Button_OnClickOkAsync()
        {
            var loData = _gridDeptUserToAssignRef.GetCurrentData();
            await this.Close(true, loData);
        }
        public async Task Button_OnClickCloseAsync()
        {
            await this.Close(true, null);
        }

    }
}

