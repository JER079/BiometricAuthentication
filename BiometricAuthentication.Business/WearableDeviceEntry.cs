using BiometricAuthentication.Common.Sensors;
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
            return !_session.IsExpired;
        }

        public SessionResult CreateNewSessionForDevice(GaitReadings gaitReadings)
        {
            if (_session != null && !_session.IsExpired) return new SessionResult(_session, _encryptionKey);

            _session = new Session();
            _gaitReadings = gaitReadings;

            _encryptionKey = CreateNewEncryptionKey(gaitReadings);
            return new SessionResult(_session, _encryptionKey);
        }

        private string CreateNewEncryptionKey(GaitReadings gaitReadings)
        {
            var keyGenerator = new EncryptionKeyGenerator();
            return keyGenerator.CreateNewEncrytionKey();
        }

        public string GetEncryptionKey()
        {
            return _encryptionKey;
        }
    }

    public class SessionResult
    {
        public SessionResult(Session session, string encryptionKey)
        {
            Session = session;
            EncryptionKey = encryptionKey;
        }
        public Session Session { get; }
        public string EncryptionKey { get; }
    }
}
