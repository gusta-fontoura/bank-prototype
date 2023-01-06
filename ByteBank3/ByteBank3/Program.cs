using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace ByteBank
{
    public class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentarConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine("Digite o CPF para buscar:");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentarConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            // saldos.Sum(); ou .Agregatte(0.0, (x, y) => x + y)
        }

        static void ApresentarConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void MenuSecundario()
        {
            Console.WriteLine("1 - Deposito.");
            Console.WriteLine("2 - Saque.");
            Console.WriteLine("3 - Transferência.");
            Console.WriteLine("0 - Retornar ao menu principal.");
        }

        static void Saque( List<double> saldos, List<string> cpfs, List<string> senhas)
        {
                int i;
                do
                {

                    Console.Write("Digite o seu CPF para fazer o login: ");
                    string cpfValidado = Console.ReadLine();
                    i = cpfs.FindIndex(cpf => cpf == cpfValidado);
                    if (i == -1)
                    {
                        Console.WriteLine("CPF inválido.");
                    }
                }
                while (i == -1);

                string senhaValidada;
                do
                {
                    Console.Write("Digite sua senha:");
                    senhaValidada = Console.ReadLine();
                    if (senhaValidada != senhas[i])
                    {
                        Console.Write("Senha inválida.");
                    }
                }


                while (senhaValidada != senhas[i]);

                string contaValidada = senhas[i];

                Console.Write("Digite o valor a que deseja sacar: ");
                double valor = double.Parse(Console.ReadLine());
                saldos[i] -= valor;
                Console.WriteLine("Esses são os dados depois do saque:");
                Console.WriteLine();
                Console.WriteLine(saldos[i]);
                Console.WriteLine();


         }

        static void Deposito( List<double> saldos, List<string> cpfs, List<string> senhas)
        {
                
                int i;
                do
                {

                    Console.Write("Digite o seu CPF para fazer o login: ");
                    string cpfValidado = Console.ReadLine();
                    i = cpfs.FindIndex(cpf => cpf == cpfValidado);
                    if (i == -1)
                    {
                        Console.WriteLine("CPF inválido.");
                    }
                }
                while (i == -1);

                string senhaValidada;
                do
                {
                    Console.Write("Digite sua senha:");
                    senhaValidada = Console.ReadLine();
                    if (senhaValidada != senhas[i])
                    {
                        Console.Write("Senha inválida.");
                    }
                }


                while (senhaValidada != senhas[i]);

                string contaValidada = senhas[i];

                Console.Write("Digite o valor a que deseja depositar: ");
                double valor = double.Parse(Console.ReadLine());
                saldos[i] += valor;
                Console.WriteLine("Esses são os dados depois do deposito:");
                Console.WriteLine();
                Console.WriteLine(saldos[i]);
                Console.WriteLine();


        }

        static void Transferir(List<string>cpfs, List<string>senhas, List<double>saldos, List<string>titulares)
        {
            int i, j;
            do
            {

                Console.Write("Digite o seu CPF para fazer o login: ");
                string cpfValidado = Console.ReadLine();
                i = cpfs.FindIndex(cpf => cpf == cpfValidado);
                if (i == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
            }
            while (i == -1);

            string senhaValidada;
            do
            {
                Console.Write("Digite sua senha:");
                senhaValidada = Console.ReadLine();
                if (senhaValidada != senhas[i])
                {
                    Console.Write("Senha inválida.");
                }
            }


            while (senhaValidada != senhas[i]);

            string contaValidada = senhas[i];

            do
            {
                Console.Write("Informe o CPF para realizar a transferência: ");
                string cpfTransferencia = Console.ReadLine();
                j = cpfs.FindIndex(cpf => cpf == cpfTransferencia);

                if (j == -1)
                {
                    Console.WriteLine("CPF inválido.");
                }
                else if (j == i)
                {
                    Console.WriteLine("Impossível realizar transferência entre a mesma conta");

                }
            } while (j == -1 || j == i);
            Console.WriteLine();

            Console.Write("Informe o valor da transferência.");
            double value = double.Parse(Console.ReadLine());
            saldos[i] -= value;
            saldos[j] += value;

            Console.WriteLine("Transferência realizada com sucesso.");
            Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            Console.WriteLine($"CPF = {cpfs[j]} | Titular = {titulares[j]} | Saldo = R${saldos[j]:F2}");
        }



            public static void Main(string[] args)
            {

                Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

                List<string> cpfs = new List<string>();
                List<string> titulares = new List<string>();
                List<string> senhas = new List<string>();
                List<double> saldos = new List<double>();

                int option;

                do
                {
                    ShowMenu();
                    option = int.Parse(Console.ReadLine());

                    Console.WriteLine("-----------------");

                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("Estou encerrando o programa...");
                            break;
                        case 1:
                            RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                            break;
                        case 2:
                            DeletarUsuario(cpfs, titulares, senhas, saldos);
                            break;
                        case 3:
                            ListarTodasAsContas(cpfs, titulares, saldos);
                            break;
                        case 4:
                            ApresentarUsuario(cpfs, titulares, saldos);
                            break;
                        case 5:
                            ApresentarValorAcumulado(saldos);
                            break;
                        case 6:
                            MenuSecundario();
                            int optionMenu2 = int.Parse(Console.ReadLine());



                            Console.WriteLine("-----------------");

                            switch (optionMenu2)
                            {
                                case 0:
                                    ShowMenu();
                                    Console.WriteLine("Retornando ao menu principal...");
                                    break;
                                case 1:
                                    Deposito(saldos, cpfs, senhas);
                                    break;
                                case 2:
                                    Saque(saldos, cpfs, senhas);
                                    break;
                                case 3:Transferir(cpfs, senhas, saldos, titulares);

                                    break;
                            }
                            break;
                    }

                    Console.WriteLine("-----------------");

                } while (option != 0);



            }

        }
    }

        


