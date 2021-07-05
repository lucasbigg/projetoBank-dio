using System;

namespace projetoDioBank
{
    public class Conta
    {
        //Atributos
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //Metodos
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Sacar
        public bool Sacar(double valorSaque)
        {
            //Validar se o saldo é suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo é insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        //Depositar
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //Tranferir
        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            return retorno;
        }
    }
}