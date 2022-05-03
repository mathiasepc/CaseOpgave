using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.Codes
{
    internal class ProductModel 
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Year { get; set; }
        public string? Rating { get; set; }
        public string? Price { get; set; }
        public List<string>? Keywords { get; set; }
    }
}
