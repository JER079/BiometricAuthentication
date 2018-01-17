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

            //details of watch and phone included in form
            PhoneName.Text = _smartphone.Name;
            WearableName.Text = _wearableDevice.Name;
           
            _smartphone.SubscribeForEvents(_wearableDevice);
            _manInTheMiddle.SubscribeForEvents(_wearableDevice);
        }

        private void StartNewSessionButton_Click(object sender, System.EventArgs e)
        {
            //Start New Session Button on form
            _wearableDevice.StartNewSession();
            DeviceLabel.Text = "Session Started";
        }

        private void PairButton_Click(object sender, System.EventArgs e)
        {
            //Discover Button (on form)
            //return
            var pairedDeviceName = _smartphone.DiscoverDevices();

            //once pairing is succesfull
            SmartphoneMessage.Text = pairedDeviceName;
        }

        private void TransmitDataButton_Click(object sender, System.EventArgs e)
        {
            //new Gait Readings & Device ID
            _wearableDevice.TransmitData(TransmitTextBox.Text);

            SmartphoneMessage.Text = "Received " + _smartphone.LastMessageReceived;
            SniffedMessage.Text = "Sniffed " + _manInTheMiddle.LastSniffedMessage;
        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void SmartphoneMessage_Click(object sender, System.EventArgs e)
        {

        }

        private void TransmitTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void DeviceLabel_Click(object sender, System.EventArgs e)
        {

        }

        private void SniffedMessage_Click(object sender, System.EventArgs e)
        {

        }
    }
}
