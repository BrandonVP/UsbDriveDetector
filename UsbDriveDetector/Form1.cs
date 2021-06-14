using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UsbDriveDetector
{
    public partial class Form1 : Form
    {
        SerialPort port;
        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;

        public Form1()
        {
            InitializeComponent();
            connectedCOM.ports = SerialPort.GetPortNames();
        }

        protected void readPortNames()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                listBox1.Items.Add(port);
                listBox1.Items.Add("----------------------------");
            }
        }

        protected int getCOMList(bool boxPrint = true)
        {
            var usbDevices = GetUSBDevices();
            int count = 0;
            if(boxPrint)
            {

            }
            else
            {

            }
            foreach (var usbDevice in usbDevices)
            {
                listBox1.Items.Add("Device ID: " + usbDevice.DeviceID);
                listBox1.Items.Add("PNP Device ID: " + usbDevice.PnpDeviceID);
                listBox1.Items.Add("Description: " + usbDevice.Description);
                listBox1.Items.Add("----------------------------");
                count++;
            }
            return count;
        }

        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            //using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            //    collection = searcher.Get();
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        class USBDeviceInfo
        {
            public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
            {
                this.DeviceID = deviceID;
                this.PnpDeviceID = pnpDeviceID;
                this.Description = description;
            }
            public string DeviceID { get; private set; }
            public string PnpDeviceID { get; private set; }
            public string Description { get; private set; }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            
                            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                            listBox1.Items.Add("New Device Arrived");
                            int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME)
                            {
                                DevBroadcastVolume vol;
                                vol = (DevBroadcastVolume)Marshal.PtrToStructure(m.LParam,
                                   typeof(DevBroadcastVolume));

                                var drive = (uint)vol.Mask;
                                int count = 0;
                                for (int bit = 0; bit < 32; bit++)
                                {
                                    if ((drive & 1) == 1)
                                    {
                                        count = bit;
                                        break;
                                    }
                                    drive = drive >> 1;
                                }
                                listBox1.Items.Add("Drive letter " + alpha[count] + " attached");
                                listBox1.Items.Add("----------------------------");
                            }
                            else
                            {
                                string[] temp = SerialPort.GetPortNames();
                                int value = temp.Length;
                                listBox1.Items.Add("Connected on port: " + temp[value - 1]);
                                listBox1.Items.Add("----------------------------");
                            }

                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            listBox1.Items.Add("Device Removed");
                            listBox1.Items.Add("----------------------------");
                            if (port != null && port.IsOpen)
                            {
                                port.Close();
                            }
                            break;
                    }
                    break;
            }
        }

        private void getUSB_Click(object sender, EventArgs e)
        {
            int count = getCOMList();
            listBox1.Items.Add(count + " devices connected");
            listBox1.Items.Add("----------------------------");
        }

        private void clearlistbox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void readComPort_Click(object sender, EventArgs e)
        {
            readPortNames();
        }

        private void sendSerial_Click(object sender, EventArgs e)
        {
            PortWrite("testLowerAxis");
            listBox1.Items.Add(port.ReadLine());
            listBox1.Items.Add("----------------------------");
            Thread.Sleep(1000);
            PortWrite("testUpperAxis");
            listBox1.Items.Add(port.ReadLine());
            listBox1.Items.Add("----------------------------");
            Thread.Sleep(1000);
            PortWrite("testPosAxis");
            listBox1.Items.Add(port.ReadLine());
            listBox1.Items.Add("----------------------------");
        }
        private void PortWrite(string message)
        {
            if (port != null && port.IsOpen)
            {
                port.Write(message);
            }
        }

        private void openSerial_Click(object sender, EventArgs e)
        {
            string[] temp = SerialPort.GetPortNames();
            int value = temp.Length;
            port = new SerialPort(temp[value - 1], 115200);//Set your board COM
            port.DtrEnable = true;
            if (port != null && !port.IsOpen)
            {
                port.Open();
            }
            listBox1.Items.Add("Device ready");
            listBox1.Items.Add("----------------------------");
            Thread.Sleep(1000);
            port.ReadExisting();
        }
    }
    static class connectedCOM
    {
        public static string[] ports;
    }
}
