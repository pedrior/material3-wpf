namespace WPF.Material.Controls;

/// <summary>
/// Represents a container that can be used to host other controls. A container has its appearance defined by a
/// <see cref="Surface"/> that expresses shape, elevation and state.
/// </summary>
public class Container : ContentControl
{
    static Container()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(Container),
            new FrameworkPropertyMetadata(typeof(Container)));
    }
}