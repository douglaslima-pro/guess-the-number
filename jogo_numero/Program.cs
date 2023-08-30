//JOGO ADVINHE O NÚMERO
//o programa vai pedir para o usuário advinhar o número até acertar
//caso erre, o programa dirá se o número digitado é maior ou menor que o número gerado

using System;

void começaJogo()
{
    Console.WriteLine("********************************************************************************");
    Console.WriteLine(@"

▒█▀▀█ ▒█░▒█ ▒█▀▀▀ ▒█▀▀▀█ ▒█▀▀▀█ 　 ▀▀█▀▀ ▒█░▒█ ▒█▀▀▀
▒█░▄▄ ▒█░▒█ ▒█▀▀▀ ░▀▀▀▄▄ ░▀▀▀▄▄ 　 ░▒█░░ ▒█▀▀█ ▒█▀▀▀
▒█▄▄█ ░▀▄▄▀ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▄▄█ 　 ░▒█░░ ▒█░▒█ ▒█▄▄▄");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@"
▒█▄░▒█ ▒█░▒█ ▒█▀▄▀█ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█
▒█▒█▒█ ▒█░▒█ ▒█▒█▒█ ▒█▀▀▄ ▒█▀▀▀ ▒█▄▄▀
▒█░░▀█ ░▀▄▄▀ ▒█░░▒█ ▒█▄▄█ ▒█▄▄▄ ▒█░▒█

");
    Console.ResetColor();

    string mensagem = @"
Neste jogo, o programa gera um número aleatório entre 1 e 100
e você precisa advinhar qual é esse número.

";

    //Efeito de typewriting...
    foreach (char caractere in mensagem)
    {
        Console.Write(caractere);
        Thread.Sleep(30);
    }
    /*for (int i = 0; i < mensagem.Length; i++)
    {
        Console.Write(mensagem[i]);
        Thread.Sleep(30);
    }*/

    Console.Write("Aperte qualquer tecla para jogar...");
    Console.ReadKey(true);

    //Preparando o sorteio...
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\n\n\n\tPreparando ");
    Console.ResetColor();
    Console.WriteLine("o sorteio...");
    Thread.Sleep(2000);

    //Misturando todos os números
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\tMisturando ");
    Console.ResetColor();
    Console.WriteLine("todos os números...");
    Thread.Sleep(2000);

    //Tirando um número aleatório...
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\tTirando ");
    Console.ResetColor();
    Console.WriteLine("um número aleatório...");
    Thread.Sleep(3000);

    //Um número foi sorteado!
    Console.WriteLine("\tUm número foi sorteado!\n");
    Thread.Sleep(1000);

    //Gera número aleatório
    int numero = geraNumeroAleatorio();

    //pede para o usuário advinhar o número
    advinhaNumero(numero);

    Console.WriteLine("\n\n");
    Thread.Sleep(3000);
    Console.Write("Aperte qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
    começaJogo();
}

int geraNumeroAleatorio()
{
    Random numeroAleatorio = new Random();
    int numero = numeroAleatorio.Next(1, 101);
    return numero;
}

void advinhaNumero(int numero)
{
    int numeroEscolhido = 0;
    int tentativas = 0;

    do
    {
        tentativas++;

        if (tentativas > 1)
        {
            if (numeroEscolhido > numero)
            {
                Console.Write("\nO número sorteado é ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("MENOR!");
                Console.ResetColor();
            }
            else
            {
                Console.Write("\nO número sorteado é ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("MAIOR!");
                Console.ResetColor();
            }
        }
        Console.Write($"[Tentativa {tentativas}] Advinhe qual foi o número sorteado: ");

        //Tenta converter uma string em outro tipo de variável
        //Essa função retorna um valor booleano dependendo se a conversão deu certo ou não
        //Porém, podemos inserir o valor de conversão em uma variável usando o parâmetro out
        while (!int.TryParse(Console.ReadLine(), out numeroEscolhido) || !(numeroEscolhido >= 1 && numeroEscolhido <= 100))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInsira um número válido de 1 a 100!");
            Console.ResetColor();
            Console.Write($"[Tentativa {tentativas}] Advinhe qual foi o número sorteado: ");
        }

    } while (numeroEscolhido != numero);

    mostraPlacar(tentativas);
}

void mostraPlacar(int tentativas)
{
    Console.WriteLine("\n\n********************************************************************************");
    Console.Write(@"
▒█▀▀█ ▒█▀▀▀ ▒█▀▀▀█ ▒█░▒█ ▒█░░░ ▀▀█▀▀ ░█▀▀█ ▒█▀▀▄ ▒█▀▀▀█
▒█▄▄▀ ▒█▀▀▀ ░▀▀▀▄▄ ▒█░▒█ ▒█░░░ ░▒█░░ ▒█▄▄█ ▒█░▒█ ▒█░░▒█
▒█░▒█ ▒█▄▄▄ ▒█▄▄▄█ ░▀▄▄▀ ▒█▄▄█ ░▒█░░ ▒█░▒█ ▒█▄▄▀ ▒█▄▄▄█");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@"
▒█▀▀▀ ▀█▀ ▒█▄░▒█ ░█▀▀█ ▒█░░░
▒█▀▀▀ ▒█░ ▒█▒█▒█ ▒█▄▄█ ▒█░░░
▒█░░░ ▄█▄ ▒█░░▀█ ▒█░▒█ ▒█▄▄█
");
    Console.ResetColor();
    Console.WriteLine($"Tentativas: {tentativas}");

    if (tentativas < 2)
    {
        Console.WriteLine("NOTA: S");
        Console.WriteLine("\nYou slayed it!");
    }
    else if (tentativas < 4)
    {
        Console.WriteLine("NOTA: A");
        Console.WriteLine("\nYou did good.");
    }
    else if (tentativas < 6)
    {
        Console.WriteLine("NOTA: B");
        Console.WriteLine("\nNot bad.");
    }
    else if (tentativas < 8)
    {
        Console.WriteLine("NOTA: C");
        Console.WriteLine("\nToo lazy.");
    }
    else
    {
        Console.WriteLine("NOTA: D");
        Console.WriteLine("\nYou slacked off!");
    }
    Console.WriteLine("\n********************************************************************************");
}

começaJogo();