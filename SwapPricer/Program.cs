using System;

namespace SwapPricer
{
    class Program
    {
        static void Main(string[] args)
        {   TauxSpots tauxSpots = new TauxSpots("/Users/lucarosales/Documents/Webstat_Export_20201012.csv");
            TauxZeroCoupon tauxZc = new TauxZeroCoupon(tauxSpots);
            tauxSpots.affichageCourbe();
            Pricer pricer = new Pricer(tauxZc);
            Swap swap = new Swap(new DateTime(2027,11,8),100,1,6 );
            Console.WriteLine("Le taux de la patte fixe est : ");
            Console.WriteLine(pricer.PriceSwap(swap));
            
        }
    }
}