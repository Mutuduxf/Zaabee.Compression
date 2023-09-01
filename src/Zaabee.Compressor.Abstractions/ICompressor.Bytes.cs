﻿namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    byte[] Compress(byte[] rawBytes);
    byte[] Decompress(byte[] compressedBytes);
}

public static class CompressorExtensions
{
    public static byte[] Compress(this ICompressor compressor, string str, Encoding? encoding = null) =>
        compressor.Compress(str.GetBytes(encoding ?? Consts.DefaultEncoding));

    public static string DecompressToString(this ICompressor compressor, byte[] bytes, Encoding? encoding = null) =>
        compressor.Decompress(bytes)
            .GetString(encoding ?? Consts.DefaultEncoding);
}