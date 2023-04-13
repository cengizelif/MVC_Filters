using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Filters.Models
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required, StringLength(20)]
        public string KullaniciAdi { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        [StringLength(100)]
        public string ControllerName { get; set; }

        [StringLength(250)]
        public string Aciklama { get; set; }
    }
}