using dotnet_async;
using System.Text.Json;

//object chave = new object();
//Task<string> conteudoTask;
//lock(chave)
//{
//    conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));
//}

//async Task LerArquivoAsync(CancellationToken token)
//{
//    try
//    {
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
        
//    }
//    catch (OperationCanceledException ex)
//    {
//       Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//    }
//    catch (AggregateException ex)
//    {
//        Console.WriteLine($"Aconteceu o erro: {ex.InnerException.Message}");
//    }
    
//}

//async Task ExibirRelatorioAsync(CancellationToken token)
//{
//	try
//	{
//        Console.WriteLine("Executando relatório de compra de passagens!");
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//    }
//	catch(OperationCanceledException ex)
//	{

//        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
//	}
    
//}

//CancellationTokenSource tokenDeCancelamento = new CancellationTokenSource();

//Task tarefa= Task.WhenAll(LerArquivoAsync(tokenDeCancelamento.Token), ExibirRelatorioAsync(tokenDeCancelamento.Token));

//await Task.Delay(1000).ContinueWith(_ => tokenDeCancelamento.Cancel());

//Implementação da tarefa que lê um arquivo json com informações de voos.
async Task<List<Voo>> LerVoosDoArquivoJsonAsync(string caminhoArquivo)
{
    using (var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
    {
        return await JsonSerializer.DeserializeAsync<List<Voo>>(stream);
    }

}

async Task ProcessarVooAsync(Voo voo)
{
    // Simulação de algum processamento assíncrono (ex: gravação em banco, envio de email, etc.)
    await Task.Delay(1000); // Simula um atraso de 1 segundo para cada voo
Console.WriteLine($"Voo: {voo.Id}, Origem: {voo.Origem}, Destino: {voo.Destino}, Preço: {voo.Preco}, Milhas: {voo.MilhasNecessarias}");
}

async Task ProcessarVoosAsync()
{
    string caminhoArquivo = "voos.json";
    var voos = await LerVoosDoArquivoJsonAsync(caminhoArquivo);

    var tarefas = new List<Task>();

    foreach (var voo in voos)
    {
        // Processa cada voo de forma assíncrona
        tarefas.Add(ProcessarVooAsync(voo));
    }

    // Aguarda todas as tarefas terminarem
    await Task.WhenAll(tarefas);
}

await ProcessarVoosAsync();

Console.ReadKey();