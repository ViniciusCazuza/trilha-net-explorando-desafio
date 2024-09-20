using Newtonsoft.Json;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {


                if (hospedes.Count() <= Suite.Capacidade)
                {

                    Hospedes = hospedes;
                    string hospedesSerializados = JsonConvert.SerializeObject(Hospedes, Formatting.Indented);
                    File.WriteAllText("Arquivos/hospedes.json", hospedesSerializados);
                    
                }
                else
                {   
                    try 
                    {
                        File.ReadAllText("");
                    }
                    catch (Exception)
                    {
                        throw new Exception("Capacidade de hospedes excedida");
                    }

                }
        }
    

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public void ObterQuantidadeHospedes()
        {
            Console.WriteLine($"Você tem {Hospedes.Count()}º Hóspede(s): \n\nSuite: {Suite.TipoSuite}");
            foreach (Pessoa item in Hospedes)
            {
            Console.WriteLine($"Nome: {item.NomeCompleto}");
            }
        }

        public void CalcularValorDiaria()
        {
            decimal calculo = DiasReservados * Suite.ValorDiaria;
            decimal valor = calculo;
            decimal porcentagem = (10 * valor) / 100M;

            if (DiasReservados >= 10)
            {
                valor = valor - porcentagem;
                Console.WriteLine( 
                    
                    $"\nVocê acabou de Ganha 10% de Desconto por ter Reservado mais de 10 Dias \n" + 
                    $"Valor total a ser pago pelos {DiasReservados} dias Reservados: {valor:C} \n "
                
                );
            }
            else
            {
                Console.WriteLine($"Valor total a ser pago pelos {DiasReservados} dias Reservados: {valor:C} \n");
            }

        }
    }
}
