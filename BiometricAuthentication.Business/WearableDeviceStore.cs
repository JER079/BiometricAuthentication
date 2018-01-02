using System;
using System.Collections.Generic;
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
