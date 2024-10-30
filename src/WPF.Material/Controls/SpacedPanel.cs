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
    /// Identifies the <see cref="JoinItemBorders"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty JoinItemBordersProperty = DependencyProperty.Register(
        nameof(JoinItemBorders),
        typeof(bool),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            false,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    /// Identifies the <see cref="ItemBorderThickness"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ItemBorderThicknessProperty = DependencyProperty.Register(
        nameof(ItemBorderThickness),
        typeof(double),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            1.0,
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
    /// Gets or sets a value indicating whether the borders of the items should be joined. This is only applicable
    /// when the <see cref="Spacing"/> between items is 0. This makes the items appear separated by a single border
    /// instead of two borders (one for each item).
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public bool JoinItemBorders
    {
        get => (bool)GetValue(JoinItemBordersProperty);
        set => SetValue(JoinItemBordersProperty, value);
    }
    
    /// <summary>
    /// Gets or sets the uniform thickness of the border around each item. This value is used when the items are
    /// eligible for joining borders. This property doesn't set the border thickness of the items, but it is used to
    /// adjust the position of the items to make them appear as if they have a single border.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public double ItemBorderThickness
    {
        get => (double)GetValue(ItemBorderThicknessProperty);
        set => SetValue(ItemBorderThicknessProperty, value);
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
        var spacing = Math.Abs(Spacing);
        var orientation = Orientation;
        var joinItemBorders = JoinItemBorders && spacing is 0.0;
        var uniformItemBorderThickness = ItemBorderThickness;

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

                if (joinItemBorders && i < children.Count - 1)
                {
                    offsetX -= uniformItemBorderThickness;
                }
            }
            else
            {
                child.Arrange(new Rect(0.0, offsetY, constraints.Width, childSize.Height));
                offsetY += childSize.Height + spacing;

                if (joinItemBorders && i < children.Count - 1)
                {
                    offsetY -= uniformItemBorderThickness;
                }
            }
        }

        return constraints;
    }
}
