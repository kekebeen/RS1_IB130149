using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Models
{
    public class Uposlenik
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        [ForeignKey(nameof(KorisnikId))]
        public virtual Korisnik Korisnik { get; set; }
        public DateTime UgovorPocetak { get;set; }
        public DateTime UgovorKraj { get; set; }
        public bool? Administrator { get; set; }
        public bool? Serviser { get; set; }
        public bool? Prodavac { get; set; }
    }
}
