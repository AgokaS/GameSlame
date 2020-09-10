using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Hero
    {
        public event EventHandler EndenStep;
        private int remainingStep;

        public int RemainiStep
        {
            get
            {
                return remainingStep;
            }
        }

        public Hero()
        {
            remainingStep = 4;
        }

        public void SpendStep()
        {
            remainingStep--;

            if (remainingStep<0)
            {
                EventHandler endenStep = EndenStep;
                endenStep?.Invoke(this, EventArgs.Empty);
            }
        }

        public void EatCandy()
        {
              
        }
    }
}
