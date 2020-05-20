using BusDataAccess.Database;
using FlightDataAccess.Database;
using InfoTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTravel.Classes.Adaptors
{
    public class Adaptor
    {
        public List<PersonVM>  GetPersons(List<BusPersonTable> list)
        {
            return list.Select(x => new PersonVM { PersonName = x.Name, TravelTypeDescription = "Bus" }).ToList();
        }

        public List<PersonVM> GetPersons(List<FlightPersonTable> list)
        {
            return list.Select(x => new PersonVM { PersonName = x.Name, TravelTypeDescription = "Flight" }).ToList();
        }
    }
}
