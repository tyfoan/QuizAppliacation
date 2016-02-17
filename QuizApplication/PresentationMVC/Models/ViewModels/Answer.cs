using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVC.Models.ViewModels
{
    public class Answer
    {
        public Guid AnswerId { get; set; }
        public bool IsTrue { get; set; }
        public string ContentAnswer { get; set; }
        public string TrueAnswer { get; set; }
        public string StudentsAnswer { get; set; }
    }
}
