using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusDataAccess.Database
{
    [Table("CORE_PERSON")]
    public class BusPersonTable
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
