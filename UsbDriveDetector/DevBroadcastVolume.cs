using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UsbDriveDetector
{
    [StructLayout(LayoutKind.Sequential)]
    class DevBroadcastVolume
    {

        public int Size;
        public int DeviceType;
        public int Reserved;
        public int Mask;
        public Int16 Flags;
    }
}
