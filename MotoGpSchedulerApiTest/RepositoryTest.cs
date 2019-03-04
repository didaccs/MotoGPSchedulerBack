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

        [TestMethod]
        public void GetByNamePilot_Record()
        {
            InitializeDatabase();
            List<Record> records = DbInitializer.GetRecords();

            List<Record> recordsResult = repoRecord.GetAll(r=> r.Pilot == "Jorge Lorenzo").ToList();

            Assert.AreEqual(recordsResult.Count, 4);            
        }

        [TestMethod]
        public void Insert_Record()
        {
            Record record = new Record()
            {
                Pilot = "Marc Márquez",
                Time = new System.TimeSpan(0, 0, 1, 32, 351)
            };

            repoRecord.Insert(record);
            List<Record> recordsResult = repoRecord.GetAll().ToList();

            Assert.AreEqual(recordsResult.Count, 1);
            Assert.AreEqual(recordsResult[0].Pilot, record.Pilot);
        }
    }
}
