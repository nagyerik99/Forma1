using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Forma1.Data;

namespace Forma1.Models
{
    public class RaceGroup
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Team Name is required")]
        [StringLength(50)]
        [TestName]
        public string Name { get; set; }
        [DataType(DataType.Date),Required(ErrorMessage ="Year of Foundation is required")]
        [Display(Name = "Year of Foundation")]
        public DateTime YoF { get; set; }
        [Required(ErrorMessage ="Won Races is required"), Range(0,100)]
        [Display(Name = "Won Races")]
        public int WonRaces { get; set; }
        [Display(Name = "Entry Fee Payed")]
        public bool Payed { get; set; }
    }
}
