using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> Hospedes = new List<Pessoa>();

string nome = "";
int cont = 0, pessoas = 1;

        Console.WriteLine(
                        
                        "Olá bem-Vindo ao Hotel dos seus Sonhos \n" +
                        "Por gentileza, a reserva é para quantas pessoas ? \n\n"
                        
                        );

        pessoas = Convert.ToInt32(Console.ReadLine());

        if (pessoas <= 3)
        {

            Console.Clear();
            Console.WriteLine($"Aqui estão as Suites ideal para você, escolha a sua Suite: \n\n" +

                            "DISPONIVEL: \n" +
                            "Suite: Premium \n" +
                            "Capacidade: 3 Pessoas \n" +
                            $"Valor da Diaria: R$ 30,00");
            


        }
        else
        {
            Console.WriteLine("Não há nenhuma Suite Vaga para essa quantidade de Pessoas, sinto muito");
            Environment.Exit(0);
        }
        Console.ReadKey();


    
    while(cont < pessoas )
    {
        
        Console.Clear();
        Console.WriteLine(
                        
                        $"{Hospedes.Count() + 1}º Cadastro:  \n" +
                        "Vamos fazer a sua reserva, por gentileza me dia o Primeiro Nome: \n\n"
                        
                        );

        nome = Console.ReadLine();

        Console.Clear();
        Console.WriteLine(
                        
                        $"{Hospedes.Count() + 1}º Cadastro: \n" +
                        $"{nome} agora por gentileza me dia o Sobrenome: \n\n"
                        
                        );

        string sobrenome = Console.ReadLine();

    Pessoa pessoa = new Pessoa(nome, sobrenome);
    Hospedes.Add(pessoa);
    cont++;

    }

        Console.Clear();
        Console.WriteLine($"Quantos dias você pretende ficar Hospedado(a) ? \n");

        int diasReservados = Convert.ToInt32(Console.ReadLine());
        

    // Cria a suíte
    Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);

    // Cria uma nova reserva, passando a suíte e os hóspedes
    Reserva reserva = new Reserva(diasReservados);
   
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(Hospedes);

    // Exibe a quantidade de hóspedes e o valor da diária
Console.Clear();
reserva.ObterQuantidadeHospedes();
reserva.CalcularValorDiaria();