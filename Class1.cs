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
    [Union (6, typeof(S_bulletPacket))]
    [Union (7, typeof(C_FirePacket))]
    [Union (8, typeof(C_HitPacket))]
    [Union (9, typeof(S_HitInfoPacket))]
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

    [MessagePackObject]
    public class S_bulletPacket : PacketBase
    {
        public S_bulletPacket()
        {
            Command = "bullet";
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
        [Key(6)]
        public long SpawnTime { get; set; }
    }

    [MessagePackObject]
    public class S_HitInfoPacket : PacketBase
    {
        public S_HitInfoPacket()
        {
            Command = "hitInfo";
        }

        [Key(1)]
        public string shooter { get; set; }
        [Key(2)]
        public string target { get; set; }
        [Key(3)]
        public float damage { get; set; }

        // 추가적인 피격 처리는 나중에
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

    [MessagePackObject]
    public class C_FirePacket : PacketBase
    {
        public C_FirePacket()
        {
            Command = "fire";
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
        [Key(6)]
        public long SpawnTime { get; set; }
    }

    [MessagePackObject]
    public class C_HitPacket : PacketBase
    {
        public C_HitPacket()
        {
            Command = "Hit";
        }
        [Key(1)]
        public string shooter { get; set; }
        [Key(2)]
        public string target { get; set; }
        [Key(3)]
        public long spawnedTime { get; set; }
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
