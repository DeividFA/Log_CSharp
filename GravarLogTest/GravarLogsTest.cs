using System;
using Xunit;
using GravarLog;
using System.IO;
using System.Collections.Generic;

namespace GravarLogTest
{
    public class GravarLogsTest
    {
        [Fact]     
        public void CriarObjClassGravarLogComPathVazio()
        {
            Assert.Throws<ArgumentNullException>( () => new GravarLogs("") );
        }

        [Fact]
        public void CriarObjClassGravarLogComPathNull()
        {
            Assert.Throws<ArgumentNullException>( () => new GravarLogs(null) );
        }

        [Theory]
        [InlineData(@"A\","Teste1")]
        [InlineData(@"B\","Teste2")]
        [InlineData(@"F\","Teste3")]
        public void SalvarLogDiretorioNaoEncontrado(string path, string linhaLog)
        {
            Assert.Throws<DirectoryNotFoundException>(() => new GravarLogs(path).SalvarLog(linhaLog));
        }

        [Theory]
        [InlineData("+", "Teste1")]
        [InlineData("B", "Teste2")]
        [InlineData(@"F:\", "Teste3")]
        public void SalvarLogDiretorioInvalido(string path, string linhaLog)
        {
            Assert.Throws<ArgumentException>( () => new GravarLogs(path).SalvarLog(linhaLog) );
        }

        [Theory]
        [InlineData(@"c:\\", "Teste1")]
        public void SalvarLogDiretorioSemPermisso(string path, string linhaLog)
        {
            Assert.Throws<UnauthorizedAccessException>( () => new GravarLogs(path).SalvarLog(linhaLog) );
        }

        [Theory]
        [InlineData(@"c:\temp\LOG.txt", "Teste1")]
        [InlineData(@"c:\temp\Log\teste.log", "Teste2")]
        [InlineData(@"c:\temp\teste.log",  null)]
        [InlineData(@"c:\temp\teste",  null)]
        public void SalvarLogTest(string path, string linhaLog)
        {
            Assert.Null(Record.Exception(() => new GravarLogs(path).SalvarLog(linhaLog)));     
        }

        [Theory]
        [InlineData(@"c:\temp\Log\",-1)]
        [InlineData(@"c:\temp\",0)]
        [InlineData(@"c:\temp\", 1)]
        public void DeletaArquivoDeLogTest(string path, int numDiasPermanecer)
        {
            Assert.Null(Record.Exception(() => new GravarLogs(path).DeleteLog(numDiasPermanecer)));
        }


    }
}
