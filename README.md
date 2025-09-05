# Estudos sobre assincronicidade em C#
Este repositório documenta meu estudo de como na fazer códigos assíncronos na linguagem C# no Visual Studio.

## Linguagens, Ferramentas e Tecnologias
> C#,
> Visual Studio 2022,
> .Net 8


## O que aprendi
### Threads

    void LerArquivo()
    {
      var conteudo = File.ReadAllText("voos.txt");
      Console.WriteLine($"Conteúdo: \n{conteudo}");
    }
    LerArquivo(() => LerArquivo());

    var threadLeitura = new Thread();
    threadLeitura.start();

Com Threads aprendi a trabalhar conceitos de assincronismo utilizando as Threads para executar uma função em paralelo. Além disso também fiz funções multithreads que permite que diferentes partes de um código sejam executados em simultâneo

### Task
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
    await ComprarPassagem();

Usei tasks para simplificar o uso de Thread, uma abordagem mais simples e mais moderna (sei que threads ainda são usadas em alguns casos)

### Cancelation Token
    CancellationTokenSource token = new CancellationTokenSource();

    token.Cancel();

    var voos = await client.ConsultarVoo(token.Token);
    foreach (Voo item in voos)
    {
      Console.WriteLine(item);
    }

Aprendi a criar e usar o CancellationToken para interromper a execução de uma task quando necessário, dando um controle maior sobre a função.

### Tratar Exceções em Tasks
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
    
Aqui eu faço um tratamendo de exceção dentro uma task para impedir a aplicação trave em caso de erros

### Usando funções assíncronos em uma API
Esse projeto é o "JornadasMilhas" da Alura, que é uma aplicação para auxiliar uma companhia aérea. Ele possuí uma API e as atividades consistiam em consumir a API usando programação assíncrona, seguindo as boas práticas.
