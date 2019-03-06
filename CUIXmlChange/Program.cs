using INIToXmlLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUIXmlChange
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  properties args => /i DNWEB.INI /o DNWEB_Final.xml
             *  CmdReader cmdReader = new CmdReader("/i DNWEB.INI /o END.xml");
             *  INIToXml iNIToXml = new INIToXml(args[1], args[3]);
             *  iNIToXml.INIStreamReader();
             *  iNIToXml.Dispose();
            */
            int Status = 0;
            do
            {
                Console.WriteLine(">>---------------------------------------------------------------<<");
                Console.WriteLine("Please input your file's name and final file's name.");
                Console.WriteLine("input  argument (.INI): /i ");
                Console.WriteLine("output argument (.xml): /o ");
                Console.WriteLine("exit   argument : /q ");
                Console.WriteLine("ex : /i DNWEB.INI /o END.xml or /q");
                Console.Write(">>");
                CmdReader cmdReader = new CmdReader(Console.ReadLine());

                Status = cmdReader.GetStatus();

                if (Status == 1)
                {
                    INIToXml iNIToXml = new INIToXml(cmdReader.GetInputFileName(), cmdReader.GetOutputFileNamee());
                    iNIToXml.INIStreamReader();
                    iNIToXml.INISwap();
                    iNIToXml.Dispose();
                }
                else if(Status != 2)
                    Console.WriteLine("semantic error");

                Console.WriteLine("Swap End");
                cmdReader.Dispose();
            } while (Status != 2);
            
            Console.WriteLine("CUIXmlChange END...");
            Console.ReadKey();
        }
    }
}
