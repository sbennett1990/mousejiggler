#region header

// MouseJiggle - Program.cs
//
// Alistair J. R. Young
// Arkane Systems
//
// Copyright Arkane Systems 2012-2013.
//
// Created: 2013-08-24 12:41 PM

#endregion

using System;
using System.Threading;
using System.Windows.Forms;

namespace ArkaneSystems.MouseJiggle {
    internal static class Program {
        public static bool StartJiggling = false;
        public static bool ZenJiggling = false;
        public static bool StartMinimized = false;

        [STAThread]
        private static void Main(string[] args) {
            Mutex instance = new Mutex(initiallyOwned: false, name: "single instance: ArkaneSystems.MouseJiggle");

            if (instance.WaitOne(0, false)) {
                // Check for command-line switches.
                foreach (string arg in args) {
                    if ((string.Compare(arg, "--JIGGLE", ignoreCase: true) == 0)
                        || (string.Compare(arg, "--J", ignoreCase: true) == 0))
                        StartJiggling = true;

                    if ((string.Compare(arg, "--ZEN", ignoreCase: true) == 0)
                        || (string.Compare(arg, "--Z", ignoreCase: true) == 0))
                        ZenJiggling = true;

                    if ((string.Compare(arg, "--MINIMIZED", ignoreCase: true) == 0)
                        || (string.Compare(arg, "--M", ignoreCase: true) == 0))
                        StartMinimized = true;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

            instance.Close();
        }
    }
}
