using System;

namespace DoorModelSource
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the type of door you would like to purchase:");
            Console.WriteLine("1) Simple Door");
            Console.WriteLine("2) Smart Door (Upgradable, Add-ons Sold Separately)");
            
            if (!int.TryParse(Console.ReadLine(), out int doorType))
            {
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }

            if (doorType == 1)
            {
                Console.WriteLine("You selected a Simple Door. No addons available.");
            }
            
            else if (doorType == 2)
            {
                SmartDoor myDoorObj = DoorPrototypes.GetDoor(doorType - 1) as SmartDoor;

                // Allow the user to choose other addons
                Console.WriteLine("Choose addons to subscribe (comma-separated ex: 1,2):");
                Console.WriteLine("1) Alert");
                Console.WriteLine("2) Auto Close");
                Console.WriteLine("3) Pager Notify");

                string[] addons = Console.ReadLine()?.Split(',');

                if (addons != null)
                {
                    foreach (var addon in addons)
                    {
                        switch (addon.Trim())
                        {
                            case "1":
                                Console.WriteLine("Buzzer Alert addon subscribed.");
                                myDoorObj.timerControllerObj.TimerDependentActionWithoutClose += (new Alert().SendAlert);
                                break;
                            case "2":
                                Console.WriteLine("Auto Close addon subscribed.");
                                myDoorObj.timerControllerObj.TimerDependentActionWithClose += (new AutoClose().CloseDoor);
                                break;
                            case "3":
                                Console.WriteLine("Pager Notify addon subscribed.");
                                myDoorObj.timerControllerObj.TimerDependentActionWithoutClose += (new PagerNotify().Notify);
                                break;
                            default:
                                Console.WriteLine($"Invalid addon choice: {addon}");
                                break;
                        }
                    }
                }

                // Simulate door operations
                myDoorObj.Open();
                Console.WriteLine("Door is open.");
                Console.WriteLine("Simulating door open for 5 seconds...");
                System.Threading.Thread.Sleep(5000);
                myDoorObj.Close();
                Console.WriteLine("Door is closed.");
                Console.WriteLine("Simulating door open again...");
                myDoorObj.Open();
            }
            
            else
            {
                Console.WriteLine("Invalid door type. Exiting.");
            }

            Console.ReadLine(); // To hold console window open after execution
        }
    }
}