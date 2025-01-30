namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private int capacidade = 0;

        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int capacidade)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.capacidade = capacidade;
        }

        public void AdicionarVeiculo()
        {
            if (veiculos.Count >= capacidade)
            {
                Console.WriteLine("Erro: O estacionamento está cheio! Nenhum veículo pode ser adicionado.");
                return;
            }

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            // Verifica se há veículos cadastrados
            if (veiculos.Any())
            {
                Console.WriteLine("Carros cadastrados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

                // Solicita a placa do veículo a ser removido
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = int.Parse(Console.ReadLine());

                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                    // Remove o veículo da lista
                    veiculos.Remove(placa);
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados para remover.");
            }
        }

        public void ListarVeiculos()
        {
            ExibirCapacidade();
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {

                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }


        public void ExibirCapacidade()
        {
            Console.WriteLine($"Capacidade total: {capacidade}");
            Console.WriteLine($"Vagas disponíveis: {capacidade - veiculos.Count}");

            if (veiculos.Count >= capacidade)
            {
                Console.WriteLine("⚠️ O estacionamento está cheio!");
            }


        }
    }
}
