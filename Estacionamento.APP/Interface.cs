using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.APP
{
    /// <summary>
    /// Constroi as interfaces do sistema
    /// </summary>
    public static class Interface
    {
        public static void Continues()
        {
            Console.WriteLine("PRESSIONE <<ENTER>> PARA CONTINUAR...");
            Console.ReadLine();
        }
        public static void Start()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("      Bem vindo ao estacionamento");
            Console.WriteLine(new string('=', 40));
        }
        public static void Stop()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("      Encerrando sistema...");
            Console.WriteLine(new string('=', 40));
        }
        public static void Error(string msg)
        {
            Console.WriteLine($"\u001b[31m[ERROR] - {msg}\u001b[0m");
            Console.WriteLine(new string('-', 40));
            Continues();
        }
        public static void Menu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1 - Cadastrar um veiculo");
            Console.WriteLine("2 - Remover um veiculo");
            Console.WriteLine("3 - Listar os veiculos");
            Console.WriteLine("4 - Encerrar");
            Console.WriteLine(new string('*', 40));
        }
        public static void ListItens(string[] itens)
        {
            Console.WriteLine(new string('*', 40));
            if (itens.Length == 0)
                Console.WriteLine("Não há veiculos para listar");
            else
                for (int i = 1; i <= itens.Length; i++)
                    Console.WriteLine($"{i} - {itens[i - 1]}");
            Console.WriteLine(new string('*', 40));
        }
        public static void CloseCashier(decimal price, string identification)
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("Nota - Conta fechada");
            Console.WriteLine($"Veiculo: {identification}");
            Console.WriteLine("Valor à pagar: R$" + price.ToString("N2"));
            Console.WriteLine(new string('*', 40));
        }
    }
}
