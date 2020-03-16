using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Models
{
    public class Superhero
    {
        [Key]
        public int SuperHeroId { get; set; }
        public string Name { get; set; }
        public string SuperPower{ get; set; }
        public string SecondarySuperPower{ get; set; }
        public string CatchPhrase{ get; set; }

    }

}
