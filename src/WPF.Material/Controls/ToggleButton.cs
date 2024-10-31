namespace WPF.Material.Controls;

/// <summary>
/// Represents a toggle button, which is a control that can switch states. This control is typically used in
/// conjunction with the <see cref="ToggleButtonGroup"/> control.
/// </summary>
public class ToggleButton : System.Windows.Controls.Primitives.ToggleButton
{
    static ToggleButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ToggleButton),
            new FrameworkPropertyMetadata(typeof(ToggleButton)));
        
        // We don't support the three state behavior
        IsThreeStateProperty.OverrideMetadata(
            typeof(ToggleIconButton),
            new FrameworkPropertyMetadata(false, null, CoerceIsChecked));
    }

    protected override void OnToggle()
    {
        if (Parent is ToggleButtonGroup group)
        {
            group.ToggleItem(this);
        }
        else
        {
            base.OnToggle();
        }
    }
    
    private static object CoerceIsChecked(DependencyObject element, object value) => false;
}