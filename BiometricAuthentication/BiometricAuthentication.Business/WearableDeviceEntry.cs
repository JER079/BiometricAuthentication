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
            Console.WriteLine("Is Session Active?");
            if (_session == null) return true;
            Console.WriteLine("Session is active");
            return !_session.IsExpired;
        }

        public SessionResult CreateNewSessionForDevice(GaitReadings gaitReadings)
        {
            Console.WriteLine("Smartphone Checks if Session is Active or Expired");
            if (_session != null && !_session.IsExpired) return new SessionResult(_session, _encryptionKey);

            // _session is where the session time frame is configured
            // new Session () returned from Session Class: SessionStartTime, SessionEndTime and SessionID
            Console.WriteLine("Session is Expired, therefore Smartphone will create a new session");
            _session = new Session();
            _gaitReadings = gaitReadings;
            //gaitReadings will be used to generate a new encryption key

            Console.WriteLine("Smartphone Generates a New Encryption Key");
            _encryptionKey = CreateNewEncryptionKey(gaitReadings);
            Console.WriteLine("New Encryption Key Generated : " + _encryptionKey);

            //new EncryptionKey created
            return new SessionResult(_session, _encryptionKey);
            //new Session and new EncryptionKey will be stored in the WearableDeviceEntry and forwarded from the phone to the watch
        }

        private string CreateNewEncryptionKey(GaitReadings gaitReadings)
        {
            
            var keyGenerator = new EncryptionKeyGenerator();
            return keyGenerator.CreateNewEncryptionKey();
            
        }

        public string GetEncryptionKey()
        {
            return _encryptionKey;
        }

        public bool IsChecksumMatched(GaitReadingsChecksum checksumToMatch)
        {
            //we put all readings together in one array
            Console.WriteLine("Validate Checksum");
            var allReadings = new double[150];
            _gaitReadings.AccelerometerReadings.XValues.CopyTo(allReadings, 0);
            _gaitReadings.AccelerometerReadings.YValues.CopyTo(allReadings, 49);
            _gaitReadings.AccelerometerReadings.ZValues.CopyTo(allReadings, 99);

            double checksum = 0;

            //we get the reading from each position as specified by the positions array
            //and add them up to get the checksum value
            for(int i = 0; i < checksumToMatch.Positions.Length; i++)
            {
                Console.WriteLine("Array Position : " + i);
                Console.WriteLine("Total Checksum :" + checksum);
                var positionToRead = checksumToMatch.Positions[i];
                checksum = checksum + allReadings[positionToRead];
                       
            }

            //if the checksum is matched to the one being sent than the device is matched.
            bool checksumMatched = checksum == checksumToMatch.Checksum;
            Console.WriteLine("Does Checksum Match? " + checksumMatched);

            return checksumMatched;
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
