using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using UnitTestConsole;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(1, "NguyenVanA", 1.2, true, 1, DisplayName = "Teacher1")]
        [DataRow(2, "NguyenVanB", 1.3, false, 2, DisplayName = "Teacher2")]
        [DataRow(3, "NguyenVanC", 1.4, true, 3, DisplayName = "Teacher3")]
        [DataRow(4, "NguyenVanD", 1.5, false, 4, DisplayName = "Teacher4")]
        public void TestTeacherSalary(int id, string name, double factor, bool unionMember, int seniority)
        {
            Teacher teacher = new Teacher()
            {
                ID = id,
                Name = name,
                Factor = factor,
                UnionMember = unionMember,
                Seniority = seniority
            };

            double salary = factor * 1490;

            salary += 1490 * 0.25; // phu cap 25% luong co ban

            if (unionMember)
                salary -= salary * 0.01;

            salary += seniority * 1000;

            Assert.AreEqual(salary, teacher.GetSalary());
        }

        [TestMethod]
        [DataRow(5, "NguyenThiA", 1.2, true, 1, 1, DisplayName = "Reseacher1")]
        [DataRow(6, "NguyenThiB", 1.3, false, 2, 2, DisplayName = "Reseacher2")]
        [DataRow(7, "NguyenThiC", 1.4, true, 3, 3, DisplayName = "Reseacher3")]
        [DataRow(8, "NguyenThiD", 1.5, false, 4, 4, DisplayName = "Reseacher4")]
        public void TestReseacherSalary(int id, string name, double factor, bool unionMember, int numOfPaper, int paperRank)
        {
            Researcher researcher = new Researcher()
            {
                ID = id,
                Name = name,
                Factor = factor,
                UnionMember = unionMember,
                NumOfPaper = numOfPaper,
                PaperRank = paperRank
            };

            double salary = factor * 1490;

            if (unionMember)
                salary -= salary * 0.01;

            if(paperRank == 1)
                salary += numOfPaper * 10000;
            else if (paperRank == 2)
                salary += numOfPaper * 70000;
            else // paperRank == 3
                salary += numOfPaper * 50000;

            Assert.AreEqual(salary, researcher.GetSalary());
        }
    }
}