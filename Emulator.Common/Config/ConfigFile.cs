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
// Created on 26/04/2013 at 19:24
#endregion

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Emulator.Common.Config
{
    public abstract class ConfigFile
    {
        private Dictionary<string, string> entries;

        public string FilePath { get; private set; }

        protected ConfigFile(string path)
        {
            FilePath = path;
            entries = new Dictionary<string, string>();
            Read();
        }

        public void Save()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var entry in entries)
            {
                builder.AppendLine(entry.Key + " = " + entry.Value);
            }
            File.WriteAllText(FilePath, builder.ToString());
        }

        protected string GetValue(string tag, string defaultValue = "")
        {
            if (!entries.ContainsKey(tag))
            {
                entries.Add(tag, defaultValue);
            }
            return entries[tag];
        }

        private void Read()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }

            entries = new Dictionary<string, string>();
            foreach (var l in File.ReadAllLines(FilePath))
            {
                string line = l.Split('#')[0].Trim();
                if (!string.IsNullOrEmpty(line) && line.Contains('='))
                {
                    entries.Add(line.Split('=')[0].Trim(), line.Split('=')[1].Trim());
                }
            }
        }
    }
}
