namespace Rin.Platform.Abstractions.Rendering;

public interface IIndexBuffer : IDisposable {
    int Count { get; }
    int Size { get; }

    void SetData(ReadOnlySpan<byte> data);
}
