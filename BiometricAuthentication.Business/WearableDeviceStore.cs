using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace BiometricAuthentication.Business
{
    public class WearableDeviceStore
    {
        public WearableDeviceStore()
        {
            WearableDeviceEntries = new List<WearableDeviceEntry>();
        }

        public List<WearableDeviceEntry> WearableDeviceEntries { get; }

        public void AddDevice(Guid wearableDeviceId, string wearableDeviceName)
        {
            if (!WearableDeviceEntries.Any(x => x.DeviceId == wearableDeviceId))
            {
                WearableDeviceEntries.Add(new WearableDeviceEntry(wearableDeviceId, wearableDeviceName));
            }
        }

        public WearableDeviceEntry Find(Guid deviceId)
        {
            return WearableDeviceEntries.First(x => x.DeviceId == deviceId);
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
