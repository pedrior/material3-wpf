using System.Windows.Markup;

namespace WPF.Material.Converters;

[MarkupExtensionReturnType(typeof(ThicknessToDoubleConverter))]
internal sealed class ThicknessToDoubleConverter : MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider services) => this;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not Thickness thickness
            ? Binding.DoNothing
            : thickness.Left;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}