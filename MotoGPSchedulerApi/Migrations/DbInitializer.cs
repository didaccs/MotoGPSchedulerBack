using Microsoft.Extensions.DependencyInjection;
using MotoGPSchedulerApi.Models;
using MotoGPSchedulerApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MotoGPSchedulerApi.Migrations
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationContext context = services.GetRequiredService<ApplicationContext>();

            context.Database.EnsureCreated();

            IRepository<Event> repoEvent = services.GetRequiredService<IRepository<Event>>();
            IRepository<Circuit> repoCircuit = services.GetRequiredService<IRepository<Circuit>>();
            IRepository<Country> repoCountry = services.GetRequiredService<IRepository<Country>>();
            IRepository<Record> repoRecord = services.GetRequiredService<IRepository<Record>>();
            
            if (repoEvent.GetAll().Any())
            {
                return;
            }
            
            foreach (Country c in GetCountries())
            {
                repoCountry.Insert(c);
            }
            List<Country> countries = repoCountry.GetAll().ToList();

            foreach (Record c in GetRecords())
            {
                repoRecord.Insert(c);
            }
            List<Record> records = repoRecord.GetAll().ToList();

            foreach (Circuit c in GetCircuits(countries, records))
            {
                repoCircuit.Insert(c);
            }
            List<Circuit> circuits = repoCircuit.GetAll().ToList();

            foreach (Event c in GetEvents(circuits))
            {
                repoEvent.Insert(c);
            }
            List<Event> events = repoEvent.GetAll().ToList();
        }

        public static List<Country> GetCountries()
        {
            return new List<Country>()
            {
                new Country(){Name = "Spain"},
                new Country(){Name = "Malaysia"},
                new Country(){Name = "Qatar"},
                new Country(){Name = "Argentina"},
                new Country(){Name = "Estados unidos"},
                new Country(){Name = "Francia"},
                new Country(){Name = "Italia"},
                new Country(){Name = "Alemania"},
                new Country(){Name = "República checa"},
                new Country(){Name = "Austria"}
            };
        }

        public static List<Record> GetRecords()
        {
            return new List<Record>()
            {
                new Record(){
                    Pilot = "Jorge Lorenzo",
                    Time = new TimeSpan(0, 0, 1, 31, 171)
                },
                new Record(){
                    Pilot = "Jorge Lorenzo",
                    Time = new TimeSpan(0, 0, 2, 0, 606)
                },
                new Record(){
                    Pilot = "Jorge Lorenzo",
                    Time = new TimeSpan(0, 0, 1, 54, 927)
                },
                new Record(){
                    Pilot = "Valentino Rossi",
                    Time = new TimeSpan(0, 0, 1, 39, 019)
                },
                new Record(){
                    Pilot = "Marc Marquez",
                    Time = new TimeSpan(0, 0, 2, 03, 575)
                },
                new Record(){
                    Pilot = "Jorge Lorenzo",
                    Time = new TimeSpan(0, 0, 1, 38, 735)
                },
                new Record(){
                    Pilot = "Maverick Viñales",
                    Time = new TimeSpan(0, 0, 1, 32, 309)
                },
                new Record(){
                    Pilot = "Marc Marquez",
                    Time = new TimeSpan(0, 0, 1, 47, 639)
                },
                new Record(){
                    Pilot = "Jonas Folger",
                    Time = new TimeSpan(0, 0, 1, 21, 442)
                },
                new Record(){
                    Pilot = "Dani Pedrosa",
                    Time = new TimeSpan(0, 0, 1, 56, 027)
                },
                new Record(){
                    Pilot = "Andrea Dovizioso",
                    Time = new TimeSpan(0, 0, 1, 24, 277)
                },
            };
        }

        public static List<Circuit> GetCircuits(List<Country> countries, List<Record> records)
        {
            return new List<Circuit>()
            {
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Spain"),
                    Name = "Ricardo Tormo",
                    Length = 4000,
                    TurnsLeft = 9,
                    TurnsRight = 5,
                    Width= 12,
                    StraightLong = 876,
                    LastRecord = records[0],
                    ImageName = "ricardo_tormo.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Malaysia"),
                    Name = "Sepang International Circuit",
                    Length = 5500,
                    TurnsLeft = 5,
                    TurnsRight = 10,
                    Width= 16,
                    StraightLong = 920,
                    LastRecord = records[1],
                    ImageName ="sepang_international_circuit.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Qatar"),
                    Name = "Losail International Circuit",
                    Length = 5400,
                    TurnsLeft = 6,
                    TurnsRight = 10,
                    Width= 12,
                    StraightLong = 1068,
                    LastRecord = records[2],
                    ImageName = "losail_international_circuit.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Argentina"),
                    Name = "Termas de Río Hondo",
                    Length = 4800,
                    TurnsLeft = 5,
                    TurnsRight = 9,
                    Width= 16,
                    StraightLong = 1076,
                    LastRecord = records[3],
                    ImageName="termas_rio_hondo.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Estados unidos"),
                    Name = "Circuit Of The Americas",
                    Length = 5500,
                    TurnsLeft = 11,
                    TurnsRight = 9,
                    Width= 15,
                    StraightLong = 1200,
                    LastRecord = records[4],
                    ImageName ="circuit_americas.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Spain"),
                    Name = "Circuito de Jerez - Angel Nieto",
                    Length = 4400,
                    TurnsLeft = 5,
                    TurnsRight = 8,
                    Width= 11,
                    StraightLong = 607,
                    LastRecord = records[5],
                    ImageName="jerez_angel_nieto.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Francia"),
                    Name = "Le Mans",
                    Length = 4200,
                    TurnsLeft = 5,
                    TurnsRight = 9,
                    Width= 13,
                    StraightLong = 674,
                    LastRecord = records[6],
                    ImageName="le_mans.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Italia"),
                    Name = "Autodromo del Mugello",
                    Length = 5200,
                    TurnsLeft = 6,
                    TurnsRight = 9,
                    Width= 14,
                    StraightLong = 1141,
                    LastRecord = records[7],
                    ImageName="autodromo_mugello.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Spain"),
                    Name = "Circuit de Barcelona-Catalunya",
                    Length = 4700,
                    TurnsLeft = 5,
                    TurnsRight = 8,
                    Width= 12,
                    StraightLong = 1047,
                    LastRecord = null,
                    ImageName="barcelona.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Alemania"),
                    Name = "Sachsenring",
                    Length = 3700,
                    TurnsLeft = 10,
                    TurnsRight = 3,
                    Width= 12,
                    StraightLong = 700,
                    LastRecord = records[8],
                    ImageName="sachsenring.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "República checa"),
                    Name = "Automotodrom Brno",
                    Length = 5400,
                    TurnsLeft = 6,
                    TurnsRight = 8,
                    Width= 15,
                    StraightLong = 636,
                    LastRecord = records[9],
                    ImageName="brno.png"
                },
                new Circuit()
                {
                    Country = countries.First(c=> c.Name == "Austria"),
                    Name = "Red Bull Ring - Spielberg",
                    Length = 4300,
                    TurnsLeft = 3,
                    TurnsRight = 7,
                    Width= 13,
                    StraightLong = 626,
                    LastRecord = records[10],
                    ImageName="spielberg.png"
                },
            };
        }

        public static List<Event> GetEvents(List<Circuit> circuits)
        {
            return new List<Event>()
            {
                new Event()
                {
                    Circuit = circuits[0],
                    Date = new DateTime(2019,11,15),
                    Name = "Gran Premio Motul"
                },
                new Event()
                {
                    Circuit = circuits[1],
                    Date = new DateTime(2019,11,01),
                    Name = "Shell Malaysia Motorcycle"
                },
                new Event()
                {
                    Circuit = circuits[2],
                    Date = new DateTime(2019,02,23),
                    Name = "Qatar Grand Prix"
                },
                new Event()
                {
                    Circuit = circuits[3],
                    Date = new DateTime(2019,03,29),
                    Name = "Gran Premio Motul"
                },
                new Event()
                {
                    Circuit = circuits[4],
                    Date = new DateTime(2019,04,12),
                    Name = "Red Bull Grand Prix"
                },
                new Event()
                {
                    Circuit = circuits[5],
                    Date = new DateTime(2019,05,03),
                    Name = "Gran Premio Red Bull"
                },
                new Event()
                {
                    Circuit = circuits[6],
                    Date = new DateTime(2019,05,17),
                    Name = "SHARK Helmets Grand Prix"
                },
                new Event()
                {
                    Circuit = circuits[7],
                    Date = new DateTime(2019,05,31),
                    Name = "Gran Premio Oakley"
                },
                new Event()
                {
                    Circuit = circuits[8],
                    Date = new DateTime(2019,06,14),
                    Name = "Gran Premi Monster Energy"
                },
                new Event()
                {
                    Circuit = circuits[9],
                    Date = new DateTime(2019,07,05),
                    Name = "HJC Helmets Motorrad Grand Prix"
                },
                new Event()
                {
                    Circuit = circuits[10],
                    Date = new DateTime(2019,08,02),
                    Name = "Monster Energy Grand Prix"
                },
                new Event()
                {
                    Circuit = circuits[11],
                    Date = new DateTime(2019,08,09),
                    Name = "World Motorrad Grand Prix von Österreich"
                },
            };
        }
    }
}

