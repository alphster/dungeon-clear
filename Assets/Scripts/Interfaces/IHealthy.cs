using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IHealthy
    {
        void RegisterOnHealthChanged(Action<float, float> callback);

        void UnregisterOnHealthChanged(Action<float, float> callback);
    }
}
