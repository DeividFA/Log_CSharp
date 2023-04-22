using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravarLog.Interface
{
    interface IGravarLog
    {
        public void SalvarLog(string linha);

        public void DeleteLog(int numberDaysNotExclusion);

    }
}
