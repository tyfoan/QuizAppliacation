using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        [Display(Name = "Сложность теста")]        
        [Required(ErrorMessage = "Необходимо ввести контент вопроса.")]
        [StringLength(350, ErrorMessage = "Необходимо ввести более 5 и меньше 350 символов.", MinimumLength = 5)]
        public string QuestionContent { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public List<StudentAnswerDto> StudentAnswers { get; set; }
    }
}
