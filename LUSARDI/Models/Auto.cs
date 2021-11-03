using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LUSARDI.Models
{   [Table("Vehiculo")]
    public class Auto
    {
        
            [Required]
            public int Id { get; set; }


            [Required]
            [Column(TypeName = "varchar")]
            [MaxLength(50)]
            public string Marca { get; set; }


            [Required]
            [Column(TypeName = "varchar")]
            [MaxLength(50)]
            public string Modelo { get; set; }

           
            [Column(TypeName = "varchar")]
            [MaxLength(50)]
            public string Color { get; set; }


            [Column(TypeName = "Money")]
            public decimal Precio { get; set; }
    }

       
}

