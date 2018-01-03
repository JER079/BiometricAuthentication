using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Common.Events
{
    public class CommunicationEventArgs : EventArgs
    {
        public string Data;
        public GaitReadings GaitReadings;
        public Guid DeviceId;
    }
}
