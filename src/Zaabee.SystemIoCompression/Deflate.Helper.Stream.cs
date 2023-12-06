﻿namespace Zaabee.SystemIoCompression;

public static partial class DeflateHelper
{
    public static MemoryStream Compress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream);
        return outputStream;
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(Stream inputStream, Stream outputStream)
    {
        using (var deflateOutputStream = new DeflateStream(outputStream, CompressionMode.Compress, true))
        {
            inputStream.CopyTo(deflateOutputStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        using (var deflateInputStream = new DeflateStream(inputStream, CompressionMode.Decompress, true))
        {
            deflateInputStream.CopyTo(outputStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}