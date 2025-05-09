using System;
using System.Collections.Generic;

public enum EstadoDeSaude
{
    Saudavel,
    Doente
}

public class Pet
{
    public int Nivel { get; private set; }
    public int Experiencia { get; private set; }
    private List<string> conquistas;
    public EstadoDeSaude Estado { get; private set; }
    public string Nome { get; private set; }
    private string nomeInterno;
    private int fome;
    private int felicidade;
    private int energia;
    private int felicidadeConsecutiva = 0;
    private Random random = new Random();

    public Pet(string nome)
    {
        this.Nome = nome;
        this.nomeInterno = nome;
        fome = 50;
        felicidade = 50;
        energia = 50;
        Nivel = 1;
        Experiencia = 0;
        conquistas = new List<string>();
        Estado = EstadoDeSaude.Saudavel;
    }

    public void Alimentar()
    {
        if (Estado == EstadoDeSaude.Saudavel)
        {
            fome += 10;
            if (fome > 100) fome = 100;
            Console.WriteLine($"{Nome} foi alimentado.");
        }
        else
        {
            energia -= 5;
            felicidade -= 2;
            fome += 5;
            if (energia < 0) energia = 0;
            if (felicidade < 0) felicidade = 0;
            if (fome > 100) fome = 100;
            Console.WriteLine($"{Nome} comeu um pouco, mas ainda não está bem.");
        }
        VerificarDoenca();
    }

    public void Brincar()
    {
        if (Estado == EstadoDeSaude.Saudavel)
        {
            felicidade += 10;
            energia -= 5;
            if (felicidade > 100) felicidade = 100;
            Console.WriteLine($"{Nome} brincou e está mais feliz.");

            felicidadeConsecutiva++;

            if (felicidadeConsecutiva >= 5)
            {
                Experiencia++;
                Console.WriteLine($"{Nome} ganhou 1 ponto de experiência!");
                felicidadeConsecutiva = 0;
            }
        }
        else
        {
            energia -= 10;
            felicidade -= 5;
            Console.WriteLine($"{Nome} tentou brincar, mas não está se sentindo bem...");
            if (energia < 0) energia = 0;
            if (felicidade < 0) felicidade = 0;
        }

        VerificarNivel();
        VerificarDoenca();
    }

    private void VerificarNivel()
    {
        if (Experiencia >= 10)
        {
            Nivel++;
            Experiencia = 0;
            int aumentoMaximo = 5;
            energia += aumentoMaximo;
            if (energia > 100) energia = 100;
            felicidade += aumentoMaximo;
            if (felicidade > 100) felicidade = 100;

            conquistas.Add($"Alcançou nível {Nivel}");
            Console.WriteLine($"🎉 {Nome} subiu para o nível {Nivel}!");
        }
    }

    public void Dormir()
    {
        if (Estado == EstadoDeSaude.Saudavel)
        {
            energia += 20;
            if (energia > 100) energia = 100;
            Console.WriteLine($"{Nome} dormiu e recuperou energia.");
        }
        else
        {
            energia += 10;
            felicidade -= 3;
            if (energia > 100) energia = 100;
            if (felicidade < 0) felicidade = 0;
            Console.WriteLine($"{Nome} tentou descansar, mas ainda se sente mal.");
        }
        VerificarDoenca();
    }

    private void VerificarDoenca()
    {
        if (Estado == EstadoDeSaude.Saudavel)
        {
            if (energia < 20 && random.Next(0, 100) < 30)
            {
                Estado = EstadoDeSaude.Doente;
                Console.WriteLine($"⚠️ {Nome} começou a se sentir mal!");
            }
            // Outras condições para adoecer podem ser adicionadas aqui
        }
    }

    public void Curar()
    {
        if (Estado == EstadoDeSaude.Doente)
        {
            if (energia >= 15) // Custo de energia para ir ao veterinário
            {
                energia -= 15;
                Estado = EstadoDeSaude.Saudavel;
                Console.WriteLine($"🏥 {Nome} foi ao veterinário e está se sentindo muito melhor!");
            }
            else
            {
                Console.WriteLine($"{Nome} está muito cansado para ir ao veterinário agora.");
            }
        }
        else
        {
            Console.WriteLine($"{Nome} já está saudável e não precisa ir ao veterinário.");
        }
    }

    public void MostrarStatus()
    {
        Console.WriteLine($"\nStatus de {Nome}:");
        Console.WriteLine($"Nível: {Nivel}");
        Console.WriteLine($"Experiencia: {Experiencia}");
        Console.WriteLine($"Fome: {fome}");
        Console.WriteLine($"Felicidade: {felicidade}");
        Console.WriteLine($"Energia: {energia}");
        Console.WriteLine($"Saúde: {Estado}");
        if (conquistas.Count > 0)
        {
            Console.WriteLine("Conquistas:");
            foreach (var conquista in conquistas)
            {
                Console.WriteLine($"- {conquista}");
            }
        }
    }
}