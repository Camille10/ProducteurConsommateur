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
        static void Main(string[] args)
        {
            QueueToProduceAndSort cqueue = new QueueToProduceAndSort(NbElement);
            SortedListOutput sortedListOutput = new SortedListOutput();

            for (int index=0; index < 2; index++)
            {
                Producteur producteur = new Producteur(cqueue);
                producteur.Run();
                Consommateur consommateur = new Consommateur(cqueue, sortedListOutput);
                consommateur.Run();
            }
            while (!(cqueue.IsFinished && cqueue.IsEmpty))
            {
                Thread.Sleep(1000);
            }
            sortedListOutput.DisplaySortedList();
        }
    }
}

