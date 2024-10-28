using System.Windows.Input;

namespace WPF.Material.Controls;

/// <summary>
/// Represents a selectable item in a <see cref="NavigationRail"/>.
/// </summary>
[TemplatePart(Name = PartRipple, Type = typeof(Ripple))]
public class NavigationRailItem : NavigationItem
{
    private const string PartRipple = "PART_Ripple";

    private Ripple ripple = null!;
    
    static NavigationRailItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NavigationRailItem),
            new FrameworkPropertyMetadata(typeof(NavigationRailItem)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        ripple = GetTemplateChild(PartRipple) as Ripple
                 ?? throw new InvalidOperationException($"Missing required template part: {PartRipple}");
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        
        StartRipple();
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);
        
        ReleaseRipple();
    }

    protected override void OnMouseLeave(MouseEventArgs e)
    {
        ReleaseRipple();
        
        base.OnMouseLeave(e);
    }

    private void StartRipple() => ripple.Start(keep: true);

    private void ReleaseRipple() => ripple.Release();
}