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
        //public void MakeEvaluationForm(FormVM.MakeFormVM viewModel)
        //{
        //    //Hitta Id för vilken klass som skall ha utvärdering
        //    var educationId = context.Education
        //        .Where(o => o.Course.CourseName == viewModel.CourseName && o.Semester.SemesterName == viewModel.SemesterName)
        //        .Select(o => o.EducationId)
        //        .SingleOrDefault();

        //    //Kolla ifall formulär med educationId och EducationWeek redan finns
        //    var formId = context.Forms
        //        .Where(o => o.EducationId == educationId && o.EducationWeek == viewModel.EducationWeek)
        //        .Select(o => o.EducationId)
        //        .SingleOrDefault();

        //    //Om det inte finns ett formulär skapa en nytt formulär
        //    if (formId == 0)
        //    {
        //        //Spara formuläret
        //        var form = new Form();
        //        form.EducationId = educationId;
        //        form.EducationWeek = viewModel.EducationWeek;
        //        form.FormTypeId = 1;                
        //        context.Forms.Add(form);
        //        context.SaveChanges();

        //        //Hämta ut id för det skapade formuläret
        //        formId = context.Forms
        //            .Where(i => i == form)
        //            .Select(i => i.FormId)
        //            .SingleOrDefault();
        //    }

        //    //Skapa frågan
        //    var question = new FormQuestion();
        //    question.Question = viewModel.Question;
        //    context.FormQuestions.Add(question);
        //    context.SaveChanges();

        //    //Hämta ut id för frågan
        //    var questionId = context.FormQuestions
        //        .Where(i => i == question)
        //        .Select(i => i.QuestionId)
        //        .SingleOrDefault();

        //    //Skapa mellan tabellen mellan formulär och fråga
        //    var formToQuestion = new FormToQuestion();
        //    formToQuestion.FormId = formId;
        //    formToQuestion.QuestionId = questionId;
        //    context.FormToQuestions.Add(formToQuestion);
        //    context.SaveChanges();

        //    //Skapa flervalen till frågan
        //    foreach (var item in viewModel.Options)
        //    {
        //        var formOption = new FormOption();
        //        formOption.Option = item.Option;
        //        formOption.Score = item.Score;
        //        context.FormOptions.Add(formOption);
        //        context.SaveChanges();

        //        //Plocka ut id för valet
        //        var optionId = context.FormOptions
        //       .Where(h => h == formOption)
        //       .Select(h => h.OptionId)
        //       .SingleOrDefault();

        //        //Lägg till i mellantabellen mellan fråga och alternativ
        //        var formQuestionToOption = new FormQuestionToOption();
        //        formQuestionToOption.OptionId = optionId;
        //        formQuestionToOption.QuestionId = questionId;
        //    }

        //    var consultInEducationId = context.Consultant
        //       .Where(j => j.EducationId == educationId)
        //       .Select(j => new User
        //       {
        //           UserId = j.UserId
        //       })
        //       .ToList();

        //    //Skapa raderna i tabellen för konsulterna
        //    foreach (var item in consultInEducationId)
        //    {
        //        var formConsultAnswer = new FormConsultAnswer();
        //        formConsultAnswer.QuestionId = questionId;
        //        formConsultAnswer.UserId = item.UserId;
        //        context.FormConsultAnswers.Add(formConsultAnswer);
        //        context.SaveChanges();
        //    }
        //}

        public List<FormVM.CreateEvaluationVM> GetActivLocations()
        {
            var listLocations = context.Education
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now)
                .Select(o => new FormVM.CreateEvaluationVM
                {
                    City = o.Location.City
                })
                .ToList();
            
            return listLocations;
        }

        public List<FormVM.CreateEvaluationVM> GetActivCourses(string location)
        {
            var listOfCourses = context.Education
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now && o.Location.City == location)
                .Select(o => new FormVM.CreateEvaluationVM
                {
                    Course = o.Course.CourseName
                })
                .ToList();

            return listOfCourses;
        }

        public List<FormVM.EvaluationFormVM> CreateForm(FormVM.MakeFormVM viewModel)
        {
            //Plocka ut educationId för vald kurs
            var educationId = context.Education
                .Where(o => o.StartDate >= DateTime.Now && o.EndDate <= DateTime.Now && o.Location.City == viewModel.City && o.Course.CourseName == viewModel.CourseName)
                .Select(o => o.EducationId)
                .SingleOrDefault();

            //Kolla ifall formulär med educationId och EducationWeek redan finns
            var formId = context.Forms
                .Where(o => o.EducationId == educationId && o.EducationWeek == viewModel.EducationWeek)
                .Select(o => o.EducationId)
                .SingleOrDefault();

            //Om det inte finns ett formulär skapa en nytt formulär
            if (formId == 0)
            {
                //Spara formuläret
                var form = new Form();
                form.EducationId = educationId;
                form.EducationWeek = viewModel.EducationWeek;
                form.FormTypeId = 1;
                context.Forms.Add(form);
                context.SaveChanges();

                //Hämta ut id för det skapade formuläret
                formId = context.Forms
                    .Where(i => i == form)
                    .Select(i => i.FormId)
                    .SingleOrDefault();

                return ShowEvaluationForm(formId);
            }
            else
            {
                return ShowEvaluationForm(formId);
            }
        }

        public List<FormVM.EvaluationFormVM> ShowEvaluationForm(int formId)
        {
            //Hämta frågorna som finns för detta formId
            var questionFromDB = context.FormToQuestions
                .Where(o => o.FormId == formId)
                .OrderBy(o => o.FormQuestion.QuestionId)
                .Select(o => new FormVM.EvaluationFormVM
                {
                    Question = o.FormQuestion.Question,
                    QuestionId = o.FormQuestion.QuestionId
                })
                .ToList();

            var takeOptionFromDB = new List<FormVM.EvaluationFormVM>();

            //Hämta flervalen som finns till detta formId
            foreach (var item in questionFromDB)
            {
                var options = context.FormQuestionToOptions.Where(o => o.QuestionId == item.QuestionId).ToList()
                    .OrderByDescending(o => o.FormOption.Score)
                    .Select(o => new FormOption
                    {
                        OptionId = o.FormOption.OptionId,
                        Option = o.FormOption.Option,
                        Score = o.FormOption.Score
                    }).ToList();

                var makeForm = new FormVM.EvaluationFormVM()
                {
                    Question = item.Question,
                    Options = options
                };

                takeOptionFromDB.Add(makeForm);

            }
            return takeOptionFromDB;
        }

        //Skapa tentaformulär
        //public void MakeExamForm(MakeFormVM viewModel)
        //{

        //}
    }
}


////Hitta Id för vilken klass som skall ha utvärdering
//var educationId = context.Education
//    .Where(o => o.Course.CourseName == viewModel.CourseName && o.Semester.SemesterName == viewModel.SemesterName)
//    .Select(o => o.EducationId)
//    .SingleOrDefault();

////Hitta formuläret med educationId och EducationWeek
//var formId = context.Forms
//    .Where(o => o.EducationId == educationId && o.EducationWeek == viewModel.EducationWeek)
//    .Select(o => o.EducationId)
//    .SingleOrDefault();



//takeOptionFromDB.AddRange(context.FormQuestionToOptions
//.Where(o => o.QuestionId == item.QuestionId)
//.Select(o => new MakeFormVM
//{
//    Option = o.FormOption.Option,
//    FormQuestionToOptionId = o.FormQuestionToOption.FormQuestionToOptionId
//})
//.ToList());


