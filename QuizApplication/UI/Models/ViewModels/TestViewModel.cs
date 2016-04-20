using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace UI.Models.ViewModels
{
    public class TestViewModel
    {   
        public int TestId { get; set; }
        [Required(ErrorMessage = "Введите название теста.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо выбрать сложность.")]
        [Display(Name = "Сложность теста")]
        public Complexity Complexity { get; set; }
        //public Rate? Rate { get; set; }
        [Required(ErrorMessage = "Необходимо ввести длительность теста.")]
        [Range(5, 180, ErrorMessage = "Минимальная длительность 5 мин. Максимальная 180")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "Поле не может быть отрицательным или 0")]
        [Display(Name = "Длительность (мин.)")]
        public int Duration { get; set; }

        //public bool IsApproved { get; set; }  //юзер с ролью преподователь отправляет заявку на 
        //подтверждение администратору об публикации теста на сайте.

        public int SubjectId { get; set; }

        public List<SubjectViewModel> Subjects { get; set; }
        public List<ThemeViewModel> Themes { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public List<TestPassViewModel> TestPasses { get; set; }

    }
}
