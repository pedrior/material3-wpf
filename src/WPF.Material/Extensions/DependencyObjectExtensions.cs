namespace WPF.Material.Extensions;

internal static class DependencyObjectExtensions
{
    public static T? FindParent<T>(this DependencyObject child) where T : DependencyObject
    {
        var element = VisualTreeHelper.GetParent(child);
        return element switch
        {
            null => null,
            T parent => parent,
            _ => FindParent<T>(element)
        };
    }
}