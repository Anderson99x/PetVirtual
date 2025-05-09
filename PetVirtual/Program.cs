using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🐶 Bem-vindo ao Pet Virtual!");
        Console.Write("Digite o nome do seu Pet: ");
        string nomeDoPet = Console.ReadLine();

        Pet meuPet = new Pet(nomeDoPet);

        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n--- MENU DO PET ---");
            Console.WriteLine("1. Ver status do Pet");
            Console.WriteLine("2. Alimentar o Pet");
            Console.WriteLine("3. Brincar com o Pet");
            Console.WriteLine("4. Colocar o Pet para dormir");
            Console.WriteLine("5. Levar ao veterinário");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("Digite uma opção válida!");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    meuPet.MostrarStatus();
                    break;
                case 2:
                    meuPet.Alimentar();
                    break;
                case 3:
                    meuPet.Brincar();
                    break;
                case 4:
                    meuPet.Dormir();
                    break;
                case 5:
                    if (meuPet.Estado == EstadoDeSaude.Doente)
                    {
                        meuPet.Curar();
                    }
                    else
                    {
                        Console.WriteLine($"{meuPet.Nome} está saudável e não precisa ir ao veterinário.");
                    }
                    break;
                case 0:
                    Console.WriteLine("Saindo do jogo... Até mais!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}