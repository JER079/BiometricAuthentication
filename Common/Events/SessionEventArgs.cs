using System;

namespace BiometricAuthentication.Common.Events
{
    public class SessionEventArgs : EventArgs
    {
        public Guid WearbleDeviceId;

        public string EncryptionKey;
        public Guid SessionId;
    }
}
