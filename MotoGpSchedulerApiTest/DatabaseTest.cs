//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using MotoGPSchedulerApi.Models;
//using MotoGPSchedulerApi.Repository;

//namespace MotoGpSchedulerApiTest
//{
//    public class DatabaseTest
//    {
//        DbSet<Event> _entitiesEvents;
//        DbSet<Country> _entitiesCountries;
//        DbSet<Record> _entitiesRecords;
//        DbSet<Circuit> _entitiesCircuits;

//        public ApplicationContext GetDbContext()
//        {
//            DbContextOptionsBuilder<ApplicationContext> builder = new DbContextOptionsBuilder<ApplicationContext>();
//            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

//            ApplicationContext dbContext = new ApplicationContext(builder.Options);
//            dbContext.Database.EnsureCreated();

//            _entitiesEvents = dbContext.Set<Event>();
//            _entitiesCountries = dbContext.Set<Country>();
//            _entitiesRecords = dbContext.Set<Record>();
//            _entitiesCircuits = dbContext.Set<Circuit>();

//            return dbContext;
//        }

//        public void InitializeInMemory()
//        {
//            List<Country> countries = new List<Country>()
//            {
//                new Country()
//                {
//                    Name = "Spain"
//                },
//                new Country()
//                {
//                    Name = "Malaysia"
//                },
//                new Country()
//                {
//                    Name = "Qatar"
//                }
//            };

//            foreach (Country c in countries)
//            {
//                _entitiesCountries.Add.Insert(c);
//            }
//            countries = repoCountry.GetAll().ToList();

//            List<Record> records = new List<Record>()
//            {
//                new Record()
//                {
//                    Pilot = "Jorge Lorenzo",
//                    Time = new TimeSpan(0, 0, 1, 31, 171)
//                },
//                new Record()
//                {
//                    Pilot = "Jorge Lorenzo",
//                    Time = new TimeSpan(0, 0, 2, 0, 606)
//                },
//                new Record()
//                {
//                    Pilot = "Jorge Lorenzo",
//                    Time = new TimeSpan(0, 0, 1, 54, 927)
//                }
//            };

//            foreach (Record c in records)
//            {
//                repoRecord.Insert(c);
//            }
//            records = repoRecord.GetAll().ToList();

//            List<Circuit> circuits = new List<Circuit>()
//            {
//                new Circuit()
//                {
//                    Country = countries.First(c=> c.Name == "Spain"),
//                    Name = "Ricardo Tormo",
//                    Length = 4000,
//                    TurnsLeft = 9,
//                    TurnsRight = 5,
//                    Width= 12,
//                    StraightLong = 876,
//                    LastRecord = records[0]
//                },
//                new Circuit()
//                {
//                    Country = countries.First(c=> c.Name == "Malaysia"),
//                    Name = "International Circuit",
//                    Length = 5500,
//                    TurnsLeft = 5,
//                    TurnsRight = 10,
//                    Width= 16,
//                    StraightLong = 920,
//                    LastRecord = records[1]
//                },
//                new Circuit()
//                {
//                    Country = countries.First(c=> c.Name == "Qatar"),
//                    Name = "Losail International Circuit",
//                    Length = 5400,
//                    TurnsLeft = 6,
//                    TurnsRight = 10,
//                    Width= 12,
//                    StraightLong = 1068,
//                    LastRecord = records[2]
//                },
//            };

//            foreach (Circuit c in circuits)
//            {
//                repoCircuit.Insert(c);
//            }
//            circuits = repoCircuit.GetAll().ToList();

//            List<Event> events = new List<Event>()
//            {
//                new Event()
//                {
//                    Circuit = circuits[0],
//                    Date = new DateTime(2019,11,20),
//                    Name = "Valencia MotoGP™"
//                },
//                new Event()
//                {
//                    Circuit = circuits[1],
//                    Date = new DateTime(2019,02,06),
//                    Name = "Sepang MotoGP™"
//                },
//                new Event()
//                {
//                    Circuit = circuits[1],
//                    Date = new DateTime(2019,02,23),
//                    Name = "Qatar MotoGP™"
//                },
//            };

//            foreach (Event c in events)
//            {
//                repoEvent.Insert(c);
//            }
//            events = repoEvent.GetAll().ToList();
//        }
//    }
//}
