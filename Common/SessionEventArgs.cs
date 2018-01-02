using System;

namespace Common
{
    public class SessionEventArgs : EventArgs
    {
        public Guid WearbleDeviceId;

        public string EncryptionKey;
        public Guid SessionId;
    }
}
