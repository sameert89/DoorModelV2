using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.ProgramLogger;

namespace DoorModelSource
{
    public class SmartDoor: SimpleDoor, ICloseDoor
    {
        [LogDefault("Smart Door Successfuly Purchased")]
        public SmartDoor()
        {
            timerControllerObj = new TimerController(10);
        }
        public SmartDoor(SmartDoor smartDoorObj) : this() {} // Copy Constructor

        public TimerController timerControllerObj;
        public override void ChangeState(DoorState newState)
        {
            base.ChangeState(newState);
            timerControllerObj.SetTimer(newState, this);
        }
    }
}
