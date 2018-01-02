using System;

namespace Common.Events
{
    public class PairingEventArgs : EventArgs
    {
        public Guid SmartphoneId;
        public Guid WearableDeviceId;

        public string SmartphoneName;
        public string WearableDeviceName;
    }
}
