using BusDataAccess;
using FlightDataAccess;
using InfoTravel.Classes.Application;
using InfoTravel.Models;
using System;
using Xunit;
using XUnitTestInfoTravel.Factory;

namespace XUnitTestInfoTravel
{
    public class PersonManagerTest
    {

        // TestMethod_Scenario_ExpectedBehavior

        [Fact]
        public void AddNewPerson_BusTraveller_AddsBusTraveller()
        {
            TestFactory testFactory = new TestFactory();

            IBusDbManager busDbManager =  testFactory.GetBusDbManager();

            PersonManager person = new PersonManager(testFactory);

            PersonVM personVM = new PersonVM {  PersonName = "TEST", TravelType = 'B'};

            person.AddNewPerson(personVM);

            Assert.Single(busDbManager.GetPersons());

        }

        [Fact]
        public void AddNewPerson_FlightTraveller_AddsFlightTraveller()
        {
            TestFactory testFactory = new TestFactory();

            IFlightDbManager flightDbManager = testFactory.GetFlightDbManager();

            PersonManager person = new PersonManager(testFactory);

            PersonVM personVM = new PersonVM { PersonName = "TEST", TravelType = 'F' };

            person.AddNewPerson(personVM);

            Assert.Single(flightDbManager.GetPersons());

        }
    }
}
