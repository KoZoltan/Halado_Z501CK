using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankShooter_Z501CK
{
    internal class IntCheker
    {
        public delegate void IntEventHandler(object sender, EventArgs e);
        public event IntEventHandler IntEqualsTenEvent;
        public void CheckInteger(int number1, int number2)
        {
            if (number1 == 10 || number2 == 10)
            {
                OnIntEqualsTen();
            }
        }
        protected virtual void OnIntEqualsTen()
        {
            IntEqualsTenEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
