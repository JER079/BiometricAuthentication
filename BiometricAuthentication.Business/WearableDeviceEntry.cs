using Common;

namespace BiometricAuthentication.Business
{
    public class WearableDeviceEntry
    {
        private GaitReadings _gaitReadings;
        private string _encryptionKey;
        private Session _session;

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
            if (!_session.IsExpired) return _session;

            _session = new Session();
            return _session;
        }      
    }
}
