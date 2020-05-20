using BusDataAccess;
using BusDataAccess.Database;
using FlightDataAccess;
using FlightDataAccess.Database;
using InfoTravel.Classes.Adaptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTravel.Classes.Factories
{
   public interface IFactory
    {
        IFlightDbManager GetFlightDbManager();
        IBusDbManager GetBusDbManager();
        Adaptor GetAdaptor();
    }

    public class Factory : IFactory
    {
        private readonly FlightDbContext flgihtDbContext;
        private readonly BusDbContext busDbContext;

        public Factory(FlightDbContext flgihtDbContext, BusDbContext busDbContext)
        {
            this.flgihtDbContext = flgihtDbContext;
            this.busDbContext = busDbContext;
        }

        public IBusDbManager GetBusDbManager()
        {
            IBusDbManager dbManger = new BusDbManager(busDbContext);
             
            return dbManger;
        }

        public IFlightDbManager GetFlightDbManager()
        {
            IFlightDbManager dbManger = new FlightDbManager(flgihtDbContext); 

            return dbManger;
        }

        public Adaptor GetAdaptor()
        {
            return new Adaptor();
        }
    }
}
