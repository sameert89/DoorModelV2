using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorModelSource
{
    public enum DoorState { OPEN, CLOSE };

    public abstract class Door
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void ChangeState(DoorState newState);
    }
}
