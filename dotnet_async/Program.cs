Task<string> conteudoTask = Task.Run(() => File.ReadAllText(".voos.txt"));
void LerArquivo()
{
	try
	{
        Task.Delay(new Random().Next(300, 8000));
        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
    }
	catch (AggregateException ex)
	{
        Console.WriteLine($"Aconteceu o erro: {ex.InnerException.Message}");
    }
    
}

void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");
    Task.Delay(new Random().Next(300, 8000));
}

Task task1 = Task.Run(()=> LerArquivo());

Task task2 = Task.Run(() => ExibirRelatorio());

Console.WriteLine("Outras operações.");
Console.ReadKey();