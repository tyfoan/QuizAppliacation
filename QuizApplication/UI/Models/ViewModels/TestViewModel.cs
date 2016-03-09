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
    {   //TODO: attributes
        public int TestId { get; set; }

        public string Name { get; set; }
        public Complexity Complexity { get; set; }
        public Rate? Rate { get; set; }
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "Поле не может быть отрицательным")]
        public int Duration { get; set; }
        public bool IsApproved { get; set; }  //юзер с ролью преподователь отправляет заявку на 
                                               //подтверждение администратору об публикации теста на сайте.
        public int SubjectId { get; set; }

        public List<SubjectViewModel> Subjects { get; set; }
        public List<ThemeViewModel> Themes { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public List<TestPassViewModel> TestPasses { get; set; }

    }
}
