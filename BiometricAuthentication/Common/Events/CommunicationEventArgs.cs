using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Common.Events
{
    public class CommunicationEventArgs : EventArgs
    {
        public string Data;
        public GaitReadingsChecksum GaitReadingsChecksum;
        public Guid DeviceId;
        public CommunicationEventStatus Status;
    }

    public enum CommunicationEventStatus
    {
        Ok = 1,
        SessionNotActive = 2,
        UnknownDevice = 3,
        ChecksumNotMatched = 4
    }
}
