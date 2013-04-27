#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 24/04/2013 at 16:36
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