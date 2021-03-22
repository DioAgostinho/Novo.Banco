using System;

namespace Novo.Banco
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo Insuficiente");
                Console.WriteLine();
                return false;                
            } 
            this.Saldo -= valorSaque;

            Console.WriteLine ("{0} Seu saldo atual é de: R$ {1}", this.Nome, this.Saldo);
            Console.WriteLine();
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine ("{0} seu Saldo Atual é de: R$ {1}", this.Nome, this.Saldo);
            Console.WriteLine();
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar (valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }
        
        public override string ToString()
        {
            Console.WriteLine();
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}
