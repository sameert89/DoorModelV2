using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeiss.Timers;
using Zeiss.ProgramLogger;

namespace DoorModelSource
{
    public class TimerController
    {
        public event Action<ICloseDoor> TimerDependentActionWithClose; // Onlly invokes when Sabscriber buys Timer + Timer Based Addons
        public event Action TimerDependentActionWithoutClose;
        public int TimeDelayInSec { get; set; }
        
        public TimerController(int t)
        {
            TimeDelayInSec = t;
        }

        [LogDefault("Door Left Open for Too Long, Calling Observers!!!")]
        private void CallbackFunction(object state)
        {
            Console.WriteLine();
            TimerDependentActionWithClose?.Invoke(state as ICloseDoor);
            TimerDependentActionWithoutClose?.Invoke();
            Timers.StopTimer();
        }

        public void SetTimer(DoorState state, ICloseDoor iCloseDoorObjRef)
        {
            if (state == DoorState.OPEN)
            {
                // Pass the smartDoorObjRef as the state parameter to the callback function
                Timers.StartTimer(TimeDelayInSec, CallbackFunction, iCloseDoorObjRef);
            }
            else
            {
                Timers.StopTimer();
            }
        }
    }
}
