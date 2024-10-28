namespace WPF.Material.Controls;

/// <summary>
/// Represents a container that can be used to host other controls. A container has its appearance defined by a
/// <see cref="Surface"/> that expresses shape, elevation and state.
/// </summary>
[TemplatePart(Name = PartSurface, Type = typeof(Surface))]
public class Container : ContentControl
{
    private static readonly DependencyPropertyKey RenderedGeometryPropertyKey = DependencyProperty.RegisterReadOnly(
        nameof(RenderedGeometry),
        typeof(Geometry),
        typeof(Container),
        new PropertyMetadata(null));

    /// <summary>
    /// Identifies the <see cref="RenderedGeometry"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty RenderedGeometryProperty = RenderedGeometryPropertyKey.DependencyProperty;

    private const string PartSurface = "PART_Surface";

    private Surface? surface;

    static Container()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(Container),
            new FrameworkPropertyMetadata(typeof(Container)));
    }

    /// <summary>
    /// Gets the <see cref="Geometry"/> that represents the rendered shape of the container.
    /// </summary>
    [Bindable(false)]
    public Geometry? RenderedGeometry
    {
        get => (Geometry?)GetValue(RenderedGeometryProperty);
        private set => SetValue(RenderedGeometryPropertyKey, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        surface = GetTemplateChild(PartSurface) as Surface
                  ?? throw new InvalidOperationException($"Missing required template part: {PartSurface}");

        surface.Rendered -= SurfaceRendered;
        surface.Rendered += SurfaceRendered;
    }

    private void SurfaceRendered(object sender, EventArgs e) => RenderedGeometry = surface?.RenderedGeometry;
}