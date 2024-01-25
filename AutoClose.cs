using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.ProgramLogger;

namespace DoorModelSource
{
    public class AutoClose
    {
        [LogDefault("Door Auto Closed")]
        public void CloseDoor(ICloseDoor iCloseDoorObjRef)
        {
            iCloseDoorObjRef.Close();
        }
    }
}
