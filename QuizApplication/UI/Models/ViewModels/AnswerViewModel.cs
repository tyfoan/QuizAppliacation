using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace UI.Models.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public bool IsTrue { get; set; }
        public string ContentAnswer { get; set; }
        public bool IsAnswered { get; set; }
        public List<Test> Tests { get; set; }
    }
}
