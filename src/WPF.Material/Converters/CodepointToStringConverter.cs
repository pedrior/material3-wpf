using System.Windows.Markup;

namespace WPF.Material.Converters;

[MarkupExtensionReturnType(typeof(CodepointToStringConverter))]
internal sealed class CodepointToStringConverter : MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider services) => this;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is null ? null : char.ConvertFromUtf32((int)value);

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}