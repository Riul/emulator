#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 24/04/2013 at 16:36
// */
#endregion

using System;

namespace Emulator.Common
{
    public static class Logger
    {
        private static readonly object locker = new object();

        public static void Log(string message, ConsoleColor color, params object[] par)
        {
            lock (locker)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message, par);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void Log(string message, params object[] par)
        {
            Log(message, ConsoleColor.Gray, par);
        }

        public static void Error(string message, params object[] par)
        {
            Log(message, ConsoleColor.Red, par);
        }

        public static void Error(Exception ex)
        {
            Log(ex.ToString());
        }

        public static void Error(string message, Exception ex, params object[] par)
        {
            Log(message + "\n" + ex, ConsoleColor.DarkRed, par);
        }

        public static void Debug(string message, params object[] par)
        {
#if DEBUG
            Log(message, ConsoleColor.Blue, par);
#endif
        }

        public static void Warning(string message, params object[] par)
        {
            Log(message, ConsoleColor.Yellow, par);
        }

        public static void Info(string message, params object[] par)
        {
            Log(message, ConsoleColor.DarkGreen, par);
        }
    }
}