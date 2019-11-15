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

        static void incluirLancamento(ref int n, lancamento[] extrato, ref double saldoFinal, ref double saldoAnterior)
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

            if (n == 10)
            {
                for (int i = 0; i < 5; i++)
                    saldoAnterior = saldoAnterior + extrato[i].valor;
                for (int i = 0; i < 5; i++)
                    extrato[i] = extrato[i + 5];
                n = 5;
            }  
        }

       
        /*Consegui implementar a lógica de remoção dos 5 ultimos lançamentos, porém não consegui
         fazer na forma de procedimento, tem algo errado na hora de passar os parâmentros*/

        /* static void excluirLancamentosAntigos(lancamento [] extrato, ref double saldoAnterior)
        {
            /* Este for() soma os valores contidos nos 5 lançamentos mais antigos que serão removidos pelo
            procedimento e os armazena na variável saldoAnterior, semelhante ao que ocorre nos bancos  

            for (int i = 0; i < 5; i++)
                saldoAnterior = saldoAnterior + extrato[i].valor;

            /* Este for() transfere o conteúdo dos 5 lançamentos mais novos para as posições dos 5 lançamentos mais
             antigos, liberando o espaço necessário para a inclusão de novos lançamentos
             A lógica utilizada foi a seguinte:
             índice    0  1  2  3  4  5
             vetor    [1  2  3  4  5  6]              
             Neste caso, é necessário que (Para apagar os 3 mais antigos) os três mais novos ocupem as posições
             dos 3 ultimos, fazendo-se assim:
             v[0] = v[3]
             v[1] = v[4]
             v[2] = v[5]      
             
            for (int i = 0; i < 5; i++)
                extrato[i] = extrato[i + 5];

            // O valor de n retorna a 5 pois mostra que existem 5 lançamentos no extrato, sendo assim, ao se incluir mais
            // 5 lançamentos (chegando a 10) o procedimento será chamado novamente.
            
        }*/

        static void exibirExtrato(lancamento[] extrato, int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("{0} - {1} -  R$ {2}  Tipo: {3}", extrato[i].data, extrato[i].descricao, extrato[i].valor, extrato[i].tipo);
            }
        }

        static void Main(string[] args)
        {
            lancamento x;
            lancamento[] extrato = new lancamento[10];
            int n = 0, opcaoMenu;
            double saldoAnterior = 0, saldoFinal = 0;

            Console.WriteLine("Bem Vindo(a) ao terminal do Banco C#!");
            do
            {
                Console.WriteLine("Por gentileza, selecione uma opção: ");
                Console.WriteLine("(1) - Incluir Lançamento");
                Console.WriteLine("(2) - Exibir Extrato");
                Console.WriteLine("(3) - Encerrar");
                opcaoMenu = int.Parse(Console.ReadLine());

                switch (opcaoMenu)
                {
                    case 1:
                        Console.Clear();
                        incluirLancamento(ref n, extrato, ref saldoFinal, ref saldoAnterior);
                        Console.Clear();
                        Console.WriteLine("Lançamento incluído!");
                        break;
                    case 2:
                        Console.Clear();
                        exibirExtrato(extrato, n);
                        Console.WriteLine(("Saldo Final: {0}"), saldoFinal);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nossos serviços");
                        break;
                }
            } while (opcaoMenu != 3);

            


            

            

        }
    }
}
