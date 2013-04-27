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
// Created on 24/04/2013 at 17:39
#endregion

using System;
using System.IO;
using System.Text;

namespace Emulator.Common.IO
{
    public class BigEndianWriter : IDisposable
    {
        private BinaryWriter writer;

        #region ctor

        public BigEndianWriter()
        {
            writer = new BinaryWriter(new MemoryStream());
        }

        public BigEndianWriter(Stream output)
        {
            writer = new BinaryWriter(output);
        }

        public BigEndianWriter(Stream output, Encoding encoding)
        {
            writer = new BinaryWriter(output, encoding);
        }

        public BigEndianWriter(string file)
        {
            writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate, FileAccess.Write));
        }

        #endregion

        public Stream BaseStream
        {
            get { return writer.BaseStream; }
        }

        public int Position
        {
            get { return (int)BaseStream.Position; }
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
            writer.Dispose();
            writer = null;
        }

        /// <summary>
        /// Writes a byte to the buffer
        /// </summary>
        public void WriteByte(byte value)
        {
            writer.Write(value);
        }

        /// <summary>
        /// Writes a signed byte to the buffer
        /// </summary>
        public void WriteSByte(sbyte value)
        {
            writer.Write(value);
        }

        /// <summary>
        /// Writes multiple bytes to the buffer
        /// </summary>
        public void WriteBytes(byte[] value)
        {
            if (value.Length > 0)
                writer.Write(value);
        }

        /// <summary>
        /// Writes a boolean to the buffer
        /// </summary>
        public void WriteBoolean(bool value)
        {
            WriteByte((byte)((value) ? 1 : 0));
        }

        /// <summary>
        /// Writes a short to the buffer
        /// </summary>
        public void WriteShort(short value)
        {
            WriteByte((byte)(value >> 8));
            WriteByte((byte)(value));
        }

        /// <summary>
        /// Writes a short to the buffer
        /// </summary>
        public void WriteShort(uint value)
        {
            WriteShort((short)value);
        }

        /// <summary>
        /// Writes an unisgned short to the buffer
        /// </summary>
        public void WriteUShort(ushort value)
        {
            WriteByte((byte)(value >> 8));
            WriteByte((byte)(value & 255));
        }

        /// <summary>
        /// Writes an integer to the buffer
        /// </summary>
        public void WriteInt(int value)
        {
            byte[] arr = BitConverter.GetBytes(value);
            WriteByte(arr[3]);
            WriteByte(arr[2]);
            WriteByte(arr[1]);
            WriteByte(arr[0]);
        }

        /// <summary>
        /// Writes an unsigned integer to the buffer
        /// </summary>
        public void WriteUInt(uint value)
        {
            WriteByte((byte)(value >> 24));
            value -= (value >> 24) << 24;
            WriteByte((byte)(value >> 16));
            value -= (value >> 16) << 16;
            WriteByte((byte)(value >> 8));
            value -= (value >> 8) << 8;
            WriteByte((byte)value);
        }

        /// <summary>
        /// Writes a double to the buffer
        /// </summary>
        public void WriteDouble(uint value)
        {
            WriteByte((byte)(value >> 56));
            value -= (value >> 56) << 56;
            WriteByte((byte)(value >> 48));
            value -= (value >> 48) << 48;
            WriteByte((byte)(value >> 40));
            value -= (value >> 40) << 40;
            WriteByte((byte)(value >> 32));
            value -= (value >> 32) << 32;
            WriteByte((byte)(value >> 24));
            value -= (value >> 24) << 24;
            WriteByte((byte)(value >> 16));
            value -= (value >> 16) << 16;
            WriteByte((byte)(value >> 8));
            value -= (value >> 8) << 8;
            WriteByte((byte)(value));
        }

        /// <summary>
        /// Writes a double to the buffer
        /// </summary>
        public void WriteDouble(double value)
        {
            WriteDouble((uint)value);
        }

        /// <summary>
        /// Writes an UTF string to the buffer
        /// </summary>
        public void WriteUTF(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            WriteUShort((ushort)bytes.Length);
            foreach (byte bit in bytes)
                WriteByte(bit);
        }

        /// <summary>
        /// Writes a float to the buffer
        /// </summary>
        public void WriteFloat(float value)
        {
            writer.Write(value);
        }

        /// <summary>
        /// Sets the reader's position
        /// </summary>
        /// <param name="position"></param>
        public long Seek(int position)
        {
            return writer.Seek(position, SeekOrigin.Begin);
        }

        /// <summary>
        /// Clears the writer's memory
        /// </summary>
        public void Clear()
        {
            writer.Dispose();
            writer = new BinaryWriter(new MemoryStream());
        }
    }
}
