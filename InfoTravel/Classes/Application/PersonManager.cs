using BusDataAccess;
using BusDataAccess.Database;
using FlightDataAccess;
using FlightDataAccess.Database;
using InfoTravel.Classes.Adaptors;
using InfoTravel.Classes.Factories;
using InfoTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTravel.Classes.Application
{
    public class PersonManager
    {

        private readonly IBusDbManager busDbManager;
        private readonly IFlightDbManager flightDbManager;
        private Adaptor adaptor;

        public PersonManager(IFactory factory)
        {
            this.busDbManager = factory.GetBusDbManager();
            this.flightDbManager = factory.GetFlightDbManager();

            adaptor = factory.GetAdaptor();
        }

        public List<PersonVM> GetPersons()
        {
            var busPersons = adaptor.GetPersons( busDbManager.GetPersons());
            var flightPersons = adaptor.GetPersons(flightDbManager.GetPersons());

            busPersons.AddRange(flightPersons);

            return busPersons;
        }

        public void AddNewPerson(PersonVM person)
        {
            if (person.TravelType == 'B')
            {
                BusPersonTable personTable = new BusPersonTable { Name = person.PersonName };
                busDbManager.AddNewPerson(personTable);
            }

            if (person.TravelType == 'F')
            {
                FlightPersonTable personTable = new FlightPersonTable { Name = person.PersonName };
                flightDbManager.AddNewPerson(personTable);
            }
        }
    }
}
