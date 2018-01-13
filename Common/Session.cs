using System;

namespace BiometricAuthentication.Business
{
    public class Session
    {
        private const double ExpiryTimeInMinutes = 5;

        public Session()
        {
            SessionId = Guid.NewGuid();
            SessionStartTime = DateTime.Now;
            SessionEndTime = DateTime.Now.AddMinutes(ExpiryTimeInMinutes);
        }

        public Guid SessionId;
        public DateTime SessionStartTime;
        public DateTime SessionEndTime;
        public bool IsExpired => DateTime.Now > SessionEndTime;
    }
}
