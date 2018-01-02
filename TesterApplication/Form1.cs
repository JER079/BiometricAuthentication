using BiometricAuthentication.Business;
using Common;
using System.Windows.Forms;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Smartphone _smartphone;
        private WearableDevice _wearableDevice;

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

            _smartphone.SubscribeForEvents(_wearableDevice);

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
        }
    }
}
