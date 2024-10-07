void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");
    Thread.Sleep(new Random().Next(300, 8000));
    Console.WriteLine($"Conteúdo: \n{conteudo}");
}

void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");
    Thread.Sleep(new Random().Next(300, 8000));
}

var thread1 = new Thread(()=> LerArquivo());

var thread2 = new Thread(() => ExibirRelatorio());


void InicializarThreads()
{
    thread1.Start();
    while(thread1.IsAlive)
    {
        Console.WriteLine("Thread 1 em execução...");
    }
    thread2.Start();
}

InicializarThreads();

Console.WriteLine("Outras operações.");
Console.ReadKey();