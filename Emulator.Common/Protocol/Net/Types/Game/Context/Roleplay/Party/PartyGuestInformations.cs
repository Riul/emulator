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
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party
{
    public class PartyGuestInformations
    {
        public const short ID = 374;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int GuestId { get; set; }
        public int HostId { get; set; }
        public string Name { get; set; }
        public EntityLook GuestLook { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public PlayerStatus Status { get; set; }


        public PartyGuestInformations()
        {
        }

        public PartyGuestInformations(int guestId, int hostId, string name, EntityLook guestLook, sbyte breed, bool sex, PlayerStatus status)
        {
            GuestId = guestId;
            HostId = hostId;
            Name = name;
            GuestLook = guestLook;
            Breed = breed;
            Sex = sex;
            Status = status;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(GuestId);
            writer.WriteInt(HostId);
            writer.WriteUTF(Name);
            GuestLook.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            GuestId = reader.ReadInt();
            HostId = reader.ReadInt();
            Name = reader.ReadUTF();
            GuestLook = new EntityLook();
            GuestLook.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}