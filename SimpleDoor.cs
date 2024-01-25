using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.ProgramLogger;

namespace DoorModelSource
{
    public class SimpleDoor : Door
    {
        public DoorState CurrentState { get; set; }

        [LogDefault("Simple Door Purchased!")]
        public SimpleDoor()
        {
            CurrentState = DoorState.CLOSE;
        }
        public SimpleDoor(SimpleDoor simpleDoorObj) : this() { } // Copy Constructor
        public override void Open()
        {
            if (CurrentState == DoorState.CLOSE)
            {
                ChangeState(DoorState.OPEN);
            }
        }
        public override void Close()
        {
            if (CurrentState == DoorState.OPEN)
            {
                ChangeState(DoorState.CLOSE);
            }
        }
        public override void ChangeState(DoorState newState)
        {
            CurrentState = newState;
        }
    }
}
