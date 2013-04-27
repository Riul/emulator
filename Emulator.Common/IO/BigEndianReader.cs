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
//     Created on 24/04/2013 at 17:39
// */
#endregion

using System;
using System.IO;
using System.Text;

namespace Emulator.Common.IO
{
    public class BigEndianReader : IDisposable
    {
        private BinaryReader reader;

        #region ctor

        public BigEndianReader(Stream input)
        {
            reader = new BinaryReader(input);
        }
        public BigEndianReader(byte[] input)
        {
            reader = new BinaryReader(new MemoryStream(input));
        }

        public BigEndianReader(string file)
        {
            reader = new BinaryReader(new FileStream(file, FileMode.Open, FileAccess.Read));
        }

        public BigEndianReader(Stream input, Encoding encoding)
        {
            reader = new BinaryReader(input, encoding);
        }

        #endregion

        public Stream BaseStream
        {
            get { return reader.BaseStream; }
        }

        public int Position
        {
            get { return (int)BaseStream.Position; }
        }

        public int Available
        {
            get { return (int) (BaseStream.Length - BaseStream.Position); }
        }

        public byte[] Data
        {
            get
            {
                long pos = BaseStream.Position;

                byte[] data = new byte[BaseStream.Length];
                BaseStream.Position = 0;
                BaseStream.Read(data, 0, (int)BaseStream.Length);

                BaseStream.Position = pos;

                return data;
            }
        }

        public void Dispose()
        {
            reader.Dispose();
            reader = null;
        }

        /// <summary>
        /// Reads one byte from the buffer
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return reader.ReadByte();
        }

        /// <summary>
        /// Reads a signed byte from the buffer
        /// </summary>
        /// <returns></returns>
        public sbyte ReadSByte()
        {
            return reader.ReadSByte();
        }

        /// <summary>
        /// Reads bytes from the buffer
        /// </summary>
        /// <param name="count">Number of bytes to read</param>
        public byte[] ReadBytes(int count)
        {
            return reader.ReadBytes(count);
        }

        /// <summary>
        /// Reads a boolean from the buffer
        /// </summary>
        public bool ReadBoolean()
        {
            return reader.ReadByte() == 1;
        }

        /// <summary>
        /// Reads a short from the buffer
        /// </summary>
        public short ReadShort()
        {
            ushort value = ReadUShort();
            if (value > short.MaxValue)
            {
                short value2 = (short)(-((ushort.MaxValue - value)) - 1);
                return value2;
            }
            return (short)value;
        }

        /// <summary>
        /// Reads an unsigned short from the buffer
        /// </summary>
        public ushort ReadUShort()
        {
            return (ushort)((ReadByte() << 8) + ReadByte());
        }

        /// <summary>
        /// Reads an interger from the buffer
        /// </summary>
        public int ReadInt()
        {
            uint value = ReadUInt();
            if (value > int.MaxValue)
            {
                int value2 = (int)(-((uint.MaxValue - value)) - 1);
                return value2;
            }
            return (int)value;
        }

        /// <summary>
        /// Reads an unsigned interger from the buffer
        /// </summary>
        public uint ReadUInt()
        {
            return (((uint)ReadByte() << 24) + ((uint)ReadByte() << 16) + ((uint)ReadByte() << 8) + ReadByte());
        }

        /// <summary>
        /// Reads a double from the buffer
        /// </summary>
        public double ReadDouble()
        {
            byte[] bytes = ReadBytes(8);
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }

        /// <summary>
        /// Reads an UTF string from the buffer
        /// </summary>
        public string ReadUTF()
        {
            byte[] byteArray = ReadBytes(ReadUShort());
            return Encoding.UTF8.GetString(byteArray);
        }

        /// <summary>
        /// Reads a float from the buffer
        /// </summary>
        /// <returns></returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        /// Sets the reader's position
        /// </summary>
        public void Seek(int position)
        {
            BaseStream.Position = position;
        }

        /// <summary>
        /// Clears the reader's memory
        /// </summary>
        public void Clear()
        {
            reader.Dispose();
            reader = new BinaryReader(new MemoryStream());
        }

        private byte[] ReadBigEndianBytes(int count)
        {
            byte[] buffer = new byte[count];
            for (int i = count - 1; i >= 0; i--)
                buffer[i] = (byte)BaseStream.ReadByte();
            return buffer;
        }
    }
}
