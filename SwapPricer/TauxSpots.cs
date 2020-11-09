using System;
using System.IO;
namespace SwapPricer
{
    public class TauxSpots : Taux
    {
        /**
             * On initliase les horizons des taux spots des bons du trésor francais
             * 
             * On initialise les tauxSpot (1 mois, 3 mois, 6 mois, 9 mois, 12 mois,
             * 2 ans, 5 ans, 10 ans, 30 ans)
             *
             */
        public TauxSpots(string nameFile)
        {
            var reader = new StreamReader(File.OpenRead(nameFile));
            
            var line= reader.ReadLine();
            string[] values = line.Split(';');
            string[] value;
            for (int i = 1; i < values.Length; i++)
            {
                value = values[i].Split(" ");
                if (i <= 5)
                {    
                    _dateTimes.Add(DateTime.Now.AddMonths(Convert.ToInt16(value.GetValue(value.Length - 2))));
                }
                else
                {    
                    _dateTimes.Add(DateTime.Now.AddYears(Convert.ToInt16(value.GetValue(value.Length-2))));
                }
            }
            
            for (int i = 0; i < 7; i++)
            {
                line = reader.ReadLine(); 
            }
            values = line.Split(';');
            //double[] test_spot = {0.101, 0.104, 0.124, 0.127, 0.137, 0.151, 0.188, 0.328, 0.756};
            for (int i = 1; i < values.Length; i++)
            {    
                _taux.Add(Convert.ToDouble(values[i].Replace(",","."))/100);
                //_taux.Add(test_spot[i-1]/100);
            }
        }
    }
}