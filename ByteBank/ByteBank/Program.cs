

using ByteBank.Entities;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Bytebank
{
    public class Program
    {
        static void MostrarMenu()
        {
            Console.WriteLine("Seja bem-vindo ao ByteBank, por favor siga as instruções abaixo.");
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("Este é o Menu Principal do ByteBank, escolha uma opção para seguir.");
            Console.WriteLine("1 - Cadastrar um usuário.");
            Console.WriteLine("2 - Listar usuários registrados.");
            Console.WriteLine("3 - Deletar informações de usuário.");
            Console.WriteLine("0 - Sair do ByteBank.");
        }

        static void CadastroDeUsuario(List<User> users)
        {

            User cadastro = new User();
            Console.Write("Nome: ");
            cadastro.name = Console.ReadLine();
            Console.Write("CPF: ");
            cadastro.cpf = Console.ReadLine();
            Console.Write("Senha: ");
            cadastro.password = Console.ReadLine();
            Console.Write("Valor do primeiro depósito: ");
            cadastro.saldo = double.Parse(Console.ReadLine());
            users.Add(cadastro);

        }

        static void ListarCadastrosDeUsuario(List<User> users)
        {
            for(int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"Nome: {users[i].name} | CPF: {users[i].cpf} | Saldo: {users[i].saldo}");
            }
        }


        public static void Main(string[] args)
        {

            List<User> users = new List<User>();
           
                
            

            int opção;
            

            do
            {
                MostrarMenu();
                opção = int.Parse(Console.ReadLine());

                Console.WriteLine("__________________________________________________________");

                switch (opção)
                {
                    case 0:
                        Console.WriteLine("Finalizando o ByteBank, até a próxima!");
                        break;
                    case 1:
                        CadastroDeUsuario(users);
                        break;
                    case 2:
                        ListarCadastrosDeUsuario(users);
                        break;
                    
                }
            } while(opção != 0);
        }
    }
}
