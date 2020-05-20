using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTravel.Models
{
    public class PersonVM
    {
        public string TravelTypeDescription { get; set; }

        [DisplayName("Тип")]
        public char TravelType { get; set; }
       
        [DisplayName("Име")]
        public string PersonName { get; set; }

    }
}
