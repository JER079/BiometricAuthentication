using Common;
using System;

namespace BiometricAuthentication.Business
{
    public class WearableDeviceEntry
    {
        public Guid DeviceId;
        public string DeviceName;

        private GaitReadings _gaitReadings;
        private string _encryptionKey;
        private Session _session;

        public WearableDeviceEntry(Guid deviceId, string deviceName)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }

        public bool IsDeviceMatched(GaitReadings readingsToMatch)
        {
            return true;
        }

        public bool IsSessionActive()
        {
            return _session.IsExpired;
        }

        public Session CreateNewSessionForDevice()
        {
            if (_session != null && !_session.IsExpired) return _session;

            _session = new Session();
            return _session;
        }      
    }
}
