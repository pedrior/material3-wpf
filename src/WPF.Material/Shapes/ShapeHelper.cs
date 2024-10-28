using System.Runtime.CompilerServices;

namespace WPF.Material.Shapes;

internal static class ShapeHelper
{
    private const double NoneRadius = 0.0;
    private const double ExtraSmallRadius = 4.0;
    private const double SmallRadius = 8.0;
    private const double MediumRadius = 12.0;
    private const double LargeRadius = 16.0;
    private const double ExtraLargeRadius = 28.0;

    public static CornerRadius ClampCornerRadius(CornerRadius radius, double width, double height)
    {
        var maxRadius = Math.Min(width, height) * 0.5;

        var tl = Math.Clamp(radius.TopLeft, 0.0, maxRadius);
        var tr = Math.Clamp(radius.TopRight, 0.0, maxRadius);
        var bl = Math.Clamp(radius.BottomLeft, 0.0, maxRadius);
        var br = Math.Clamp(radius.BottomRight, 0.0, maxRadius);

        return new CornerRadius(tl, tr, bl, br);
    }
    
    public static CornerRadius GetRadiusForStyle(ShapeStyle style, ShapeCorner corner, double width, double height)
    {
        var maxRadius = Math.Min(width, height) * 0.5;

        var tl = IsCornerSet(corner, ShapeCorner.TopLeft) ? GetRadiusForStyle(style, maxRadius) : 0.0;
        var tr = IsCornerSet(corner, ShapeCorner.TopRight) ? GetRadiusForStyle(style, maxRadius) : 0.0;
        var bl = IsCornerSet(corner, ShapeCorner.BottomLeft) ? GetRadiusForStyle(style, maxRadius) : 0.0;
        var br = IsCornerSet(corner, ShapeCorner.BottomRight) ? GetRadiusForStyle(style, maxRadius) : 0.0;

        return new CornerRadius(tl, tr, bl, br);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsCornerSet(ShapeCorner value, ShapeCorner flag) => (value & flag) is not 0;

    private static double GetRadiusForStyle(ShapeStyle style, double maxRadius)
    {
        var radius = style switch
        {
            ShapeStyle.None => NoneRadius,
            ShapeStyle.ExtraSmall => ExtraSmallRadius,
            ShapeStyle.Small => SmallRadius,
            ShapeStyle.Medium => MediumRadius,
            ShapeStyle.Large => LargeRadius,
            ShapeStyle.ExtraLarge => ExtraLargeRadius,
            ShapeStyle.Full => maxRadius,
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };

        return Math.Clamp(radius, 0.0, maxRadius);
    }
}