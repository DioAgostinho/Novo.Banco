using System;
using System.Collections.Generic;

namespace Novo.Banco
{
    class Program
	{
		static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() != "3")
			{  
				switch (opcaoUsuario)
                { 
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        Cadastro();
                        break;                        

                    case "X":
                        Console.Write("OBRIGADO, por utilizar nossos serviços!!");
                        Environment.Exit(0);
                        break;
                
                    default: 
                        Console.WriteLine("Opção Indísponivel!", opcaoUsuario);
                        Console.ReadLine();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada."); 
                return;
            }   
            else
            { 
                Console.WriteLine("Digite o número de sua conta: ");
                int i = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("BEM VINDO(A), À SEU NOVO BANCO!");
                      
                Conta conta = listContas[i];
                Console.Write(conta);
            }
            string cliente = Opcao();           
            while (cliente.ToUpper() != "X")
            {
                switch (cliente)
                {
                    case "1":
                        Transferir();
                        break;

                    case "2":
                        Depositar();
                        break;

                    case "3": 
                        Sacar();
                        break;

                    case "4": 
                        ListarContas();
                        break;
                    
                    case "C":
                        Console.Clear();
                        break;

                    default: 
                        Console.WriteLine("Opção Indísponivel!", cliente);
                        Console.ReadLine();
                        break;                                           
                }   
                cliente = Opcao();               
            }
            Console.Write("OBRIGADO, por utilizar nossos serviços!!");       
        }
        private static void Depositar()
        {
            Console.WriteLine("Depositar\n");
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor do depoósito");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {
            Console.WriteLine("Sacar");
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void Transferir()
        {
            Console.WriteLine("Transferir\n");
            Console.WriteLine("Digite o número de sua conta");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void Cadastro()
        {
            Console.WriteLine("Cadastrar");
            Console.WriteLine("");
            Console.Write("Digite o tipo de conta \n 1- Pessoa Física \n 2- Pessoa Jurídica ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta Cadastro = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                            saldo : entradaSaldo,
                                                            credito : entradaCredito,
                                                            nome : entradaNome);                                               
            listContas.Add(Cadastro);
            Console.WriteLine();
        }
        private static void ListarContas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.ReadLine();
                return;
            }            
            Console.WriteLine("Listar Contas\n");
            for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}     
            Console.ReadLine();  
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIGITE A OPÇÃO DESEJADA");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Cadastrar");
            Console.WriteLine("3- Entrar");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;  
        }
        private static string Opcao()
        {  
            Console.WriteLine();
            string cliente;          
            Console.WriteLine("\nDIGITE A OPÇÃO DESEJADA:");
            Console.WriteLine();
            Console.WriteLine("1- Transferir");
            Console.WriteLine("2- Depositar");                
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Listar conta");
            Console.WriteLine("c- Limpar tela");
            Console.WriteLine("X- Sair");
            
            return cliente = Console.ReadLine().ToUpper();              
        }
    }
}
