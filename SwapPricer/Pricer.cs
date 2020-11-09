using System;
using IronPython.Modules;

namespace SwapPricer
{
    public class Pricer
    {
        private TauxZeroCoupon _tauxZc;
        
        public TauxZeroCoupon Taux
        {
            get => _tauxZc;
        }

        public Pricer(TauxZeroCoupon tauxZc)
        { 
            _tauxZc = tauxZc;
        }

        /*
        pricer en date t = 0, depart spot
        */
        public double PriceSwap(Swap swap)
        {
            DateTime t = DateTime.Now.AddMonths(swap.PeriodeVariable);
            double patteVariable = 0;
            double patteFixe = 0;
            /*while (t.CompareTo(swap.Maturity) <= 0)
            {
                double taux_variable = 1 / Math.Pow(1 + _tauxZc.Taux_t(t), (t - DateTime.Now).TotalDays/365);
                taux_variable *=  100*swap.PeriodeVariable / 365 *
                                                 _tauxZc.tauxForward(DateTime.Now, t, 
                                                     t.AddMonths(swap.PeriodeVariable));
                patteVariable += taux_variable;
                t = t.AddMonths(swap.PeriodeVariable);
            }
            ;*/
            t = DateTime.Now.AddMonths(swap.PeriodeFixe);
            while (t.CompareTo(swap.Maturity) <= 0)
            {
               
                double taux_fixe = 1 /Math.Pow(1+_tauxZc.Taux_t(t),(t - DateTime.Now).TotalDays/365);
                patteFixe += taux_fixe;
                t = t.AddMonths(swap.PeriodeFixe);

            }
            patteVariable =  100* (1 - 1 /Math.Pow(1+_tauxZc.Taux_t(swap.Maturity),(swap.Maturity - DateTime.Now).TotalDays/365));
            return patteVariable/patteFixe;
        }
    }
}