using System;
using System.Collections.Generic;
using System.IO;

namespace SwapPricer
{
    public abstract class Taux
    {
        protected List<double> _taux = new List<double>(); //on stocke les taux spot
        protected List<DateTime> _dateTimes = new List<DateTime>(); //on stocke les horizons de ces taux

        
        /**
         *
         * @date date à laquelle on calcule le taux
         * On calcule le taux par interpolation linéaire
         */
        public double Taux_t(DateTime date)
        {
            int index = 0;
            for (int i = 0; i < _dateTimes.Count; i++)
            {
                index = _dateTimes.Count - i - 1;
                if (DateTime.Compare(date, _dateTimes[index]) >= 0)
                {   
                    return ((date - _dateTimes[index]).TotalDays * _taux[index+1] + (_dateTimes[index + 1] - date).TotalDays * _taux[index]) /
                           (_dateTimes[index+1] - _dateTimes[index]).TotalDays;
                }
            }
            return 0.0;
        }
        
        /**
         * Méthode qui calcule un taux forward
         */
        public double tauxForward(DateTime now, DateTime deb, DateTime fin)
        {
            double forward = Math.Pow(1 + Taux_t(fin), (fin - now).TotalDays / 365) /
                             Math.Pow(1 + Taux_t(deb), (deb - now).TotalDays / 365);
            forward = Math.Pow(forward, 1 / ((fin - deb).TotalDays / 365)) - 1;
            return forward;
        }

        public void affichageCourbe()
        {
            for (int i = 0; i < _taux.Count; i++)
            {   
                Console.Write("À la date ");
                Console.WriteLine(_dateTimes[i]);
                Console.Write("Le taux est ");
                Console.WriteLine(_taux[i]);
                Console.WriteLine();
            }
        }
        public List<DateTime> DateTimes
        {
            get => _dateTimes;
            //set => _dateTimes = value;
        }
        public List<double> Taux1
        {
            get => _taux;
            //set => _taux = value;
        }
    }
}