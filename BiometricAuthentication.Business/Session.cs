using System;

namespace BiometricAuthentication.Business
{
    public class Session
    {
        private const double ExpiryTimeInMunites = 5;

        public Session()
        {
            SessionId = Guid.NewGuid();
            SessionStartTime = DateTime.Now;
            SessionEndTime = DateTime.Now.AddMinutes(ExpiryTimeInMunites);
        }

        public Guid SessionId;
        public DateTime SessionStartTime;
        public DateTime SessionEndTime;
        public bool IsExpired => DateTime.Now > SessionEndTime;
    }
}
