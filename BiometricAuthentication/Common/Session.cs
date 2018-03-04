using System;

namespace BiometricAuthentication.Business
{
    public class Session
    {
        private const double ExpiryTimeInSeconds = 600; 

        public Session()
        {
            SessionId = Guid.NewGuid();
            SessionStartTime = DateTime.Now;
            SessionEndTime = DateTime.Now.AddSeconds(ExpiryTimeInSeconds);
            Console.WriteLine("New Session ID, Session Start Time and Expiry Time configured");
        }
        //
        public Guid SessionId;
        public DateTime SessionStartTime;
        public DateTime SessionEndTime;
        public bool IsExpired => DateTime.Now > SessionEndTime;
    }
}
