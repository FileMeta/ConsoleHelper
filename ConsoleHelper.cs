/*
---
# Metadata in MicroYaml format. See http://filemeta.org and http://schema.org
name: ConsoleHelper.cs
description: Helper class for console applications in C#
url: https://github.com/FileMeta/ConsoleHelper/raw/master/ConsoleHelper.cs
version: 1.0
keywords: codebit
dateModified: 2017-05-25
license: http://creativecommons.org/publicdomain/zero/1.0/
...
*/
/*
Creative Commons CC0
To the extent possible under law, Brandt Redd has waived all copyright and
related or neighboring rights to ConsoleHelper.
This work is published from: United States
*/

using System;
using System.Runtime.InteropServices;

namespace Win32Interop
{

    /// <summary>
    /// Set of static properties and methods that make console applicaitons operate more smoothly.
    /// </summary>
    static class ConsoleHelper
    {

        #region Private Stuff

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint GetConsoleProcessList(uint[] ProcessList, uint ProcessCount);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion Private Stuff

        #region Public Stuff

        /// <summary>
        /// Returns true if application is the sole owner of the current console.
        /// </summary>
        public static bool IsSoleConsoleOwner
        {
            get
            {
                uint[] procIds = new uint[4];
                uint count = GetConsoleProcessList(procIds, (uint)procIds.Length);
                return count <= 1;
            }
        }

        /// <summary>
        /// If applicaiton is the sole console owner, prompts the user to press
        /// any key before returning - presumably for the application to exit.
        /// </summary>
        public static void PromptAndWaitIfSoleConsole()
        {
            if (IsSoleConsoleOwner)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Brings the console to the front
        /// </summary>
        public static void BringConsoleToFront()
        {
            SetForegroundWindow(GetConsoleWindow());
        }

        #endregion Public Stuff
    }
}
