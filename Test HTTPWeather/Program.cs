// This implements a console application that can be used to test an ASCOM driver
//

// This is used to define code in the template that is specific to one class implementation
// unused code can be deleted and this definition removed.

#define ObservingConditions
// remove this to bypass the code that uses the chooser to select the driver
#define UseChooser

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the code that's required
#if UseChooser
            // choose the device
            string id = ASCOM.DriverAccess.ObservingConditions.Choose("");
            if (string.IsNullOrEmpty(id))
                return;
            // create this device
            ASCOM.DriverAccess.ObservingConditions device = new ASCOM.DriverAccess.ObservingConditions(id);
#else
            // this can be replaced by this code, it avoids the chooser and creates the driver class directly.
            ASCOM.DriverAccess.ObservingConditions device = new ASCOM.DriverAccess.ObservingConditions("ASCOM.HTTPWeather.ObservingConditions");
#endif
            // now run some tests, adding code to your driver so that the tests will pass.
            // these first tests are common to all drivers.
            Console.WriteLine("name " + device.Name);
            Console.WriteLine("description " + device.Description);
            Console.WriteLine("DriverInfo " + device.DriverInfo);
            Console.WriteLine("driverVersion " + device.DriverVersion);

            // TODO add more code to test the driver.
            device.Connected = true;

            Console.WriteLine($"Connection status {device.Connected}");
            if(device.Connected)
            {
                device.Refresh();
                Console.WriteLine($"Temperature: {device.Temperature}");

                Console.WriteLine($"Last measurement date: {device.TimeSinceLastUpdate("")}");

            }
            else
            {
                Console.WriteLine($"Can't connect to server");
            }


            device.Connected = false;
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
