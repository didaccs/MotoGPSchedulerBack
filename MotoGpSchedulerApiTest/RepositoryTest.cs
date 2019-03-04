using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotoGPSchedulerApi.Migrations;
using MotoGPSchedulerApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MotoGpSchedulerApiTest
{
    [TestClass]
    public class RepositoryTest : DatabaseTest
    {
        [TestMethod]
        public void GetAll_Records()
        {
            InitializeDatabase();
            List<Record> records = DbInitializer.GetRecords();

            List<Record> recordsResult = repoRecord.GetAll().ToList();

            Assert.AreEqual(recordsResult.Count, records.Count);
            Assert.AreEqual(recordsResult[0].Pilot, records[0].Pilot);
        }        
    }
}
