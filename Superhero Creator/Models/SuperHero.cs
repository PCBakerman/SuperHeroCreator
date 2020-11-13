using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superhero_Creator.Models
{
    //this model will represent a table in your database and the properties represent the columns of that table in the database.
    
    public class SuperHero
    {   [Key]
        public int ID { get; set; }
        public string SuperName { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        public string Catchphrase { get; set; }
    }
}
