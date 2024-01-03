using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

using XGCommLib;

namespace PLCStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string plcIPAdress = "192.168.1.33:2004";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            plcResult.Text = string.Empty;

            // PLC에 접속하기 위한 메소드가 정의된 클래스
            CommObjectFactory20 factory = new CommObjectFactory20();

            // PLC와 데이터를 주고 받기 위한 메소드가 정의된 클래스
            CommObject20 oCommDriver = factory.GetMLDPCommObject20(plcIPAdress);

            // 연결 실패시
            if(oCommDriver.Connect("") == 0)
            {
                MessageBox.Show("연결 실패!");
                return;
            }

            
            int nMaxBuf = 1400;
            byte[] bufWrite = new byte[nMaxBuf];

            int nTotal_len = 0;

            DeviceInfo oDevice = factory.CreateDevice();
            oDevice.ucDataType = (byte)dataSize.Text[0];
            oDevice.ucDeviceType = (byte)dataLocation.Text[0];

            if(string.IsNullOrEmpty(offsetData.Text))
            {
                plcResult.Text = "오류! offset 미입력!";
                DisConnectPLC(oCommDriver);
                return;
            }

            oDevice.lOffset = int.Parse(offsetData.Text);
            oDevice.lSize = 4;
            oCommDriver.AddDeviceInfo(oDevice);

            for (int i = 0; i < oDevice.lSize; i++)
                bufWrite[i] = (byte)((i + 1) % 255);

            nTotal_len += oDevice.lSize;

            byte[] bWriteBuf = new byte[nTotal_len];
            Array.Copy(bufWrite, 0, bWriteBuf, 0, nTotal_len);

            if(oCommDriver.WriteRandomDevice(bWriteBuf) != 1)
            {
                plcResult.Text = "오류! 쓰기 실패!";
                DisConnectPLC(oCommDriver);
                return;
            }

            byte[] bufRead = new byte[nTotal_len];

            if(oCommDriver.ReadRandomDevice(bufRead) == 1)
            {
                if(bWriteBuf.SequenceEqual(bufRead))
                {
                    for(int i=0;i<bufRead.Length;i++)
                        plcResult.Text += bufRead[i].ToString() + "\n";

                    plcResult.Text += "데이터 일치!";
                }
                else
                {
                    plcResult.Text = "데이터 불일치!";
                }
            }
            else
            {
                plcResult.Text = "오류! 읽기 실패!";
                DisConnectPLC(oCommDriver);
                return;
            }
            

            DisConnectPLC(oCommDriver);
        }

        void DisConnectPLC(CommObject20 oCommDriver)
        {
            int nRetn = oCommDriver.Disconnect();

            if (nRetn == 1)
                MessageBox.Show("연결 종료!");
            else
                MessageBox.Show("연결 종료도 안되네 이젠");
        }

        private void OffsetData_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}