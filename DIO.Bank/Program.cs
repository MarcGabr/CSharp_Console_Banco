using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>(); 
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                    ListarContas();
                    break;
                    case "2":
                    InserirConta();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    Sacar();
                    break;
                    case "5":
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Thanks for using our services");
        }
        private static string ObterOpcaoUsuario(){
            Console.WriteLine("Insira a informação Desejada");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            return Console.ReadLine();
        }
        private static void InserirConta(){
            Console.WriteLine("Insert new account");
            Console.WriteLine("Enter 1 for Physical Account or 2 for Legal:");
            int entradaTC = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the Client:");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Enter the opening balance:");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a credit:");
            double entradaCredit = double.Parse(Console.ReadLine());
            Conta novaconta = new Conta(tipoConta: (TipoConta)entradaTC, saldo: entradaSaldo, nome: entradaNome, credito: entradaCredit);
            listContas.Add(novaconta);
        }
        private static void ListarContas(){
            Console.WriteLine("Listar Contas");
            if(listContas.Count==0) Console.WriteLine("No account here");
            else{int i = 0;
                foreach(var item in listContas){
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(item.ToString());
                    i++;
                } 
            }
        }
        private static void Sacar(){
            Console.WriteLine("Account number?");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount to be withdrawn");
            double valor = double.Parse(Console.ReadLine());
            listContas[indice].Sacar(valor);
        }
        private static void Depositar(){
            Console.WriteLine("Account number?");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount to be deposited");
            double valor = double.Parse(Console.ReadLine());
            listContas[indice].Depositar(valor);
        }

        private static void Transferir(){
            Console.WriteLine("Account number to source?");
            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("Account number to transfer?");
            int indice2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount to be transfer");
            double valor = double.Parse(Console.ReadLine());
            listContas[indice].Transferir(valor, listContas[indice2]);
        }
        
    }
}

