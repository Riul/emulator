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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryJobInfo
    {
        public const short Id = 195;

        public sbyte jobId;
        public sbyte jobLevel;
        public sbyte minSlots;
        public sbyte userDefinedParams;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public JobCrafterDirectoryEntryJobInfo()
        {
        }

        public JobCrafterDirectoryEntryJobInfo(sbyte jobId, sbyte jobLevel, sbyte userDefinedParams, sbyte minSlots)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.userDefinedParams = userDefinedParams;
            this.minSlots = minSlots;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteSByte(jobLevel);
            writer.WriteSByte(userDefinedParams);
            writer.WriteSByte(minSlots);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            jobLevel = reader.ReadSByte();
            if (jobLevel < 1 || jobLevel > 100)
                throw new Exception("Forbidden value on jobLevel = " + jobLevel + ", it doesn't respect the following condition : jobLevel < 1 || jobLevel > 100");
            userDefinedParams = reader.ReadSByte();
            if (userDefinedParams < 0)
                throw new Exception("Forbidden value on userDefinedParams = " + userDefinedParams + ", it doesn't respect the following condition : userDefinedParams < 0");
            minSlots = reader.ReadSByte();
            if (minSlots < 0 || minSlots > 9)
                throw new Exception("Forbidden value on minSlots = " + minSlots + ", it doesn't respect the following condition : minSlots < 0 || minSlots > 9");
        }
    }
}