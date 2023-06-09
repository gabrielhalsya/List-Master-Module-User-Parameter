using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMM03700Model;
using LMM03700Common.DTO_s;
using R_CommonFrontBackAPI;
using R_BlazorFrontEnd.Helpers;

namespace LMM03700Front
{
    public partial class PopupAssignTenant : R_Page
    {
        private LMM03710ViewModel _viewTCModel;
        private R_Grid<TenantToAssignDTO> _gridTenantRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridTenantRef.R_RefreshGrid(poParameter);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task GetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<TenantToAssignDTO>(eventArgs.Parameter);
                await _viewTCModel.GetTenantList(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }
        public async Task Process()
        {
            var loEx = new R_Exception();
            try
            {
                var loData = _gridTenantRef.GetCurrentData();
                //await _viewTCModel.
                //await _viewTCModel.GetTenantList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            await this.Close(true, null);
            R_DisplayException(loEx);
        }
        public async Task Cancel()
        {
            await this.Close(true, null);
        }
    }
}
