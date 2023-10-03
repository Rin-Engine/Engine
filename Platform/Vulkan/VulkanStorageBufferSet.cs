using Rin.Core.Abstractions;
using Rin.Platform.Internal;
using Rin.Platform.Rendering;

namespace Rin.Platform.Vulkan;

public sealed class VulkanStorageBufferSet : IStorageBufferSet {
    readonly List<IStorageBuffer> storageBuffers;

    public VulkanStorageBufferSet(StorageBufferOptions options, int size, int framesInFlight) {
        if (framesInFlight == 0) {
            framesInFlight = Renderer.Options.FramesInFlight;
        }

        storageBuffers = new(framesInFlight);
        for (var i = 0; i < framesInFlight; i++) {
            storageBuffers.Add(ObjectFactory.CreateStorageBuffer(options, size));
        }
    }

    public IStorageBuffer Get() => Get(Renderer.CurrentFrameIndex);
    public IStorageBuffer Get_RT() => Get(Renderer.CurrentFrameIndex_RT);
    public IStorageBuffer Get(int frame) => storageBuffers[frame];

    public void Set(IStorageBuffer storageBuffer, int frame) {
        storageBuffers[frame] = storageBuffer;
    }

    public void Resize(int newSize) {
        foreach (var buffer in storageBuffers) {
            buffer.Resize(newSize);
        }
    }
}