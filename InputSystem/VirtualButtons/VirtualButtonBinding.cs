namespace Rin.InputSystem.VirtualButtons;

/// <summary>
///     Describes a binding between a name and a <see cref="IVirtualButton" />.
/// </summary>
public class VirtualButtonBinding {
    /// <summary>
    ///     Gets or sets the name of this virtual button.
    /// </summary>
    /// <value>The name.</value>
    public object? Name { get; set; }

    /// <summary>
    ///     Gets or sets the virtual button.
    /// </summary>
    /// <value>The virtual button.</value>
    public IVirtualButton? Button { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualButtonBinding" /> class.
    /// </summary>
    public VirtualButtonBinding() : this(null) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualButtonBinding" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="button">The button.</param>
    public VirtualButtonBinding(object? name, IVirtualButton? button = null) {
        Name = name;
        Button = button;
    }

    /// <summary>
    ///     Gets the value for a particular binding.
    /// </summary>
    /// <returns>Value of the binding</returns>
    public virtual float GetValue(InputManager manager) => Button?.GetValue(manager) ?? 0.0f;

    public override string ToString() => $"[{Name}] => {Button}";
}
