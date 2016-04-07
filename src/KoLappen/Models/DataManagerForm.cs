using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public class DataManagerForm
    {
        DBContext context;

        public DataManagerForm(DBContext context)
        {
            this.context = context;
        }
        
        //Skapa utvärderingformulär
        public /*List<MakeFormVM>*/ void MakeEvaluationForm(MakeFormVM makeEvaluationForm)
        {

            //return evaluationForm;
        }

        //Skapa tentaformulär
        public void MakeExamForm(MakeFormVM viewModel)
        {
           
        }
    }
}
