using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_async.Estudos
{
    internal class SicronizandoTarefas
    {
        //O lock pode ser usado para gerenciar o acesso simultâneo a um bloco de códigos
        //Apenas uma thread pode acessar um bloco lock por vez
        object chave = new object();

        public void ExecutarLock()
        {
            lock (chave)
            {
                //Trecho de código a ser executado
                //Como executar funções em paralelo
                //Parallel.For(0, 10, i => LerArquivoAsync(tokenDeCancelamento.Token));
            }
        }

        public void ExecutarSlim()
        {

            //O objeto SemaphoreSlim limite o acesso a uma therad a uma certa quantidade
            SemaphoreSlim semaforo = new(2); // Permite até 2 threads simultâneas
            
            // Cria 5 tarefas que incrementam o contador
            //var tarefas = Enumerable.Range(0, 5).Select(_ => IncrementarAsync());
            //await Task.WhenAll(tarefas);
            //Task<string> conteudoJson = File.ReadAllTextAsync(@"voos.json");
        }
       

    }
}
