using BiometricAuthentication.Business.Encryption;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Business.Devices
{
    public class Smartphone
    {
        public bool UseEncryption;

        private readonly WearableDeviceStore _wearableDeviceStore;
        private readonly DeviceDiscoveryService _deviceDiscoveryService;

        private readonly Guid _smartphoneId;
        public string Name { get; }

        public string LastMessageReceived = string.Empty;

        public Smartphone(DeviceDiscoveryService deviceDiscoveryService)
        {
            _smartphoneId = Guid.Parse("4A9EA187-A08E-4415-923E-1669202F723D");
            Name = "Jeremy's Phone";

            _wearableDeviceStore = new WearableDeviceStore();
            _deviceDiscoveryService = deviceDiscoveryService;
        } 

        public void ListenForRougeMessage(ManInTheMiddle manInTheMiddle)
        {
            manInTheMiddle.TransmitData += DataTransmitter_TransmitData;
        }

        private void ManInTheMiddle_TransmitData(CommunicationEventArgs communicationEventArgs)
        {
            throw new NotImplementedException();
        }

        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.RaiseStartNewSession += WearableDevice_RaiseStartNewSession;
            wearableDevice.DataTransmitter.TransmitData += DataTransmitter_TransmitData;
        }

        private void DataTransmitter_TransmitData(Common.Events.CommunicationEventArgs communicationEventArgs)
        {
            Console.WriteLine(" Smartphone -> Is device known?");
            var deviceWithId = _wearableDeviceStore.Find(communicationEventArgs.DeviceId);
            Console.WriteLine(" Device id known" );

            if (deviceWithId == null)
            {
                Console.Write("Device not found");
                LastMessageReceived = "Device not found";
                communicationEventArgs.Status = CommunicationEventStatus.UnknownDevice;
                return;
            }
            if (!deviceWithId.IsSessionActive())
            {
                Console.WriteLine("Session Not Active");
                LastMessageReceived = "Session Not Active";
                communicationEventArgs.Status = CommunicationEventStatus.SessionNotActive;
                return;
            }
            
              if (deviceWithId.IsChecksumMatched(communicationEventArgs.GaitReadingsChecksum))
            {
                Console.WriteLine("Checksum Matched");
                var message = string.Empty;

                if (UseEncryption)
                {
                    Console.WriteLine("Cipher Text received, decrypt to plain text");
                    var decriptionService = new DecryptionService();
                    message = decriptionService.Decrypt(communicationEventArgs.Data, deviceWithId.GetEncryptionKey());
                    Console.WriteLine("CipherText decrypted to Original Plain Text : " + message);
                }
                else
                {
                    message = communicationEventArgs.Data;
                }

                Console.WriteLine("Smartphone received : " + message);
                LastMessageReceived = message;
            }
            else
            {
                Console.WriteLine("Checksum Not Matched");
                LastMessageReceived = "Checksum not matched";
                communicationEventArgs.Status = CommunicationEventStatus.ChecksumNotMatched;
            }                  
        }

        private void WearableDevice_RaiseStartNewSession(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs)
        {
            var createSessionResult = StartNewSession(sessionEventArgs.WearbleDeviceId, gaitReadings);

            sessionEventArgs.SessionId = createSessionResult.Session.SessionId;
            sessionEventArgs.EncryptionKey = createSessionResult.EncryptionKey;
        }

        private SessionResult StartNewSession(Guid wearableDeviceId, GaitReadings gaitReadings)

       {
           Console.WriteLine("Smartphone Validates Device Name and ID");
           var deviceEntry = _wearableDeviceStore.Find(wearableDeviceId);

            if (deviceEntry != null)
            {
                Console.WriteLine("Wearable Device Name & ID are validated");
                Console.WriteLine("Gait Readings Array Table Stored in Smartphone Store");
                return deviceEntry.CreateNewSessionForDevice(gaitReadings);
            }

            else return null;
        }

        public string DiscoverDevices()
        {
            
            var pairingResult = _deviceDiscoveryService.PairWearableDevice(_smartphoneId, Name);
            
            if (pairingResult != null)
            {                          
                _wearableDeviceStore.AddDevice(pairingResult.WearableDeviceId, pairingResult.WearableDeviceName);

                return pairingResult.WearableDeviceName;
            }
            else return "pairing not successful";

        }
    }
}
