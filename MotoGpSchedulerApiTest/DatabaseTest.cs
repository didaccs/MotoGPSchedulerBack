using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoGPSchedulerApi.Migrations;
using MotoGPSchedulerApi.Models;
using MotoGPSchedulerApi.Repository;

namespace MotoGpSchedulerApiTest
{
    public class DatabaseTest
    {
        protected IRepository<Event> repoEvent;
        protected IRepository<Circuit> repoCircuit;
        protected IRepository<Country> repoCountry;
        protected IRepository<Record> repoRecord;
        private IServiceProvider serviceProvider;

        public DatabaseTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<ApplicationContext>(options =>
                options
                .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceProvider = services.BuildServiceProvider();
            
            repoEvent = serviceProvider.GetRequiredService<IRepository<Event>>();
            repoCircuit = serviceProvider.GetRequiredService<IRepository<Circuit>>();
            repoCountry = serviceProvider.GetRequiredService<IRepository<Country>>();
            repoRecord = serviceProvider.GetRequiredService<IRepository<Record>>();
        }

        public void InitializeDatabase() {
            DbInitializer.Initialize(serviceProvider);
        }
    }
}
