using System;
namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta{get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque){
            if(this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposit){
            this.Saldo += valorDeposit;
            Console.WriteLine("Saldo atual {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valor, Conta contaDestino){
            if(this.Sacar(valor)){
                contaDestino.Depositar(valor);
            }
        }
        public override string ToString(){
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        } 

    }
}