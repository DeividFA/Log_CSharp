using GravarLog.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravarLog.Controller
{
    class GravarLogController
    {
        private readonly IGravarLog _gravarLog;

        public GravarLogController(IGravarLog gravarLog)
        {
            _gravarLog = gravarLog ?? throw new ArgumentException(nameof(gravarLog));
        }

        public void SalvarLog(string linha) => _gravarLog.SalvarLog(linha);

        public void DeleteLog(int numberDaysNotExclusion) => _gravarLog.DeleteLog(numberDaysNotExclusion);
    }
}
