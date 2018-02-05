using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducteurConsommateur
{
    class Program
    {
        private static int NbElement = 10;
        private static int NbProducteurConsommateur = 1;


        static void Main(string[] args)
        {
                CommunicateQueue cqueue = new CommunicateQueue(NbElement);
                OutputList sortedListOutput = new OutputList();

                for (int index = 0; index < NbProducteurConsommateur; index++)
                {
                    if (!(cqueue.IsFinished && cqueue.IsEmpty))
                    {
                        Producteur producteur = new Producteur(cqueue);
                        producteur.Run();
                        Consommateur consommateur = new Consommateur(cqueue, sortedListOutput);
                        consommateur.Run();
                    }
                    else
                    {
                        break;
                    }
                }

                while (!(cqueue.IsFinished && cqueue.IsEmpty))
                {
                    Thread.Sleep(1000);
                }
                DisplayOutputList(sortedListOutput);
        }

        public static void  DisplayOutputList(OutputList sortedListOutput)
        {
            foreach(var outputNumber in sortedListOutput.outputList.Values)
            {
                Console.WriteLine(outputNumber);
            }
            Console.ReadLine();
        }
    }
}
