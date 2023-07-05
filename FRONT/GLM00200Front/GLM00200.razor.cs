using GLM00200Common;
using GLM00200Model;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;

namespace GLM00200Front
{
    public partial class GLM00200 : R_Page
    {
        private GLM00200ViewModel _journalVM = new GLM00200ViewModel();
        private R_Grid<JournalGridDTO> _gridJournal;
        private R_ConductorGrid _conJournal;

        private R_Grid<JournalDetailGridDTO> _gridJournalDet;
        private R_ConductorGrid _conJournalDet;

        protected override Task R_Init_From_Master(object poParameter)
        {
            return base.R_Init_From_Master(poParameter);
        }
        
        #region TAB Predefined
        private void Predef_RecurringEntry(R_InstantiateDockEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(RecurringEntry);
            eventArgs.Parameter = "RECURRING ENTRY";
        }

        private void AfterPredef_RecurringEntry(R_AfterOpenPredefinedDockEventArgs eventArgs)
        { }

        private void Predef_ActualJournalList(R_InstantiateDockEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(ActualJournalList);
            eventArgs.Parameter = "ACTUAL JOURNAL LIST";
        }

        private void AfterPredef_ActualJournalList(R_AfterOpenPredefinedDockEventArgs eventArgs)
        { }
        #endregion

        #region JournalGrid
        private async Task JournalGrid_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                await _journalVM.GetJournalList();
                eventArgs.ListEntityResult = _journalVM.JournalList;
                //if (eventArgs.ListEntityResult == null)
                //{
                //    R_PopupActiveInactive.Enabled = false;
                //    R_PopupAssignUser.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        private async Task JournalGrid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<JournalDTO>(eventArgs.Data);
                await _journalVM.GetJournal(loParam);
                eventArgs.Result = _journalVM.Journal;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task JournalGrid_Display(R_DisplayEventArgs eventArgs)
        {

        }
        #endregion

        #region JournalDetailGrid
        private async Task JournalDetGrid_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                //await _journalVM.GetJournalList();
                //eventArgs.ListEntityResult = _journalVM.JournalList;
                //if (eventArgs.ListEntityResult == null)
                //{
                //    R_PopupActiveInactive.Enabled = false;
                //    R_PopupAssignUser.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            R_DisplayException(loEx);
        }
        private async Task JournalDetGrid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                //var loParam = R_FrontUtility.ConvertObjectToObject<JournalDTO>(eventArgs.Data);
                //await _journalVM.GetJournal(loParam);
                //eventArgs.Result = _journalVM.Journal;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        private async Task JournalDetGrid_Display(R_DisplayEventArgs eventArgs)
        {

        }
        #endregion


    }
}
