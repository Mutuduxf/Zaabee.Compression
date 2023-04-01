﻿using Zaabee.Extensions;

namespace Zaabee.Compressor.Abstractions;

public class NullCompressor : ICompressor
{
    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToArray();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.ToArray();

    public async Task<MemoryStream> CompressAsync(Stream rawStream, CancellationToken cancellationToken = default)
    {
        var memoryStream = new MemoryStream();
#if NETSTANDARD2_0
        await rawStream.CopyToAsync(memoryStream);
#else
        await rawStream.CopyToAsync(memoryStream, cancellationToken);
#endif
        rawStream.TrySeek(0, SeekOrigin.Begin);
        memoryStream.TrySeek(0, SeekOrigin.Begin);
        return memoryStream;
    }

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream,
        CancellationToken cancellationToken = default)
    {
        var memoryStream = new MemoryStream();
#if NETSTANDARD2_0
        await compressedStream.CopyToAsync(memoryStream);
#else
        await compressedStream.CopyToAsync(memoryStream, cancellationToken);
#endif
        compressedStream.TrySeek(0, SeekOrigin.Begin);
        memoryStream.TrySeek(0, SeekOrigin.Begin);
        return memoryStream;
    }

    public async Task CompressAsync(Stream inputStream, Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        await inputStream.CopyToAsync(outputStream);
#else
        await inputStream.CopyToAsync(outputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public async Task DecompressAsync(Stream inputStream, Stream outputStream,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        await inputStream.CopyToAsync(outputStream);
#else
        await inputStream.CopyToAsync(outputStream, cancellationToken);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public MemoryStream Compress(Stream rawStream)
    {
        var memoryStream = new MemoryStream();
        rawStream.CopyTo(memoryStream);
        rawStream.TrySeek(0, SeekOrigin.Begin);
        memoryStream.TrySeek(0, SeekOrigin.Begin);
        return memoryStream;
    }

    public MemoryStream Decompress(Stream compressedStream)
    {
        var memoryStream = new MemoryStream();
        compressedStream.CopyTo(memoryStream);
        compressedStream.TrySeek(0, SeekOrigin.Begin);
        memoryStream.TrySeek(0, SeekOrigin.Begin);
        return memoryStream;
    }

    public void Compress(Stream inputStream, Stream outputStream)
    {
        inputStream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public void Decompress(Stream inputStream, Stream outputStream)
    {
        inputStream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}