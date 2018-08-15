using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using DataManagement;

namespace ConsoleApp
{
    class Program
    {
        //public static RepoUsers repositorio = new RepoUsers();
        public static RepoUsers repositorio = new RepoUsers();
        public static Actions dataManagment = new Actions();


        static void Main(string[] args)
        {
            int option;

            dataManagment.CreateDir();
            repositorio.Lista = dataManagment.ReadFiles();


            do
            {
                Console.WriteLine("Gerenciador de Aniversários");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Selecione uma das opções abaixo:");
                Console.WriteLine("[1] Pesquisar amigo");
                Console.WriteLine("[2] Adicionar novo amigo");
                Console.WriteLine("[3] Excluir um amigo");
                Console.WriteLine("[4] Atualizar data de aniversário de um amigo");
                Console.WriteLine("[5] Sair\n");
                Console.WriteLine("Aniversariantes do dia:");
                Console.WriteLine("-------------------------------------");

                foreach(User user in repositorio.Aniversariantes())
                {
                    Console.WriteLine($"{user.nome} {user.sobrenome}");
                }

                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Search();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Exit();
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (option != 0);
        }


        private static void Search()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("-------------------------------------");

            if (repositorio.Lista.Count == 0)
            {

                Console.WriteLine("----- Nenhuma pessoa cadastrada -----");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Pressione ENTER para retornar ao menu");
            }
            else
            {
                Console.WriteLine("Digite o nome, ou parte do nome, da pessoa que deseja encontrar:");
                var query = Console.ReadLine();

                List<User> filterList = repositorio.FindUsers(query);

                if (filterList.Count() != 0) {
                    Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas:");
                    int i = 0;
                    foreach (User user in filterList)
                    {
                        Console.WriteLine($"[{i}] {user.nome} {user.sobrenome}");
                        i++;
                    }
                    Console.WriteLine($"\nTotal de amigos encontrados: {filterList.Count()}\n");
                    Console.WriteLine("Digite o número relacionado ao amigo:");
                    var index = Int32.Parse(Console.ReadLine());

                    Console.WriteLine($"Nome Completo: {filterList[index].nome} {filterList[index].sobrenome}");
                    Console.WriteLine("Data de Aniversário: {0}", filterList[index].dtAniversario);

                    int total = Calculator.DiasRestantesAniversario(filterList[index].dtAniversario);

                    Console.WriteLine($"Faltam {total} dias para esse aniversário.");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Pressione ENTER para retornar ao menu");
                } else
                {
                    Console.WriteLine($"Nenhum amigo encontrado.");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Pressione ENTER para retornar ao menu");
                }
            }
      
        }

        private static void Insert()
        {
            Console.Clear();
            int confirm;
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Digite o NOME da pessoa que deseja adicionar:");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o SOBRENOME da pessoa que deseja adicionar:");
            var lastname = Console.ReadLine();
            Console.WriteLine("Digite a DATA DE NASCIMENTO no fomrato dd/MM/yyyy:");
            var birthday = Console.ReadLine();

            User newUser = new User(name, lastname, DateTime.Parse(birthday));

            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome: {newUser.nome} {newUser.sobrenome}");
            Console.WriteLine($"Data de Aniversário: {newUser.dtAniversario}");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");

            confirm = Int32.Parse(Console.ReadLine());

            if (confirm == 1)
            {
                //repositorio.AddUsers(newUser);
                dataManagment.CreateFile(newUser);
                Console.WriteLine("Dados adicionados com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar");
            }
            ReloadData();
        }

        private static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("-------------------------------------");

            if (repositorio.Lista.Count == 0)
            {    
                Console.WriteLine("----- Nenhuma pessoa cadastrada -----");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Pressione ENTER para retornar ao menu");
            }
            else
            {
                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas:");
                
                int i = 0;

                foreach (User user in repositorio.GetUsers())
                {
                    Console.WriteLine($"[{i}] {user.nome} {user.sobrenome}");
                    i++;
                }

                var index = Int32.Parse(Console.ReadLine());
                string fileName = $"{repositorio.Lista[index].nome}.txt";
                dataManagment.DeleteFile(fileName);
                Console.WriteLine("Amigo removido com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar");
                ReloadData();
            }
        }

        private static void Update()
        {
            Console.Clear();
            int confirm;
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas:");
            int i = 0;
            foreach (User user in repositorio.GetUsers())
                {
                Console.WriteLine($"[{i}] {user.nome} {user.sobrenome}");
                i++;
            }
            Console.WriteLine("Digite o número relacionado ao amigo:");
            var index = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nova DATA DE NASCIMENTO no formato dd/MM/yyyy:");
            var birthday = Console.ReadLine();

            User newUser = repositorio.UserUpdate(DateTime.Parse(birthday), repositorio.Lista[index]);

            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome: {newUser.nome} {newUser.sobrenome}");
            Console.WriteLine($"Data de Aniversário: {newUser.dtAniversario}");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");

            confirm = Int32.Parse(Console.ReadLine());

            if (confirm == 1)
            {
                string fileName = $"{repositorio.Lista[index].nome}.txt";
                dataManagment.UpdateFile(fileName, newUser);
                Console.WriteLine("Dados atualizados com sucesso!");
                Console.WriteLine("Pressione ENTER para continuar");
            }
            ReloadData();
        }

        

        private static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Mas já vai embora? \nPressione qualquer tecla para encerrar a aplicação.");
            Console.ReadKey();
            Environment.Exit(0);
        }


        private static void ReloadData() {
            repositorio.Lista = dataManagment.ReadFiles();
        }

    }
}
