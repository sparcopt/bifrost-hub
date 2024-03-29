﻿namespace BifrostHub.Infrastructure.Gateways.OdinEye.WebSockets.Extensions;

using ProtoBuf;

public static class ByteExtensions
{
    public static TTYpe DeserializeProto<TTYpe>(this byte[] binaryData) =>
        Serializer.Deserialize<TTYpe>(new MemoryStream(binaryData));
}