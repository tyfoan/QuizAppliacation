using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class TestDto
    {
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Введите название теста.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо выбрать сложность.")]
        [Display(Name = "Сложность теста")]
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        [Required(ErrorMessage = "Необходимо ввести длительность теста.")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "Поле не может быть отрицательным")]
        [Display(Name = "Длительность в минутах")]
        public int Duration { get; set; }
        public bool IsApproved { get; set; }

        public List<ThemeDto> Themes { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public List<TestPassDto> TestPasses { get; set; }
    }
}
