using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        struct lancamento
        {
            public string descricao, data;
            public double valor;
            public char tipo;
        }

        static void incluirLancamento(ref int n, ref lancamento[] extrato, ref double saldoFinal, ref double saldoAnterior)
        {
            lancamento l;
            Console.Write("Data: ");
            l.data = Console.ReadLine();
            Console.Write("Descrição: ");
            l.descricao = Console.ReadLine();
            Console.Write("Valor: ");
            l.valor = double.Parse(Console.ReadLine());
            Console.Write("Tipo: ");
            l.tipo = char.Parse(Console.ReadLine());

            extrato[n] = l;
            n++;

            if (l.tipo.ToString().ToUpper() == "C")
                saldoFinal = saldoFinal + l.valor;
            else
                saldoFinal = saldoFinal - l.valor;

            if (n == 10) // Se houver 10 lançamentos
            {
                // Exclui os 5 mais antigos e move os 5 mais recentes para as posições iniciais do vetor
                excluirLancamentosAntigos(ref extrato, ref saldoAnterior, ref n);
            }  
        }

       

         static void excluirLancamentosAntigos(ref lancamento[] extrato, ref double saldoAnterior, ref int n)
        {
            for (int i = 0; i < 5; i++) // Esse for soma os 5 últimos saldos
                saldoAnterior = saldoAnterior + extrato[i].valor;
             
            for (int i = 0; i < 5; i++)
                extrato[i] = extrato[i + 5];

                n = 5; // Essa variável recebe o número de lançamentos, para que quando chegar em 10 novamente, exclua os 5 últimos
        
        }

        static void exibirExtrato(ref lancamento[] extrato, int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("{0} - {1} -  R$ {2}  Tipo: {3}", extrato[i].data, extrato[i].descricao, extrato[i].valor, extrato[i].tipo);
            }
        }

        static void Main(string[] args)
        {
            lancamento[] extrato = new lancamento[10];
            int n = 0, opcaoMenu;
            // A variável N é um contador de quantos lançamentos há 

            double saldoAnterior = 0, saldoFinal = 0;

            Console.WriteLine("Bem Vindo(a) ao terminal do Banco C#!");
            do
            {
                Console.WriteLine("Por gentileza, selecione uma opção: ");
                Console.WriteLine("(1) - Incluir Lançamento");
                Console.WriteLine("(2) - Exibir Extrato");
                Console.WriteLine("(3) - Encerrar");

                opcaoMenu = int.Parse(Console.ReadLine());
                
                //A variável opcaoMenu contém o número da instrução que o usuário quer usar

                switch (opcaoMenu)
                {
                    case 1: // Usuário irá incluir um novo lançamento
                        Console.Clear();
                        incluirLancamento(ref n, ref extrato, ref saldoFinal, ref saldoAnterior);
                        Console.Clear();
                        Console.WriteLine("Lançamento incluído!");
                        break;
                    case 2: // Mostrará todos últimos lançamentos, limitando apenas aos 10 últimos
                        Console.Clear();
                        exibirExtrato(ref extrato, n);
                        Console.WriteLine(("Saldo Final: {0}"), saldoFinal);
                        break;
                    case 3: // Encerra o algoritmo
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nossos serviços");
                        break;
                }
            } while (opcaoMenu != 3);          
        }
    }
}
