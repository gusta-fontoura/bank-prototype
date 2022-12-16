using System.Runtime.CompilerServices;

namespace BancoDoGustavo
{
    public class Program
    {
        static void mostrarMenu()
        {
            Console.WriteLine("Digite o número para a opção desejada.");
            Console.WriteLine("1 - Cadastrar usuário.");
            Console.WriteLine("2 - Buscar informações do usuário.");
            Console.WriteLine("3 - Deletar usuário.");
            Console.WriteLine("0 - Encerrar programa.");
            Console.Write("Digite aqui: ");
        }

        static void cadastraInformacaoDoUsuario(List<string> nome, List<string> cpf)
        {
            Console.WriteLine("Cadastre as informações");
            Console.Write("Nome completo: ");
            nome.Add(Console.ReadLine());
            Console.Write("CPF: ");
            cpf.Add(Console.ReadLine());
            /*Console.WriteLine("Selecione o tipo de conta do usuário?");
            Console.Write("1 - Conta corrente ou ");
            Console.Write("2 - Conta poupança. ");
            int tipoDaConta = int.Parse(Console.ReadLine());*/
            //criar um objeto para conta poupança e conta corrente;
        }
        static void buscaInformacaoDoUsuario(List<string> nome, List<string> cpf)
        {
            Console.WriteLine("Buscando Usuário...");

            for (int i = 0; i < cpf.Count; i++)
            {
                Console.WriteLine($"Nome:{nome[i]} | CPF:{cpf[i]}");
            }
            
        }
        public static void Main(string[] arg)

        {

            List<string> nome = new List<string>();
            List<string> cpf = new List<string>();

            int opção;
            do
            {
                mostrarMenu();
                opção = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------");

                switch (opção)
                {
                    case 0:
                        Console.WriteLine("Encerrando programa...");
                        break;
                    case 1:
                        cadastraInformacaoDoUsuario(nome, cpf);
                        Console.WriteLine("Cadastro concluído!");
                        break;
                    case 2:
                        buscaInformacaoDoUsuario(nome, cpf);
                        break;
                }
                Console.WriteLine("-----------------------");
            } while (opção != 0);
        }
    }
}
