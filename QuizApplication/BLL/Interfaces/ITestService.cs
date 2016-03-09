using System.Collections;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        IEnumerable<TestDto> GetTests(int subjId);
        TestDto GetTest(int id);
        void AddTest(TestDto test);
        void DeleteTest(int id);
        void EditTest(TestDto test);
    }
}
