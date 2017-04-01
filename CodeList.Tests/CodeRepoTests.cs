using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeList.Models;

namespace CodeList.Tests
{
    [TestClass]
    public class CodeRepoTests
    {
        [TestCleanup]
        public void CleanUp()
        {
            CodeRepo t = new CodeRepo();
            t.DeleteAll();
        }

        [TestMethod]
        public void CodeRepoTests__Add__ItShouldWork()
        {
            //arrange
            CodeRepo t = new CodeRepo();
            Code r = getTestRecord();

            //act
            string id = t.Add(r);

            //assert
            Assert.IsTrue(t.RecordExists(id));
        }

        [TestMethod]
        public void CodeRepoTests__GetRecord__ItShouldWork()
        {
            //arrange
            CodeRepo t = new CodeRepo();
            Code r = getTestRecord();
            string id = t.Add(r);

            //act
            var r2 = t.GetRecord(id);

            //assert
            Assert.IsTrue(r2.Name == r.Name);
            Assert.IsTrue(r2.Program == r.Program);
            Assert.IsTrue(r2.Description == r.Description);
        }

        private static Code getTestRecord()
        {
            Code r = new Code();
            r.Name = "test";
            r.Description = "description goes here.";
            r.Program = "alert('hi');";
            return r;
        }

        [TestMethod]
        public void CodeRepoTests__Delete__ItShouldWork()
        {
            //arrange
            CodeRepo t = new CodeRepo();
            Code r = getTestRecord();
            string id = t.Add(r);

            //act
            t.Delete(id);

            //assert
            Assert.IsFalse(t.RecordExists(id));
        }

        [TestMethod]
        public void CodeRepoTests__Update__ItShouldWork()
        {
            //arrange
            CodeRepo t = new CodeRepo();
            Code r = getTestRecord();
            string id = t.Add(r);


            //act
            var r2 = t.GetRecord(id);
            r2.Name = "myChange";
            t.Update(r2);

            //assert
            var r3 = t.GetRecord(id);
            Assert.IsTrue(r2.Name == r3.Name);

        }

        [TestMethod]
        public void CodeRepoTests__GetAll__ItShouldWork()
        {
            //arrange
            CodeRepo t = new CodeRepo();

            for(int i=0; i<200; i++) { 
                Code r = getTestRecord();
                string id = t.Add(r);
            }

            //act
            var codeList = t.GetAll();

            //assert
            Assert.IsTrue(codeList.Count == 200);
        }


    }
}
