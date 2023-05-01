using GravarLog.Interface;
using System;
using System.IO;

namespace GravarLog
{
    public class GravarLogs : IGravarLog
    {
        private string _path { get; }

        public GravarLogs(string path)
        {
            _path = !string.IsNullOrEmpty(path) ? path : throw new ArgumentNullException("Path is null");
        }

        public void SalvarLog(string linha)
        {
            // a linha sera salva como no exemplo:  dd/mm/yyyy HH:mm:ss: linha
            if (FileLog())
            {
                GravarLinha(linha);
            }
        }

        private bool FileLog()
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(_path)) == true)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_path));
                }
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e.ParamName);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private void GravarLinha(string linha)
        {
            using StreamWriter sw = new(_path, true);
            Console.WriteLine("O log gravado foi: " + DateTime.Now.ToString() + ": " + linha);
            sw.WriteLine(DateTime.Now.ToString() + ": " + linha);
            sw.Close();
        }

        public void DeleteLog(int numberDaysNotExclusion)
        {
            int qtdeArqExcluidos = -1; // criado apenas para fins demonstrativos
            
            if (numberDaysNotExclusion > 0)
            {
                try
                {
                    FileInfo[] Arquivos = ((DirectoryInfo)new(Path.GetDirectoryName(_path))).GetFiles(Path.GetExtension(_path));

                    foreach (FileInfo fileinfo in Arquivos)
                    {
                        Console.Write("Arquivo: " + fileinfo.Name + " Data Criação: " + File.GetCreationTime(fileinfo.FullName));

                        if (File.GetCreationTime(fileinfo.FullName) < DateTime.Now.AddDays(-numberDaysNotExclusion))
                        {
                            File.Delete(fileinfo.FullName);
                            Console.WriteLine(" Excluido as: " + DateTime.Now);
                            qtdeArqExcluidos++;
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new DirectoryNotFoundException(e.Message);
                }
                catch (FileNotFoundException e)
                {
                    throw new FileNotFoundException(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Configurado para não exclusão.");
            }

            if(qtdeArqExcluidos == 0)
            {
                Console.WriteLine("Não foram encontrados arquivos a serem excluidos!.");
            }
            else if(qtdeArqExcluidos > 0)
            {
                Console.WriteLine("Quantidade excluida: {0} arquivo(s)", qtdeArqExcluidos);
            }

        }
    }
}
