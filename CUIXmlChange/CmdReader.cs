using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CUIXmlChange
{
    class CmdReader : IDisposable
    {
        /// <param name="Status"> 
        ///     0 = semantic error
        ///     1 = success
        ///     2 = exit
        /// </param>
        private int Status = 0;
        private string InputFileName = "";
        private string OutputFileName = "";
        private bool isDisposed = false;

        public CmdReader(string input)
        {
            if (RegexMsg.ExitRegex(input))
                Status = 2;
            else
            {
                InputFileName  = RegexMsg.INIRegex(input);
                OutputFileName = RegexMsg.XmlRegex(input);
                if (!InputFileName.Equals("") && !OutputFileName.Equals(""))
                {
                    InputFileName  = InputFileName.Substring(3);
                    OutputFileName = OutputFileName.Substring(3);
                    Status = 1;
                }
            }
        }

        public int GetStatus()
        {
            return Status;
        }

        public string GetInputFileName()
        {
            return InputFileName;
        }

        public string GetOutputFileNamee()
        {
            return OutputFileName;
        }
      
        public string ToString()
        {
            return "Status : " + Status + ", intput : " + InputFileName + ", output : " + OutputFileName;
        }

        protected virtual void Dispose(bool Diposing)
        {
            if (isDisposed)
                return;

            if (Diposing)
            {
            }
     
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
