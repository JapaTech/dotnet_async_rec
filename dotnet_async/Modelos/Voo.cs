using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_async.Modelos
{
    public class Voo
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Preco { get; set; }
        public int MilhasNecessarias { get; set; }

        public override string ToString()
        {
            return $"Id: {Id};\nOrigem: {Origem};\nDestino: {Destino};\n" +
                $"Preco: R$ {Preco};\nMilhas Necessarias: {MilhasNecessarias}";
        }
    }
}
