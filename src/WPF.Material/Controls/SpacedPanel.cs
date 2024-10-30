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

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            
            child.Measure(constraints);

            var childSize = child.DesiredSize;

            if (orientation is Orientation.Horizontal)
            {
                width += childSize.Width;
                height = Math.Max(height, childSize.Height);
            }
            else
            {
                height += childSize.Height;
                width = Math.Max(width, childSize.Width);
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
        
        // Offset of the next child
        var offsetX = 0.0;
        var offsetY = 0.0;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var childSize = child.DesiredSize;

            if (orientation is Orientation.Horizontal)
            {
                child.Arrange(new Rect(offsetX, 0.0, childSize.Width, constraints.Height));
                offsetX += childSize.Width + spacing;
            }
            else
            {
                child.Arrange(new Rect(0.0, offsetY, constraints.Width, childSize.Height));
                offsetY += childSize.Height + spacing;
            }
        }

        return constraints;
    }
}