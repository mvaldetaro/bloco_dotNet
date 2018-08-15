using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"C:\Users\Magno\Desktop";
            System.IO.Directory.CreateDirectory(dir);

            

            List<Pessoa> collection = new List<Pessoa>();
            collection.Add(new Pessoa("Magno", "Valdetaro", new DateTime(1984,11,14)));
            collection.Add(new Pessoa("Wagner", "Valdetaro", new DateTime(1987, 10, 14)));

            
            foreach (Pessoa pessoa in collection)
            {
                string nomeArquivo = $"{pessoa.nome}.txt";
                string caminhoArquivo = System.IO.Path.Combine(dir, nomeArquivo.ToLower()); 
                using (StreamWriter fluxoEscrita = new StreamWriter(caminhoArquivo))
                {
                    fluxoEscrita.WriteLine(pessoa.nome);
                    fluxoEscrita.WriteLine(pessoa.sobrenome);
                    fluxoEscrita.WriteLine(pessoa.dt);
                }
            }

            //bool existeArquivo = System.IO.File.Exists($"C:\\Users\\Magno\\Desktop\\{nomeArquivo}");

            /*if (existeArquivo)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        String linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Arquivo não existe.");
            }*/

            Console.ReadKey();
        }
    }

    class Pessoa
    {
        public string nome;
        public string sobrenome;
        public DateTime dt;

        public Pessoa() { }

        public Pessoa(string nome, string sobrenome, DateTime dt) {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.dt = dt;
        }
    }


}
