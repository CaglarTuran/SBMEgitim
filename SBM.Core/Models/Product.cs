using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[Precision]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int Number { get; set; }

        public string Barcode { get; set; }

        public int CategoryId { get; set; }

        public Byte[] RowVersion { get; set; }

        public virtual Category Category { get; set; }
    }
}