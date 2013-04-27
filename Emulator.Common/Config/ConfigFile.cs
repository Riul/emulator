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
//     Created on 26/04/2013 at 19:24
// */
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

        protected ConfigFile(string path)
        {
            FilePath = path;
            entries = new Dictionary<string, string>();
            Read();
        }

        public string FilePath { get; private set; }

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
