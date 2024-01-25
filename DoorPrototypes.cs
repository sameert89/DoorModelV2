using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorModelSource
{
    public class DoorPrototypes
    {
        private static readonly Dictionary<int, Door> DoorTypes = new Dictionary<int, Door>
        {
        { 0, new SimpleDoor() },
        { 1, new SmartDoor() },
        };
        public static Door GetDoor(int doorType)
        {
            if (DoorTypes.TryGetValue(doorType, out var doorProtoType))
            {
                Type t = doorProtoType.GetType();

                return (Door)Activator.CreateInstance(t, doorProtoType);
            }
            throw new ArgumentException("Invalid door type");
        }
    }
}
