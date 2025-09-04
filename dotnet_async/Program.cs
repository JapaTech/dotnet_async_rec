using dotnet_async;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using dotnet_async.Client;
using dotnet_async.Modelos;

#region Estudos sobre Progamação Assíncrona
////------------Progamação assíncrona com Thread---------	
////*não é mais tão usado hojem dia
////var thread = new Thread(() => LerArquivo());
////thread.Start();

////void FazerRelatorio()
////{
////    Task.Delay(1000);
////    Console.WriteLine("Relatorio feito");
////}

////var task1 = Task.Run(() => FazerRelatorio());
////task1.Start();


////----------------Hoje em dia programação assíncrona hoje é feita usando 'task'
////Task<string> conteudo = Task.Run(() => File.ReadAllText(@"voos.txt"));

////void LerArquivo()
////{
////    try
////    {
////        Task.Delay(new Random().Next(300, 8000));
////        Console.WriteLine($"Conteúdo:\n {conteudo.Result}");
////    }
////    catch (AggregateException ex)
////    {

////        Console.WriteLine("Erro ao ler arquivo: " + ex.Message);
////    }

////}
//// Task taskLerArquivo = Task.Run(() => LerArquivo())

////------------Além de criar task, torne as funções assíncronas
////*É importante deixar a função assíncrona também
////*Esse é o jeito mais comum de fazer uma função assíncrona, diferente do jeito anterior,
////*aqui a função também é marcada como assíncrona.
////*Isso faz a função toda ser executada numa thread separada

////Task<string> conteudo = Task.Run(() => File.ReadAllTextAsync(@"voos.txt"));

////async void LerArquivoAsync()
////{
////    try
////    {
////        await Task.Delay(new Random().Next(300, 8000));
////        Console.WriteLine($"Conteúdo:\n {conteudo.Result}");
////    }
////    catch (AggregateException ex)
////    {

////        Console.WriteLine("Erro ao ler arquivo: " + ex.Message);
////    }

////}

////LerArquivoAsync();


//////------------------Tirando funções void
//////*O padrão do tipo de retorno, pode ser void, int, string, etc..., porém isso limita a função e pode
//////*exigir vários tratamento de erros
//////*O ideal, recomendado pela Microsoft, é retornar uma task
//////*Caso precise resultado use Task<T> onde T é o tipo que a task deve retornar
////Task<string> conteudo = Task.Run(() => File.ReadAllTextAsync(@"voos.txt"));

////async Task LerArquivoAsync()
////{
////    try
////    {
////        await Task.Delay(new Random().Next(300, 8000));
////        Console.WriteLine($"Conteúdo:\n {conteudo.Result}");
////    }
////    catch (AggregateException ex)
////    {

////        Console.WriteLine("Erro ao ler arquivo: " + ex.Message);
////    }

////}

////async Task ExibirRelatorioAsync()
////{
////    Console.WriteLine("Lendo relatorios");
////    await Task.Delay(new Random().Next(300, 8000));
////}

//////*await é necessário para efetivamente chamar uma função assíncrona que retorna uma Task
//////await LerArquivoAsync();
//////await ExibirRelatorioAsync();

//////*Porém fazendo a chamada da função como está acima
//////*o código vai esperar cada função terminar executar para ir para a próxima;
//////*Então é necessário o seguinte método para executar as task de forma paralela
////await Task.WhenAll(LerArquivoAsync(), ExibirRelatorioAsync());

////Console.WriteLine("Outras operações");
////Console.ReadKey();

////---------------Fazendo funções tasks seguras
////Existem casos que é necessário verificar erros e terminar uma função assíncrona quando acontecer algum erro
////Para isso é necessário criar um cancelation token, que serve para o tratamento de excesseções em tasks

////O objeto CancellationTokenSource é usado para cancelar funções quando necessário



//Task<string> conteudo = Task.Run(() => File.ReadAllTextAsync(@"voos.txt"));

////Para uma função ser cancelada ela percisa receber um parâmetro CancellationToken
//async Task LerArquivoTXTAsync(CancellationToken token)
//{
//    try
//    {
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//        Console.WriteLine($"Conteúdo:\n {conteudo.Result}");
//    }
//    catch (OperationCanceledException ex)
//    {
//        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//    }
//    catch (AggregateException ex)
//    {
//        Console.WriteLine("Erro ao ler arquivo: " + ex.InnerException.Message);
//    }

//}

//async Task ExibirRelatorioAsync(CancellationToken token)
//{
//    try
//    {
//        Console.WriteLine("Exibindo relatorios");
//        await Task.Delay(new Random().Next(3000, 8000));
//        token.ThrowIfCancellationRequested();
//    }
//    catch (OperationCanceledException ex)
//    {
//        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//    }
//    catch (AggregateException ex)
//    {
//        Console.WriteLine("Erro ao ler arquivo: " + ex.InnerException.Message);
//    }
//}

//CancellationTokenSource tokenDeCancelamento = new CancellationTokenSource();

////Para simular o cancelamento da função vamos tranformar em variável e logo após chamar o token
////Task tarefa = Task.WhenAll(LerArquivoTXTAsync(tokenDeCancelamento.Token), 
//   // ExibirRelatorioAsync(tokenDeCancelamento.Token));

////Cancela todas as funções com o token de cancelamento
////await Task.Delay(500).ContinueWith(_ => tokenDeCancelamento.Cancel());

//Console.WriteLine("Outras operações");
//Console.ReadKey();

//////********************Atividade Ler Arquivos JSON async
////async Task<List<voo>> LerArquivosJSONAsync(CancellationToken token, 
////    string caminho = @"C:\Users\Jonathan\Desktop\Projetos\Alura\CS_ProgAssincrona\dotnet_async_rec\dotnet_async\voos.json") 
////{

////    try
////    {
////        token.ThrowIfCancellationRequested();
////        using (var stream = new FileStream(caminho, FileMode.Open, FileAccess.Read))
////        {
////            return await JsonSerializer.DeserializeAsync<List<voo>>(stream);
////        }

////    }
////    catch (OperationCanceledException ex)
////    {
////        Console.WriteLine("Erro: " + ex.Message);
////        return new List<voo>();
////    }
////    catch (Exception ex)
////    {
////        Console.WriteLine("Erro: " + ex.InnerException.Message);
////        return new List<voo>();
////    }
////}

////async Task ProcessarVooAsync(voo voo)
////{
////    Task.Delay(1000);
////    Console.WriteLine(voo.ToString());
////}

////async Task LerVoosAsync()
////{
////    List<voo> voos = await LerArquivosJSONAsync(tokenDeCancelamento.Token);

////    var tarefas = new List<Task>();

////    foreach (var item in voos)
////    {
////        tarefas.Add(ProcessarVooAsync(item));
////    }

////    Task.WhenAll(tarefas);
////}

////await LerVoosAsync();

//////********************
#endregion

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarVoosAsync()
{
	try
	{
        CancellationTokenSource token = new CancellationTokenSource();

        token.Cancel();

        var voos = await client.ConsultarVoo(token.Token);
        foreach (Voo item in voos)
        {
            Console.WriteLine(item);
        }
    }
	catch (Exception ex)
	{
        Console.WriteLine("Erro ao processar voos: " + ex.InnerException.Message);
	}

	
}

async Task ComprarPassagem()
{
	CompraPassagemRequest request = new CompraPassagemRequest
	{
		Origem = "Brasília",
		Destino = "São Paulo",
		Milhas = 1500
	};
	var compra = await client.ComprarPassagem(request);
    Console.WriteLine();
	Console.WriteLine(compra);
}

await ProcessarVoosAsync();
await ComprarPassagem();

