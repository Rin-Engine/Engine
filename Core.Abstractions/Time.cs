using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Rin.Core")]
namespace Rin.Core.General;

public static class Time {
    public static float DeltaTime { get; internal set; }
}
