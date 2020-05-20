using FlightDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDataAccess
{

    public interface IFlightDbManager
    {
        List<FlightPersonTable> GetPersons();

        void AddNewPerson(FlightPersonTable person);
    }

    public class FlightDbManager : IFlightDbManager
    {
        private FlightDbContext dbContext;

        public FlightDbManager(FlightDbContext flgihtDbContext)
        {
            this.dbContext = flgihtDbContext;
        }

        public void AddNewPerson(FlightPersonTable person)
        {
            int nextValue = GetNextValue();

            person.Id = nextValue;
            dbContext.FlightPersons.Add(person);

            dbContext.SaveChanges();
        }


        public List<FlightPersonTable> GetPersons()
        {
            return dbContext.FlightPersons.ToList();
        }


        //https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/EFCoreAPI.html#GUID-770CD8EA-F963-48A5-A679-CAF471A4DB1A
        // Да се види UseOracleIdentityColumn
        public int GetNextValue()
        {
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select CORE_FLIGHT_PERSON_SEQ.NEXTVAL as NEXTVAL from dual";
                dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }


    }
}
