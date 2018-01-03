using BiometricAuthentication.Business;
using BiometricAuthentication.Business.Devices;
using BiometricAuthentication.Common;
using System.Windows.Forms;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Smartphone _smartphone;
        private WearableDevice _wearableDevice;
        private ManInTheMiddle _manInTheMiddle;

        public Form1()
        {
            InitializeComponent();

            InitializeDevices();
        }

        public void InitializeDevices()
        {
            var discoveryService = new DeviceDiscoveryService();
            var dataTransmitter = new TransmitDataService();

            _wearableDevice = new WearableDevice(new Accelerometer(), discoveryService, dataTransmitter);
            _smartphone = new Smartphone(discoveryService);
            _manInTheMiddle = new ManInTheMiddle();

            PhoneName.Text = _smartphone.Name;
            WearableName.Text = _wearableDevice.Name;
           
            _smartphone.SubscribeForEvents(_wearableDevice);
            _manInTheMiddle.SubscribeForEvents(_wearableDevice);
        }

        private void StartNewSessionButton_Click(object sender, System.EventArgs e)
        {
            _wearableDevice.StartNewSession();
            DeviceLabel.Text = "Session Started";
        }

        private void PairButton_Click(object sender, System.EventArgs e)
        {
            var pairedDeviceName = _smartphone.DiscoverDevices();

            SmartphoneMessage.Text = pairedDeviceName;
        }

        private void TransmitDataButton_Click(object sender, System.EventArgs e)
        {
            _wearableDevice.TransmitData(TransmitTextBox.Text);

            SmartphoneMessage.Text = "Received " + _smartphone.LastMessageReceived;
            SniffedMessage.Text = "Sniffed " + _manInTheMiddle.LastSniffedMessage;
        }
    }
}
