using WPF.Material.Environment;

namespace WPF.Material.Controls;

/// <summary>
/// A panel that arranges its children with a specified spacing between them in either horizontal or vertical
/// orientation.
/// </summary>
public class SpacedPanel : Panel
{
    /// <summary>
    /// Identifies the <see cref="Spacing"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
        nameof(Spacing),
        typeof(double),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            0.0,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    /// Identifies the <see cref="Orientation"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
        nameof(Orientation),
        typeof(Orientation),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            Orientation.Horizontal,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    /// Identifies the <see cref="OverlappingBorderThickness"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty OverlappingBorderThicknessProperty = DependencyProperty.Register(
        nameof(OverlappingBorderThickness),
        typeof(bool),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            true,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    /// Initializes static members of the <see cref="SpacedPanel"/> class.
    /// </summary>
    static SpacedPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpacedPanel),
            new FrameworkPropertyMetadata(typeof(SpacedPanel)));
    }

    /// <summary>
    /// Gets or sets the spacing between children.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    /// <summary>
    /// Gets or sets the orientation, which specifies the direction in which the children are arranged.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the children should overlap the border thickness.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public bool OverlappingBorderThickness
    {
        get => (bool)GetValue(OverlappingBorderThicknessProperty);
        set => SetValue(OverlappingBorderThicknessProperty, value);
    }

    protected override Size MeasureOverride(Size constraints)
    {
        var children = Children;
        var spacing = Spacing;
        var orientation = Orientation;

        if (children.Count is 0)
        {
            return Size.Empty;
        }

        var width = 0.0;
        var height = 0.0;

        var overlappingBorderThickness = IsOverlappingBorderThickness();

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            
            child.Measure(constraints);

            var childSize = child.DesiredSize;
            var thickness = GetChildBorderThickness(child);

            if (orientation is Orientation.Horizontal)
            {
                width += childSize.Width;
                height = Math.Max(height, childSize.Height);

                if (overlappingBorderThickness)
                {
                    width -= thickness.Left;
                }
            }
            else
            {
                height += childSize.Height;
                width = Math.Max(width, childSize.Width);

                if (overlappingBorderThickness)
                {
                    height -= thickness.Top;
                }
            }
        }

        // Space between children
        var spacingBetween = spacing * (children.Count - 1);
        if (orientation is Orientation.Horizontal)
        {
            width += spacingBetween;
        }
        else
        {
            height += spacingBetween;
        }

        return new Size(width, height);
    }

    protected override Size ArrangeOverride(Size constraints)
    {
        var children = Children;
        var spacing = Spacing;
        var orientation = Orientation;

        if (children.Count is 0)
        {
            return constraints;
        }

        var overlappingBorderThickness = IsOverlappingBorderThickness();

        // Offset of the next child
        var offsetX = 0.0;
        var offsetY = 0.0;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var childSize = child.DesiredSize;
            var thickness = overlappingBorderThickness
                ? GetChildBorderThickness(child)
                : default;

            if (orientation is Orientation.Horizontal)
            {
                child.Arrange(new Rect(offsetX, 0.0, childSize.Width, constraints.Height));
                offsetX += childSize.Width + spacing - thickness.Left;
            }
            else
            {
                child.Arrange(new Rect(0.0, offsetY, constraints.Width, childSize.Height));
                offsetY += childSize.Height + spacing - thickness.Top;
            }
        }

        return constraints;
    }

    private static Thickness GetChildBorderThickness(UIElement element) =>
        (Thickness?)element.GetValue(Control.BorderThicknessProperty) ?? default;

    private bool IsOverlappingBorderThickness() => OverlappingBorderThickness &&
                                                   Spacing is 0.0 &&
                                                   Children.Count is not 1;
}