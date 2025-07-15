using MessagePack;
using System.Collections.Generic;

namespace SharedPacket
{
    [MessagePackObject]
    [Union(0, typeof(C_InputPacket))]
    [Union(1, typeof(S_PlayerListPacket))]
    [Union(2, typeof(S_PlayerJoinedPacket))]
    [Union(3, typeof(C_ConnectPacket))]
    [Union(4, typeof(C_DisconnectPacket))]
    [Union(5, typeof(C_PositionPacket))]
    public abstract class PacketBase
    {
        [Key(0)]
        public string Command { get; set; }
    }

    //둘다 공용



    //서버 -> 클라(S_***)
    [MessagePackObject]
    public class S_PlayerListPacket : PacketBase
    {
        public S_PlayerListPacket()
        {
            Command = "playerList";
        }

        [Key(1)]
        public List<PlayerInfo> Players { get; set; }
    }

    [MessagePackObject]
    public class S_PlayerJoinedPacket : PacketBase
    {
        public S_PlayerJoinedPacket()
        {
            Command = "playerJoined";
        }

        [Key(1)] public string Id { get; set; }
        [Key(2)] public float X { get; set; }
        [Key(3)] public float Y { get; set; }
        [Key(4)] public float Z { get; set; }
    }

    [MessagePackObject]
    public class C_PositionPacket : PacketBase
    {
        public C_PositionPacket()
        {
            Command = "position";
        }

        [Key(1)]
        public string Id { get; set; }
        [Key(2)]
        public float X { get; set; }
        [Key(3)]
        public float Y { get; set; }
        [Key(4)]
        public float Z { get; set; }
        [Key(5)]
        public float Angle { get; set; }
    }


    //클라 -> 서버(C_***)
    [MessagePackObject]
    public class C_InputPacket : PacketBase
    {
        public C_InputPacket()
        {
            Command = "input";
        }

        [Key(1)]
        public string Id { get; set; }
        [Key(2)]
        public float X { get; set; }
        [Key(3)]
        public float Y { get; set; }
        [Key(4)]
        public float Z { get; set; }
        [Key(5)]
        public float Angle { get; set; }

    }

    [MessagePackObject]
    public class C_ConnectPacket : PacketBase
    {
        public C_ConnectPacket()
        {
            Command = "connected";
        }

        [Key(1)]
        public string Id { get; set; }
    }

    [MessagePackObject]
    public class C_DisconnectPacket : PacketBase
    {

        public C_DisconnectPacket()
        {
            Command = "disconnected";
        }

        [Key(1)]
        public string Id { get; set; }
    }


    //기타 정보
    [MessagePackObject]
    public class PlayerInfo
    {
        [Key(0)]
        public string Id { get; set; }
        [Key(1)]
        public float X { get; set; }
        [Key(2)]
        public float Y { get; set; }
        [Key(3)]
        public float Z { get; set; }
        [Key(5)]
        public float Angle { get; set; }
    }
}
