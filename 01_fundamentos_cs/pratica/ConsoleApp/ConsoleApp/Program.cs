using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"C:\Users\Magno\Desktop";
            System.IO.Directory.CreateDirectory(dir);

            string nomeArquivo = "meu_arquivo.txt";
            string caminhoArquivo = System.IO.Path.Combine(dir, nomeArquivo);

            //var fluxoArquivo = System.IO.File.Create(caminhoArquivo);

            using (var fluxoEscrita = new StreamWriter(caminhoArquivo))
            {
                for (var i = 1; i <= 100; i++)
                {
                    fluxoEscrita.WriteLine($"Linha {i}");
                }
            }

            bool existeArquivo = System.IO.File.Exists($"C:\\Users\\Magno\\Desktop\\{nomeArquivo}");

            if (existeArquivo)
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
            }

            Console.ReadKey();
        } 
    }
}
