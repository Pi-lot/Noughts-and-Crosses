using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Windows_Game
{
    class MP3Player
    {
        public MP3Player(string filName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = string.Format(FORMAT, filName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Play()
        {
            string command = "Play MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Stop()
        {
            string command = "Close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwnCallback);
    }
}
