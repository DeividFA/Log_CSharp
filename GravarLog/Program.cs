using GravarLog.Controller;
using System;

namespace GravarLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string NomeArquivoLog;
            string unidade = @"C:\";


            NomeArquivoLog = DateTime.Now.ToString();
            NomeArquivoLog = NomeArquivoLog.Replace('/', '_').Replace(':', '_');
            NomeArquivoLog = unidade + @"Temp\LOG\Applicacao\Log-" + NomeArquivoLog + ".txt";

            Console.WriteLine("Criando Objeto.");
            //GravarLog log = new GravarLog(NomeArquivoLog);
            var gravarlog = new GravarLogController(new GravarLog(NomeArquivoLog));

            Console.WriteLine("Chamando metodo de inserir texto e salvando no arquivo de log.");
            // log.SalvarLog("Teste de Log");
            gravarlog.SalvarLog("Teste de log injeção de dependencia");

            Console.WriteLine("Chamando metodo de controle para limpar logs antigos");
            // log.DeleteLog(-1); // numero de dias para excluir o arquivo sendo: 0 - nunca excluir, > 0 dias que vao ficar
            gravarlog.DeleteLog(1);
          //  Console.WriteLine("Apontando a referencia do objeto pra null para GC retirar da memoria");
          //  log = null;

            Console.WriteLine("Programa encerrado tecle enter para finalizar");
            Console.ReadLine();
        }
    }
}
