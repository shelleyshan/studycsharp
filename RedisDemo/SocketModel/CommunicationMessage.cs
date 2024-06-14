using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace SocketDemo.SocketModel
{
    [ProtoContract]
    public class CommunicationMessage
    {
        [ProtoMember(1)]
        public int id { get; set; }

        [ProtoMember(2)]
        public string Content { get; set; }

        [ProtoMember(3)]
        public List<string> Items { get; set; }
    }


    public class TestProtoBufTools
    {
        static int newid = 1;
        public static CommunicationMessage Test()
        {
            var message = new CommunicationMessage()
            {
                id = newid,
                Content = $"Hello{newid}, protobuf-net",
                Items = new List<string>() { "Item1", "Item2", "Item3" }
            };
            newid++;
            return message;

        }

        public static byte[] Serialize<T>(T model)
        {
            //序列化到内存
            using (var memoryStream = new MemoryStream())
            {
                //序列化对象
                Serializer.Serialize(memoryStream, model);
                //重置流的位置到开始位置，以便可以读取
                memoryStream.Position = 0;

                byte[] data = memoryStream.ToArray();
                return data;
            }
        }

        public static T Deserialize<T>(byte[] data, int length)
        {
            using (var memoryStream = new MemoryStream(data, 0, length))
            {
                var deserializedMessage = Serializer.Deserialize<T>(memoryStream);
                return deserializedMessage;
            }
        }
    }
}
