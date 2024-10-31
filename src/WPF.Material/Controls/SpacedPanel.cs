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
    /// Identifies the StretchHorizontally dependency property.
    /// </summary>
    public static readonly DependencyProperty StretchHorizontallyProperty = DependencyProperty.RegisterAttached(
        "StretchHorizontally",
        typeof(bool),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            false,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    /// <summary>
    /// Identifies the StretchVertically dependency property.
    /// </summary>
    public static readonly DependencyProperty StretchVerticallyProperty = DependencyProperty.RegisterAttached(
        "StretchVertically",
        typeof(bool),
        typeof(SpacedPanel),
        new FrameworkPropertyMetadata(
            false,
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));

    private int stretchableChildrenCount;
    private double totalNonStretchedWidth;
    private double totalNonStretchedHeight;

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
    
        /// <summary>
    /// Sets the value of the <see cref="StretchHorizontallyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="StretchHorizontallyProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetStretchHorizontally(DependencyObject element, bool value) =>
        element.SetValue(StretchHorizontallyProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="StretchHorizontallyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="StretchHorizontallyProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="StretchHorizontallyProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetStretchHorizontally(DependencyObject element) =>
        (bool)element.GetValue(StretchHorizontallyProperty);

    /// <summary>
    /// Sets the value of the <see cref="StretchVerticallyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="StretchVerticallyProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetStretchVertically(DependencyObject element, bool value) =>
        element.SetValue(StretchVerticallyProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="StretchVerticallyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="StretchVerticallyProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="StretchVerticallyProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetStretchVertically(DependencyObject element) =>
        (bool)element.GetValue(StretchVerticallyProperty);

    protected override Size MeasureOverride(Size availableSize)
    {
        var children = Children;
        var spacing = Spacing;
        var orientation = Orientation;
        var joinItemBorders = JoinItemBorders && spacing is 0.0;
        var itemBorderThickness = ItemBorderThickness;

        if (children.Count is 0)
        {
            return Size.Empty;
        }

        var totalWidth = 0.0;
        var totalHeight = 0.0;

        stretchableChildrenCount = 0;
        totalNonStretchedWidth = 0.0;
        totalNonStretchedHeight = 0.0;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];

            // Let the child measure itself.
            child.Measure(availableSize);
            var childSize = child.DesiredSize;

            // Calculate the total width and height of the panel based on the orientation and the size of the child.
            if (orientation is Orientation.Horizontal)
            {
                totalWidth += childSize.Width;
                totalHeight = Math.Max(totalHeight, childSize.Height);
            }
            else
            {
                totalHeight += childSize.Height;
                totalWidth = Math.Max(totalWidth, childSize.Width);
            }

            // Count the number of stretchable children and the total width and height of the non-stretched children.
            if (GetStretchHorizontally(child) || GetStretchVertically(child))
            {
                stretchableChildrenCount++;
            }
            else
            {
                if (orientation is Orientation.Horizontal)
                {
                    totalNonStretchedWidth += childSize.Width;
                }
                else
                {
                    totalNonStretchedHeight += childSize.Height;
                }
            }
        }

        // Adjust the total size of the panel by adding the total spacing between children and removing the total
        // border thickness that has been joined. Also, ensures that the total size is at least the size of the
        // available space if there are any stretchable children.

        var totalSpacing = spacing * (children.Count - 1);
        var totalJoinedBorderThickness = joinItemBorders
            ? itemBorderThickness * (children.Count - 1)
            : 0.0;

        if (orientation is Orientation.Horizontal)
        {
            totalWidth += totalSpacing - totalJoinedBorderThickness;
            if (stretchableChildrenCount > 0)
            {
                totalWidth = Math.Max(totalWidth, availableSize.Width);
                totalNonStretchedWidth -= totalJoinedBorderThickness;
            }
        }
        else
        {
            totalHeight += totalSpacing - totalJoinedBorderThickness;
            if (stretchableChildrenCount > 0)
            {
                totalHeight = Math.Max(totalHeight, availableSize.Height);
                totalNonStretchedHeight -= totalJoinedBorderThickness;
            }
        }

        return new Size(totalWidth, totalHeight);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        var children = Children;
        var spacing = Math.Abs(Spacing);
        var orientation = Orientation;
        var joinItemBorders = JoinItemBorders && spacing is 0.0;
        var itemBorderThickness = ItemBorderThickness;

        if (children.Count is 0)
        {
            return finalSize;
        }

        // The offset of the next child.
        var offsetX = 0.0;
        var offsetY = 0.0;

        var totalSpacing = spacing * (children.Count - 1);

        // Calculate the remaining width and height after arranging the non-stretched children.
        var remainingWidth = finalSize.Width - totalNonStretchedWidth - totalSpacing;
        var remainingHeight = finalSize.Height - totalNonStretchedHeight - totalSpacing;

        // Calculate the width and height of the stretchable children.
        var stretchableChildWidth = stretchableChildrenCount > 0 ? remainingWidth / stretchableChildrenCount : 0.0;
        var stretchableChildHeight = stretchableChildrenCount > 0 ? remainingHeight / stretchableChildrenCount : 0.0;

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var childSize = child.DesiredSize;
            
            if (orientation is Orientation.Horizontal)
            {
                var childWidth = childSize.Width;

                // Use the stretchable width if the child is stretchable.
                if (GetStretchHorizontally(child))
                {
                    childWidth = stretchableChildWidth;
                }
                
                child.Arrange(new Rect(offsetX, 0.0, childWidth, finalSize.Height));

                // Update the offset for the next child.
                offsetX += Math.Round(childWidth + spacing);

                // Adjust the offset to join the borders of the items.
                if (joinItemBorders && i < children.Count - 1)
                {
                    offsetX = Math.Round(offsetX) - itemBorderThickness;
                }
            }
            else
            {
                var childHeight = childSize.Height;

                // Use the stretchable height if the child is stretchable.
                if (GetStretchVertically(child))
                {
                    childHeight = stretchableChildHeight;
                }

                child.Arrange(new Rect(0.0, offsetY, finalSize.Width, childHeight));

                // Update the offset for the next child.
                offsetY += Math.Round(childHeight + spacing);

                // Adjust the offset to join the borders of the items.
                if (joinItemBorders && i < children.Count - 1)
                {
                    offsetY = Math.Round(offsetY) - itemBorderThickness;
                }
            }
        }

        return finalSize;
    }
}