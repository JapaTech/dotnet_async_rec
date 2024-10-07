Task<string> conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));
async void LerArquivoAsync()
{
	try
	{
        await Task.Delay(new Random().Next(300, 8000));
        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
    }
	catch (AggregateException ex)
	{
        Console.WriteLine($"Aconteceu o erro: {ex.InnerException.Message}");
    }
    
}

async void ExibirRelatorioAsync()
{
    Console.WriteLine("Executando relatório de compra de passagens!");
    await Task.Delay(new Random().Next(300, 8000));
}

//Task task1 = Task.Run(()=> LerArquivo());

//Task task2 = Task.Run(() => ExibirRelatorio());

LerArquivoAsync();
ExibirRelatorioAsync();

Console.WriteLine("Outras operações.");
Console.ReadKey();