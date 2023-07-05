using GLM00200Common;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GLM00200Model
{
    public class GLM00200ViewModel : R_ViewModel<JournalGridDTO>
    {
        public GLM00200Model _model = new GLM00200Model();
        public ObservableCollection<JournalGridDTO> JournalList { get; set; } = new ObservableCollection<JournalGridDTO>();
        public ObservableCollection<JournalDetailGridDTO> JournaDetailList { get; set; } = new ObservableCollection<JournalDetailGridDTO>();
        public JournalDTO Journal { get; set; } = new JournalDTO();
        public RecurringJournalListParamDTO SearchParam { get; set; } = new RecurringJournalListParamDTO();


        public int Year { get; set; }
        public List<int> Period = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12};
        public List<string> Status = new List<string>() {"Draft","Submitted"};

        public async Task GetJournal(JournalDTO loParam)
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);
                Journal = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
        public async Task GetJournalList()
        {
            R_Exception loEx = new R_Exception();
            try
            {
                var loResult = new List<JournalGridDTO>();
                loResult = await _model.GetAllRecurringListAsync();
                JournalList = new ObservableCollection<JournalGridDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
    }
}
