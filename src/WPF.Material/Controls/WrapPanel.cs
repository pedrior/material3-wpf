using WPF.Material.Environment;

namespace WPF.Material.Controls;

/// <summary>
/// Represents a panel that positions child elements in sequential position from left to right, breaking content to the
/// next row at the edge of the containing box. It supports horizontal alignment, horizontal gap between children and
/// vertical gap between rows.
/// </summary>
public class WrapPanel : Panel
{
    /// <summary>
    /// Identifies the <see cref="HorizontalContentAlignment"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register(
        nameof(HorizontalContentAlignment),
        typeof(HorizontalAlignment),
        typeof(WrapPanel),
        new FrameworkPropertyMetadata(HorizontalAlignment.Center, FrameworkPropertyMetadataOptions.AffectsArrange));

    /// <summary>
    /// Identifies the <see cref="HorizontalGap"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalGapProperty = DependencyProperty.Register(
        nameof(HorizontalGap),
        typeof(double),
        typeof(WrapPanel),
        new FrameworkPropertyMetadata(
            default(double),
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
            null,
            CoerceGap));

    /// <summary>
    /// Identifies the <see cref="VerticalGap"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalGapProperty = DependencyProperty.Register(
        nameof(VerticalGap),
        typeof(double),
        typeof(WrapPanel),
        new FrameworkPropertyMetadata(
            default(double),
            FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
            null,
            CoerceGap));

    /// <summary>
    /// Initializes static members of the <see cref="WrapPanel"/> class.
    /// </summary>
    static WrapPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WrapPanel),
            new FrameworkPropertyMetadata(typeof(WrapPanel)));
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of the content within the panel. Default is
    /// <see cref="HorizontalAlignment.Center"/>.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public HorizontalAlignment HorizontalContentAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
        set => SetValue(HorizontalContentAlignmentProperty, value);
    }

    /// <summary>
    /// Gets or sets the horizontal gap between children.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public double HorizontalGap
    {
        get => (double)GetValue(HorizontalGapProperty);
        set => SetValue(HorizontalGapProperty, value);
    }

    /// <summary>
    /// Gets or sets the vertical gap between rows.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Layout)]
    public double VerticalGap
    {
        get => (double)GetValue(VerticalGapProperty);
        set => SetValue(VerticalGapProperty, value);
    }

    protected override Size MeasureOverride(Size constraint)
    {
        var rowWidth = 0.0;
        var rowHeight = 0.0;

        var width = 0.0;
        var height = 0.0;

        var children = InternalChildren;
        for (var index = 0; index < children.Count; index++)
        {
            var child = children[index];

            // Let the child determine its size
            child.Measure(constraint);

            var childSize = child.DesiredSize;

            // Add horizontal gap between children
            var horizontalGap = rowWidth > 0.0 ? HorizontalGap : 0.0;

            // Check if the current row has enough space for the next child
            if (rowWidth + childSize.Width + horizontalGap > constraint.Width)
            {
                // Add vertical gap between rows
                var verticalGap = index > 0 ? VerticalGap : 0.0;

                // Row exceeded available width, move to the next row and update total size
                width = Math.Max(rowWidth, width);
                height += rowHeight + verticalGap;

                // Start a new row with the moved child
                rowWidth = childSize.Width;
                rowHeight = childSize.Height;
            }
            else
            {
                // Accumulate the width and height for the current row
                rowWidth += childSize.Width + horizontalGap;
                rowHeight = Math.Max(childSize.Height, rowHeight);
            }
        }

        // Add the final row size to the total panel size
        width = Math.Max(rowWidth, width);
        height += rowHeight;

        return new Size(width, height);
    }

    protected override Size ArrangeOverride(Size constraint)
    {
        var rowWidth = 0.0;
        var rowHeight = 0.0;
        
        var verticalOffset = 0.0;

        var firstChildInRowIndex = 0;

        var children = InternalChildren;
        for (var index = 0; index < children.Count; index++)
        {
            var childSize = children[index].DesiredSize;
            var horizontalGap = rowWidth > 0 ? HorizontalGap : 0.0;

            // Check if the current row has enough space for the next child
            if (rowWidth + childSize.Width + horizontalGap > constraint.Width)
            {
                // Arrange the current row and move to the next row
                ArrangeRow(
                    verticalOffset,
                    rowWidth,
                    rowHeight,
                    constraint.Width,
                    firstChildInRowIndex,
                    index);

                rowWidth = childSize.Width;
                rowHeight = childSize.Height;
                verticalOffset += rowHeight + VerticalGap;

                firstChildInRowIndex = index;
            }
            else
            {
                // Accumulate the width and height for the current row
                rowWidth += childSize.Width + horizontalGap;
                rowHeight = Math.Max(childSize.Height, rowHeight);
            }
        }

        // Arrange the final row
        if (firstChildInRowIndex < children.Count)
        {
            ArrangeRow(
                verticalOffset,
                rowWidth,
                rowHeight,
                constraint.Width,
                firstChildInRowIndex,
                children.Count);
        }

        return constraint;
    }

    private void ArrangeRow(double y, double rowWidth, double rowHeight, double width, int childIndex, int childCount)
    {
        // Calculate the horizontal offset based on the horizontal content alignment
        var x = HorizontalContentAlignment switch
        {
            HorizontalAlignment.Center => (width - rowWidth) * 0.5,
            HorizontalAlignment.Right => width - rowHeight,
            _ => 0.0
        };

        var children = InternalChildren;

        // Arrange each child in the row
        for (var index = childIndex; index < childCount; index++)
        {
            var child = children[index];
            var childWidth = child.DesiredSize.Width;

            // Arrange the child
            child.Arrange(new Rect(x, y, childWidth, rowHeight));

            // Add horizontal gap between children unless it's the last child in the row
            var horizontalGap = index < childCount - 1 ? HorizontalGap : 0.0;

            // Increment horizontal offset,
            x += childWidth + horizontalGap;
        }
    }
    
    private static object CoerceGap(DependencyObject element, object value) => 
        Math.Max(0.0, (double)value);
}