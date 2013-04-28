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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryJobInfo
    {
        public const short ID = 195;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte JobId { get; set; }
        public sbyte JobLevel { get; set; }
        public sbyte UserDefinedParams { get; set; }
        public sbyte MinSlots { get; set; }


        public JobCrafterDirectoryEntryJobInfo()
        {
        }

        public JobCrafterDirectoryEntryJobInfo(sbyte jobId, sbyte jobLevel, sbyte userDefinedParams, sbyte minSlots)
        {
            JobId = jobId;
            JobLevel = jobLevel;
            UserDefinedParams = userDefinedParams;
            MinSlots = minSlots;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteSByte(JobLevel);
            writer.WriteSByte(UserDefinedParams);
            writer.WriteSByte(MinSlots);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            JobId = reader.ReadSByte();
            JobLevel = reader.ReadSByte();
            UserDefinedParams = reader.ReadSByte();
            MinSlots = reader.ReadSByte();
        }
    }
}