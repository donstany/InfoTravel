using BusDataAccess;
using BusDataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestInfoTravel.Db
{
    internal class TestBusDbManager : IBusDbManager
    {
        List<BusPersonTable> list = new List<BusPersonTable>();

        public void AddNewPerson(BusPersonTable person)
        {
            list.Add(person);
        }

        public List<BusPersonTable> GetPersons()
        {
            return list;
        }
    }
}
