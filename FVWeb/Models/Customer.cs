using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FVWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }

        public IList<Adress> Adresses { get; set; }
        //Adressi index olarak kullanmak için Ilist i kullandık
        //yani Customer Adress olorak kullanabiliriz customer.adres[0].Id gibi
    }
}
