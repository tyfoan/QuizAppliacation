using Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        [Display(Name = "Название предмета")]
        [Required(ErrorMessage = "Необходимо ввести название предмета.")]
        public string Name { get; set; }
        [Display(Name = "Сложность предмета")]
        [Required(ErrorMessage = "Необходимо выбрать сложность.")]
        public Complexity Complexity { get; set; }
        //public Rate? Rate { get; set; }
        [Display(Name = "Количество вопросов")]
        public int TestAmount { get; set; }


        public List<TestViewModel> Tests { get; set; }
    }
}
