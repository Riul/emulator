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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class NpcDialogQuestionMessage : NetworkMessage
    {
        public const uint ID = 5617;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short Messageid { get; set; }
        public string[] DialogParams { get; set; }
        public short[] VisibleReplies { get; set; }


        public NpcDialogQuestionMessage()
        {
        }

        public NpcDialogQuestionMessage(short messageId, string[] dialogParams, short[] visibleReplies)
        {
            Messageid = messageId;
            DialogParams = dialogParams;
            VisibleReplies = visibleReplies;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(Messageid);
            writer.WriteUShort((ushort) DialogParams.Length);
            foreach (var entry in DialogParams)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) VisibleReplies.Length);
            foreach (var entry in VisibleReplies)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Messageid = reader.ReadShort();
            var limit = reader.ReadUShort();
            DialogParams = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                DialogParams[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            VisibleReplies = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                VisibleReplies[i] = reader.ReadShort();
            }
        }
    }
}