using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Filters.Models
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(30)]
        public string Ad { get; set; }

        [Required, StringLength(30)]
        public string Soyad { get; set; }

        [Required, StringLength(20),DisplayName("Username")]
        public string KullaniciAdi { get; set; }

        [Required, StringLength(15),DisplayName("Password")]
        public string Sifre { get; set; }

    }
}