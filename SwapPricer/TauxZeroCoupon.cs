using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SwapPricer
{
    public class TauxZeroCoupon : Taux
    {    
        /**
         * Dans ce constructeur on va calculer les taux zeros coupons avec la formule
         * du pricing zero coupon
         */
        public TauxZeroCoupon(TauxSpots tauxSpots)
        {
            // pour les horizons ne dépassant pas 1 an on peut réutiliser les taux du trésor public.
            for (int i = 0; i <= 4; i++)
            {
                _taux.Add(tauxSpots.Taux1[i]);
                _dateTimes.Add(tauxSpots.DateTimes[i]);
            }
            // pour les horizons dépassant 1 an on utilise la formule du pricing zero coupon.
            DateTime deb = DateTime.Now.AddYears(2);
            double sommeDividendes = 0;
            double taux = 0;
            double puissance = 0;
            while (DateTime.Compare(tauxSpots.DateTimes[tauxSpots.DateTimes.Count-1],deb)>= 0)
            {
                taux = tauxSpots.Taux_t(deb);
                puissance = 1;
                sommeDividendes = 0;
                for (int i = 4; i < _taux.Count; i++)
                {
                    sommeDividendes += taux/Math.Pow(1+_taux[i],(i-3));
                    puissance += 1;
                }
                _taux.Add(Math.Pow((1+ taux)/(1 - sommeDividendes),1/puissance)-1);
                _dateTimes.Add(deb);
                deb = deb.AddYears(1);
            }
        }
    }
}