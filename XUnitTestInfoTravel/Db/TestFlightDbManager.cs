using FlightDataAccess;
using FlightDataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestInfoTravel.Db
{
    internal class TestFlightDbManager : IFlightDbManager
    {
        List<FlightPersonTable> list = new List<FlightPersonTable>();

        public void AddNewPerson(FlightPersonTable person)
        {
            list.Add(person);
        }

        public List<FlightPersonTable> GetPersons()
        {
            return list;
        }
    }
}
