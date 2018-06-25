using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Pedagog_MVC.Models
{
    [Table("skolska_godina")]
    public class SkolskaGodina
    {
        [Key]
        [Required]
        public long id_skolska_godina { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Školska Godina")]
        public int godina{ get; set; }

        }
    }

