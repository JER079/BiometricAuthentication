using System;

namespace Common.Events
{
    public class CommunicationEventArgs : EventArgs
    {
        public string Data;
        public GaitReadings GaitReadings;
        public Guid DeviceId;
    }
}
