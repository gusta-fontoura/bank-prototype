using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities
{
    public class User
    {
        public string? name;
        public string? password;
        public string? cpf;
        public double saldo;



        // metodos
        public void MostrarUsuario()
        {
            Console.WriteLine( "_______________________________________________" );
            Console.WriteLine("Usuário Cadastrado!");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Nome: " + name + " | CPF: " + cpf + " | Saldo: " + saldo);
            Console.WriteLine("_______________________________________________");
        }

        public void SacarValor(double a , double b)
        {
            a = saldo;

            if(a <= 0)
            {
                Console.WriteLine("Saldo indisponível para transação");
            }else if ( b > a )
            {
                Console.WriteLine("Saldo indisponível para transação");
            } else
            {
                Console.Write("Insira o valor que deseja sacar:");
                b = double.Parse(Console.ReadLine());
                double newSaldo = a - b;
                Console.WriteLine("Saque realizado com sucesso.");
                Console.WriteLine($"Saldo disponível: {newSaldo}");
            }
        }

      


    }

    
}
