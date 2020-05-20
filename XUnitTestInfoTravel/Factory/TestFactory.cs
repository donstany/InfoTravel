using BusDataAccess;
using FlightDataAccess;
using InfoTravel.Classes.Adaptors;
using InfoTravel.Classes.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTestInfoTravel.Db;

namespace XUnitTestInfoTravel.Factory
{
    internal class TestFactory : IFactory
    {
        IBusDbManager testBusDbManager;
        IFlightDbManager testFlightDbManager;

        public Adaptor GetAdaptor()
        {
            return new Adaptor();
        }

        public IBusDbManager GetBusDbManager()
        {
            if (testBusDbManager == null)
            {
                testBusDbManager = new TestBusDbManager();
            }

            return testBusDbManager;
        }

        public IFlightDbManager GetFlightDbManager()
        {
            if (testFlightDbManager == null)
            {
                testFlightDbManager = new TestFlightDbManager();
            }

            return testFlightDbManager;
        }
    }
}
