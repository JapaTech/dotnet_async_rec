using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_async.Modelos
{
    public class CompraPassagemRequest
    {
        public string? Origem {  get; set; }
        public string? Destino { get; set; }
        public int Milhas { get; set; }
    }
}
