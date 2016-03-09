using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Необходимо ввести контент вопроса.")]
        [Display(Name = "Является ответом на вопрос")]
        public bool IsTrue { get; set; }
        [Required(ErrorMessage = "Необходимо ввести контент вопроса.")]
        [Display(Name = "Контент вопроса")]
        [StringLength(350, ErrorMessage = "Необходимо ввести более 5 и меньше 350 символов.", MinimumLength = 5)]
        public string ContentAnswer { get; set; }
        public bool IsAnswered { get; set; }
        public QuestionViewModel Tests { get; set; }
    }
}
