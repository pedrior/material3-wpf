namespace WPF.Material.Controls;

/// <summary>
/// Represents a panel that arranges its children in a single layer. The children are arranged in the order they are
/// added to the <see cref="OverlapPanel.Children"/> collection. To control the order of the children, use the
/// <see cref="Panel.ZIndexProperty"/> attached property.
/// </summary>
public class OverlapPanel : Panel
{
    static OverlapPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(OverlapPanel),
            new FrameworkPropertyMetadata(typeof(OverlapPanel)));
    }

    protected override Size MeasureOverride(Size constraints)
    {
        var children = InternalChildren;
        var childrenCount = children.Count;
        
        var width = 0.0;
        var height = 0.0;

        for (var i = 0; i < childrenCount; i++)
        {
            var child = children[i];
            
            child.Measure(constraints);
            
            var childSize = child.DesiredSize;

            width = Math.Max(width, childSize.Width);
            height = Math.Max(height, childSize.Height);
        }

        return new Size(width, height);
    }

    protected override Size ArrangeOverride(Size constraints)
    {
        var children = InternalChildren;
        var childrenCount = children.Count;
        
        for (var i = 0; i < childrenCount; i++)
        {
            var child = children[i];
            
            child.Arrange(new Rect(0.0, 0.0, constraints.Width, constraints.Height));
        }

        return constraints;
    }
}