using BiometricAuthentication.Business;
using BiometricAuthentication.Business.Devices;
using BiometricAuthentication.Common;
using System;
using System.Windows.Forms;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Smartphone _smartphone;
        private WearableDevice _wearableDevice;
        private ManInTheMiddle _manInTheMiddle;
        
        private Timer _dataTransmissionTimer;
        private string[] _wordsToSend;

        public Form1()
        {
            InitializeComponent();

            InitializeDevices();
            SetupTimer();
            SetupWordsToSend();
        }

        private void SetupWordsToSend()
        {
            _wordsToSend = new []{ "HELLO", "JEREMY", "CAT", "DOG", "UNITED", "TOYOTA", "FOOTBALL", "SHARK", "SUMMER" };
        }

        private void SetupTimer()
        {
            _dataTransmissionTimer = new Timer();

            _dataTransmissionTimer.Interval = 5000;
            _dataTransmissionTimer.Enabled = false;
            _dataTransmissionTimer.Tick += _dataTransmissionTimer_Tick;
        }

        private void _dataTransmissionTimer_Tick(object sender, EventArgs e)
        {
            //this method will trigger every time the timer ticks which is every 5s
            var random = new Random();
            var wordToSend = _wordsToSend[random.Next(0, _wordsToSend.Length-1)];

           //Console.WriteLine($"Sending {wordToSend}");
           //Console.WriteLine("Session Expired");
           //Console.WriteLine("Starting New Session");
           // Console.WriteLine(" seconds for new message");

            if (EncryptionOnOff.Checked)

            {
                Console.WriteLine("Message Encrypted");
                Console.WriteLine("Sending Encrypted Message");
                _wearableDevice.TransmitData(wordToSend);
            }
            else
            {
                //if encryption is not selected
                Console.WriteLine("Message Not Encrypted");
                Console.WriteLine("Sending Unencrypted Message");
                _wearableDevice.TransmitDataPlainText(wordToSend);
            }
     
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
            _smartphone.ListenForRougeMessage(_manInTheMiddle);
            _manInTheMiddle.SubscribeForEvents(_wearableDevice);
        }

        private void StartNewSessionButton_Click(object sender, System.EventArgs e)
        {
            //Start New Session Button on form
            Console.WriteLine("Starting New Session Button Clicked");
            _wearableDevice.StartNewSession();
            DeviceLabel.Text = "Session Started";
        }

        private void PairButton_Click(object sender, System.EventArgs e)
        {
            Console.WriteLine("Discover & Pair Button Pressed");
            //var pairedDeviceName will show on the form Jeremy's Watch
            //smartphone.DiscoverDevices returns both devices data, i.e. name & ID
            var pairedDeviceName = _smartphone.DiscoverDevices();

            Console.WriteLine("Jeremy's Watch paired with Jeremy's Phone" );
            SmartphoneMessage.Text = pairedDeviceName;
        }

        //Send Data button of Form
        private void TransmitDataButton_Click(object sender, System.EventArgs e)
        {
            //if encryption is selected
            if (EncryptionOnOff.Checked)
                
            {
                Console.WriteLine("Encrypt Message :" + TransmitTextBox.Text);
                //Console.WriteLine("Sending Cipher Text ");
                _wearableDevice.TransmitData(TransmitTextBox.Text);
            }
            else
            {
                //if encryption is not selected
                Console.WriteLine("Message Not Encrypted");
                Console.WriteLine("Sending Unencrypted Message");
                _wearableDevice.TransmitDataPlainText(TransmitTextBox.Text);
            }

            //TOADD Log of plain text the phone received and the encrypted text
            Console.WriteLine("Message Delivered to Jeremy's Phone");
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

        private void EncryptionOnOff_CheckedChanged(object sender, System.EventArgs e)
        {
            if (EncryptionOnOff.Checked) Console.WriteLine("Encryption On");
            else Console.WriteLine("Encryption Off");

            _smartphone.UseEncryption = EncryptionOnOff.Checked;
        }

        private void TimerOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (TimerOnOff.Checked)
            {
                Console.WriteLine("Timer On");
                _dataTransmissionTimer.Enabled = true;
                _dataTransmissionTimer.Start();
                Console.WriteLine("Starting a New Session");
                Console.WriteLine("10 seconds");
            }
            else
            {
                Console.WriteLine("Timer Off");
                _dataTransmissionTimer.Stop();
                _dataTransmissionTimer.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PhoneName_Click(object sender, EventArgs e)
        {

        }

        private void ManInTheMiddleButton_Click(object sender, EventArgs e)
        {
            _manInTheMiddle.TransmitDataToPhone();
        }
    }
}
