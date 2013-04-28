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
    public class JobExperience
    {
        public const short ID = 98;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte JobId { get; set; }
        public sbyte JobLevel { get; set; }
        public double JobXP { get; set; }
        public double JobXpLevelFloor { get; set; }
        public double JobXpNextLevelFloor { get; set; }


        public JobExperience()
        {
        }

        public JobExperience(sbyte jobId, sbyte jobLevel, double jobXP, double jobXpLevelFloor, double jobXpNextLevelFloor)
        {
            JobId = jobId;
            JobLevel = jobLevel;
            JobXP = jobXP;
            JobXpLevelFloor = jobXpLevelFloor;
            JobXpNextLevelFloor = jobXpNextLevelFloor;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteSByte(JobLevel);
            writer.WriteDouble(JobXP);
            writer.WriteDouble(JobXpLevelFloor);
            writer.WriteDouble(JobXpNextLevelFloor);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            JobId = reader.ReadSByte();
            JobLevel = reader.ReadSByte();
            JobXP = reader.ReadDouble();
            JobXpLevelFloor = reader.ReadDouble();
            JobXpNextLevelFloor = reader.ReadDouble();
        }
    }
}