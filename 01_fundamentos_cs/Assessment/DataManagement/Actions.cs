using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lib;

namespace DataManagement
{
    public class Actions
    {

        private const String diretorio = @"C:\Users\Public\AssessmentCS";



        public void CreateDir(String dir = diretorio)
        {
            Directory.CreateDirectory(dir);
        }




        public void CreateFile(User pessoa, String dir = diretorio)
        {
            string nomeArquivo = $"{pessoa.nome}.txt";
            string caminhoArquivo = System.IO.Path.Combine(dir, nomeArquivo.ToLower());
            using (StreamWriter fluxoEscrita = new StreamWriter(caminhoArquivo))
            {
                fluxoEscrita.WriteLine(pessoa.nome);
                fluxoEscrita.WriteLine(pessoa.sobrenome);
                fluxoEscrita.WriteLine(pessoa.dtAniversario);
            }
        }




        public List<User> ReadFiles(String dir = diretorio)
        {
            string[] files = Directory.GetFiles(dir);
            List<User> repoUsers = new List<User>();

            foreach (string file in files)
            {
                string[] userData = new string[3];
                string caminhoArquivo = System.IO.Path.Combine(dir, file);

                try
                {
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        for (int i = 0; i < userData.Length; i++)
                        {
                            userData[i] = sr.ReadLine();
                        }
                    }

                    User newUser = new User(userData[0], userData[1], DateTime.Parse(userData[2]));

                    repoUsers.Add(newUser);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return repoUsers;
        }




        public void DeleteFile(string fileName, String dir = diretorio)
        {
            string caminhoArquivo = Path.Combine(dir, fileName);

            if (File.Exists(caminhoArquivo))
            {
                try
                {
                    File.Delete(caminhoArquivo);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }




        public void UpdateFile(string fileName, User userData, String dir = diretorio)
        {
            string caminhoArquivo = Path.Combine(dir, fileName);
            using (StreamWriter fluxoEscrita = new StreamWriter(caminhoArquivo))
            {
                fluxoEscrita.WriteLine(userData.nome);
                fluxoEscrita.WriteLine(userData.sobrenome);
                fluxoEscrita.WriteLine(userData.dtAniversario);
            }
        }


    }
}