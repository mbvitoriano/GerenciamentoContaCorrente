# Segundo Trabalho Prático de Algorítmos e Técnicas de Programação
Autores: Matheus Braga Zanon Vitoriano e Igor Theodoro Oliveira


O trabalho consiste em:
Faça um programa em C# que simule o gerenciamento do extrato de uma conta corrente em um banco. 
O extrato deverá ser armazenado em um vetor de tamanho 10 (apenas os últimos 10 lançamentos serão mantidos) e cada lançamento será composto de: 
1. Dia e mês da data; 
2. Descrição; 
3. Valor; 
4. Tipo (débito ou crédito). 

O programa deverá exibir ao usuário um menu com as seguintes opções:
1. Incluir lançamento; 
2. Exibir extrato;
3. Encerrar. Instruções 

1. Como o vetor é uma estrutura estática e serão mantidos apenas os últimos 10 lançamentos, assim que a inclusão de um novo lançamento causar a ocupação de todo o vetor (10 lançamentos presentes no extrato), os 5 lançamentos mais antigos deverão ser excluídos; 
2. Cada lançamento deverá ser armazenado na forma de um registro (Struct); 
3. O programa deverá manter os valores do saldo anterior (saldo antes dos lançamentos presentes no extrato) e do saldo final (saldo após os lançamentos presentes no extrato);
4. O menu deve ser exibido indefinidamente, até que a opção 3 seja escolhida.
