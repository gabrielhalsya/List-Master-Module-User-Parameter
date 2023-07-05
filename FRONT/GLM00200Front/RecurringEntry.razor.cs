using R_BlazorFrontEnd.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLM00200Front
{
    public partial class RecurringEntry : R_Page
    {
        public string Title { get; set; }
        protected override async Task R_Init_From_Master(object poParameter)
        {
            Title = (string)poParameter;
        }
    }
}
