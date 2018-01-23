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
            Producteur producteur = new Producteur(cqueue);
            Consommateur consommateur = new Consommateur(cqueue);
            producteur.Run();
            consommateur.Run();
            while (!(cqueue.IsFinished && cqueue.IsEmpty))
            {
                Thread.Sleep(1000);
            }
        }
    }
}
