using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{

    interface IPessoas
    {
        void AddUsers(User newUser);
        List<User> FindUsers(string query);
    }

    /// <summary>
    /// Classe que representa a Pessoa
    /// </summary>
    public class User
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dtAniversario { get; set; }


        public User(string strNome, string strSobrenome, DateTime datAniversario)
        {
            nome = strNome;
            sobrenome = strSobrenome;
            dtAniversario = datAniversario;
        }
    }

    /// <summary>
    /// Classe que contém o metodo apra calcular os dias restantes para o aniversário.
    /// </summary>
    public class Calculator
    {
        public static int DiasRestantesAniversario(DateTime dt)
        {
            int anoAtual = DateTime.Today.Year;

            var dataInicial = DateTime.Today;
            var dataFinal = $"{dt.Day}/{dt.Month}/{anoAtual}";

            return (DateTime.Parse(dataFinal).Subtract(dataInicial)).Days;
        }
    }

    /// <summary>
    /// Classe que representa o Repositórios de pessoas
    /// </summary>

    public sealed class RepoUsers : IPessoas
    {

        private static List<User> lista = new List<User>();

        public List<User> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        private static List<User> BuildList()
        {
            return lista;
        }

        /// <summary>
        ///  Método para inserir uma pessoa na "base de dados"
        /// </summary>
        /// <param name="newUser"></param>

        public void AddUsers(User newUser)
        {
            lista.Add(newUser);

        }

        /// <summary>
        /// Método para buscar pessoas pelo nome
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public List<User> FindUsers(string query)
        {

            List<User> filterList = new List<User>();
            List<User> users = BuildList();
            var result = from user in users where user.nome.ToLower().Contains(query.ToLower()) orderby user.nome select user;
            int i = 0;

            foreach (User user in result)
            {
                filterList.Add(user);
                i++;
            }

            return filterList;
        }


        public List<User> GetUsers() => Lista;

        public User UserUpdate(DateTime newDateTime, User user)
        {
            user.dtAniversario = newDateTime;

            return user;
        }

        public List<User> Aniversariantes()
        {
            DateTime dt = DateTime.Now;
            List<User> newList = new List<User>();

            foreach (User user in Lista)
            {
                if (user.dtAniversario.Day == dt.Day && user.dtAniversario.Month == dt.Month) 
                    newList.Add(user);
            }

            return newList;
        }

    }






    public sealed class RepoPessoas : IPessoas
    {

        private static IDictionary<string, User> lista = new Dictionary<string, User>();
        public static IDictionary<string, User> ListaPessoas
        {
            get { return lista; }
            set { lista = value; }
        }
        private static IDictionary<string, User> BuildList()
        {
            return lista;
        }

        public void AddUsers(User newUser)
        {
            lista.Add(newUser.nome, newUser);
        }

        public List<User> FindUsers(string query)
        {

            IDictionary<string, User> filterList = new Dictionary<string, User>();
            IDictionary<string, User> users = BuildList();

            var result = from user in users where user.Key.Contains(query) orderby user.Key select user;

            int i = 0;

            foreach (KeyValuePair<string, User> item in result)
            {
                filterList.Add(item.Key, item.Value);
                i++;
            }

            return filterList.Values.ToList();
        }
    }
    }

