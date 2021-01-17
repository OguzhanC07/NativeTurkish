using NativeTurkish.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.ApiServices.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionListModel>> GetAllQuestions();
        Task<QuestionListModel> GetQuestionByIdAsync(string id);
        Task AddAsync(QuestionAddModel model);
        Task UpdateAsync(QuestionListModel model);
        Task DeleteAsync(string id);

    }
}
