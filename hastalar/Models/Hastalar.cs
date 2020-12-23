using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hastalar.Models
{
    public class Hastalar
    {
        public int ID { get; set; }
        
        [Required]
        public string HastaAdi { get; set; }
        [Required]
        public string HastaSoyadi { get; set; }
        [Required]
        public string HastaKanGrubu { get; set; }
        [Phone]
        public string HastaTelNo { get; set; }
    }
}