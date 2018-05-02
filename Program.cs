using System;
using System.IO;
using System.Linq;

namespace RenomearArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() == 0)
                Console.WriteLine("Nenhuma opção foi informada! Indique o diretório (-d), filtro (-t) e prefixo (-n)");
            else
            {
                var diretorio = String.Empty;
                var filtro = "*";
                var prefixo = String.Empty;

                for(var i = 0; i < args.Count(); i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "-d":
                            diretorio = args[++i];
                            break;
                        case "-t":
                            filtro = args[++i];
                            break;
                        case "-n":
                            prefixo = args[++i];
                            break;
                        default:
                            Console.WriteLine($"Opção {args[i]} inválida!");
                            Environment.Exit(1);
                            break;
                    }
                }

                Renomear(diretorio, filtro, prefixo);  
            }
            
        }

        static void Renomear(string diretorio, string filtro, string prefixo){

            Console.WriteLine("Arquivos renomeados:");
            foreach(var arq in Directory.GetFiles(diretorio, filtro))
            {
                var novoArquivo = Path.Combine(Path.GetDirectoryName(arq), String.Format("{0} - {1}", prefixo, Path.GetFileName(arq)));
                File.Move(arq, novoArquivo);
                Console.WriteLine(novoArquivo);
            }
        }
    }
}
