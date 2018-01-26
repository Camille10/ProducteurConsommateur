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
        private static int NbElement = 1000;
        private static int NbProducteur = 30;
        private static int NbConsommateur = 30;


        static void Main(string[] args)
        {
                QueueToProduceAndSort cqueue = new QueueToProduceAndSort(NbElement);
                OutputList sortedListOutput = new OutputList();

                for (int index = 0; index < NbProducteur; index++)
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
                sortedListOutput.DisplaySortedList();
        }
    }
}

