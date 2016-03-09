using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        [Required(ErrorMessage = "Необходимо ввести контент вопроса.")]
        [StringLength(350, ErrorMessage = "Необходимо ввести более 5 и меньше 350 символов.", MinimumLength = 5)]
        public string QuestionContent { get; set; }
        public AnswerVarian AnswerVariant { get; set; }
        public List<AnswerViewModel> Answers { get; set; }

        public int ChoosenAnswerGuid { get; set; }
        public List<Guid> ChoosenAnswerGuids { get; set; }
    }

    public enum AnswerVarian
    {
        One,
        MoreThanOne
    }
}
