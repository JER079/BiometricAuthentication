using BiometricAuthentication.Common.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiometricAuthentication.Business
{
    public class WearableDeviceStore
    {
        public WearableDeviceStore()
        {
            WearableDeviceEntries = new List<WearableDeviceEntry>();
        }

        //this is a list of devices that the smartphone has paired with.
        public List<WearableDeviceEntry> WearableDeviceEntries { get; }

        public void AddDevice(Guid wearableDeviceId, string wearableDeviceName)
        {
            if (!WearableDeviceEntries.Any(x => x.DeviceId == wearableDeviceId))
            {
                WearableDeviceEntries.Add(new WearableDeviceEntry(wearableDeviceId, wearableDeviceName));
                Console.WriteLine("Wearable Device Name and ID Added in Smartphone Store");
            }
        }

        public WearableDeviceEntry Find(Guid deviceId)
        {
            //paired device is stored in the phone's WearableDeviceStore
            // the count is 1 and will return back the value to the phone WearabledeviceEntry
            return WearableDeviceEntries.FirstOrDefault(x => x.DeviceId == deviceId);
        }

        internal WearableDeviceEntry Find(GaitReadings gaitReadings)
        {
            foreach(var entry in WearableDeviceEntries)
            {
                if (entry.IsDeviceMatched(gaitReadings))
                {
                    return entry;
                }
            }

            return null;
        }
    }
}
