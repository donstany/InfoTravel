using BusDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusDataAccess
{
    public interface IBusDbManager
    { 
        List<BusPersonTable> GetPersons();

        void AddNewPerson(BusPersonTable person);
    }

    public class BusDbManager : IBusDbManager
    {
        private BusDbContext busDbContext;

        public BusDbManager(BusDbContext busDbContext)
        {
            this.busDbContext = busDbContext;
        }

        public void AddNewPerson(BusPersonTable person)
        {
            int nextValue = GetNextValue();

            person.Id = nextValue;
            busDbContext.Persons.Add(person);

            busDbContext.SaveChanges();
        }


        public List<BusPersonTable> GetPersons()
        {
            return busDbContext.Persons.ToList();
        }


        //https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/EFCoreAPI.html#GUID-770CD8EA-F963-48A5-A679-CAF471A4DB1A
        // Да се види UseOracleIdentityColumn
        public int GetNextValue()
        {
            using (var command = busDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select CORE_PERSON_SEQ.NEXTVAL as NEXTVAL from dual";
                busDbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }


    }
}
