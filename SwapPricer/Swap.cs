using System;

namespace SwapPricer
{
    public class Swap
    {
        private DateTime _maturity;
        private double _nominal;
        private int _periode_fixe; // On l'exprime en mois
        private int _periode_variable;// On l'exprime en mois

        public double Nominal => _nominal;
        public int PeriodeVariable => _periode_variable;

        public DateTime Maturity
        {
            get => _maturity;
            //set => _maturity = value;
        }
        
        public int PeriodeFixe
        {
            get => _periode_fixe;
            //set => _periode_fixe = value;
        }

        public Swap(DateTime maturity, double nominal, int periodeFixe, int periodeVariable)
        {
            this._maturity = maturity;
            this._nominal = nominal;
            this._periode_fixe = periodeFixe;
            this._periode_variable = periodeVariable;
        }
    }
}