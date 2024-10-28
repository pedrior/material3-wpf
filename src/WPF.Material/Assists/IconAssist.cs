using WPF.Material.Controls;

namespace WPF.Material.Assists;

/// <summary>
/// Provides attached properties for iconography.
/// </summary>
public static class IconAssist
{
    /// <summary>
    /// Identifies the Icon attached property.
    /// </summary>
    public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached(
        "Icon",
        typeof(Symbol?),
        typeof(IconAssist),
        new PropertyMetadata(null));

    /// <summary>
    /// Identifies the HoverIcon attached property.
    /// </summary>
    public static readonly DependencyProperty HoverIconProperty = DependencyProperty.RegisterAttached(
        "HoverIcon",
        typeof(Symbol?),
        typeof(IconAssist),
        new PropertyMetadata(null));

    /// <summary>
    /// Identifies the SelectIcon attached property.
    /// </summary>
    public static readonly DependencyProperty SelectIconProperty = DependencyProperty.RegisterAttached(
        "SelectIcon",
        typeof(Symbol?),
        typeof(IconAssist),
        new PropertyMetadata(null));
    
    /// <summary>
    /// Identifies the DeselectIcon attached property.
    /// </summary>
    public static readonly DependencyProperty DeselectIconProperty = DependencyProperty.RegisterAttached(
        "DeselectIcon",
        typeof(Symbol?),
        typeof(IconAssist),
        new PropertyMetadata(null));

    /// <summary>
    /// Identifies the Size attached property.
    /// </summary>
    public static readonly DependencyProperty SizeProperty = DependencyProperty.RegisterAttached(
        "Size",
        typeof(double),
        typeof(IconAssist),
        new PropertyMetadata(18.0));

    /// <summary>
    /// Identifies the Style attached property.
    /// </summary>
    public static readonly DependencyProperty StyleProperty = DependencyProperty.RegisterAttached(
        "Style",
        typeof(SymbolStyle),
        typeof(IconAssist),
        new FrameworkPropertyMetadata(SymbolStyle.Rounded, FrameworkPropertyMetadataOptions.Inherits));

    /// <summary>
    /// Identifies the Fill attached property.
    /// </summary>
    public static readonly DependencyProperty FillProperty = DependencyProperty.RegisterAttached(
        "Fill",
        typeof(bool),
        typeof(IconAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the FillOnHover attached property.
    /// </summary>
    public static readonly DependencyProperty FillOnHoverProperty = DependencyProperty.RegisterAttached(
        "FillOnHover",
        typeof(bool),
        typeof(IconAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the FillOnPressed attached property.
    /// </summary>
    public static readonly DependencyProperty FillOnPressedProperty = DependencyProperty.RegisterAttached(
        "FillOnPressed",
        typeof(bool),
        typeof(IconAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the FillOnSelect attached property.
    /// </summary>
    public static readonly DependencyProperty FillOnSelectProperty = DependencyProperty.RegisterAttached(
        "FillOnSelect",
        typeof(bool),
        typeof(IconAssist),
        new PropertyMetadata(false));
    
    /// <summary>
    /// Identifies the FillOnDeselect attached property.
    /// </summary>
    public static readonly DependencyProperty FillOnDeselectProperty = DependencyProperty.RegisterAttached(
        "FillOnDeselect",
        typeof(bool),
        typeof(IconAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the Weight attached property.
    /// </summary>
    public static readonly DependencyProperty WeightProperty = DependencyProperty.RegisterAttached(
        "Weight",
        typeof(FontWeight),
        typeof(IconAssist),
        new PropertyMetadata(FontWeights.Normal));

    /// <summary>
    /// Identifies the WeightOnHover attached property.
    /// </summary>
    public static readonly DependencyProperty WeightOnHoverProperty = DependencyProperty.RegisterAttached(
        "WeightOnHover",
        typeof(FontWeight),
        typeof(IconAssist),
        new PropertyMetadata(FontWeights.Normal));

    /// <summary>
    /// Identifies the WeightOnPressed attached property.
    /// </summary>
    public static readonly DependencyProperty WeightOnPressedProperty = DependencyProperty.RegisterAttached(
        "WeightOnPressed",
        typeof(FontWeight),
        typeof(IconAssist),
        new PropertyMetadata(FontWeights.Normal));

    /// <summary>
    /// Identifies the WeightOnSelect attached property.
    /// </summary>
    public static readonly DependencyProperty WeightOnSelectProperty = DependencyProperty.RegisterAttached(
        "WeightOnSelect",
        typeof(FontWeight),
        typeof(IconAssist),
        new PropertyMetadata(FontWeights.Normal));
    
    /// <summary>
    /// Identifies the WeightOnDeselectProperty attached property.
    /// </summary>
    public static readonly DependencyProperty WeightOnDeselectProperty = DependencyProperty.RegisterAttached(
        "WeightOnDeselect",
        typeof(FontWeight),
        typeof(IconAssist),
        new PropertyMetadata(FontWeights.Normal));

    /// <summary>
    /// Gets the value of the <see cref="IconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="IconProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="IconProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static Symbol? GetIcon(DependencyObject element) => (Symbol?)element.GetValue(IconProperty);

    /// <summary>
    /// Sets the value of the <see cref="IconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="IconProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetIcon(DependencyObject element, Symbol? value) => element.SetValue(IconProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="HoverIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="HoverIconProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="HoverIconProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static Symbol? GetHoverIcon(DependencyObject element) => (Symbol?)element.GetValue(HoverIconProperty);

    /// <summary>
    /// Sets the value of the <see cref="HoverIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="HoverIconProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetHoverIcon(DependencyObject element, Symbol? value) =>
        element.SetValue(HoverIconProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="SelectIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="SelectIconProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="SelectIconProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static Symbol? GetSelectIcon(DependencyObject element) => (Symbol?)element.GetValue(SelectIconProperty);

    /// <summary>
    /// Sets the value of the <see cref="SelectIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="SelectIconProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetSelectIcon(DependencyObject element, Symbol? value) =>
        element.SetValue(SelectIconProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="DeselectIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="DeselectIconProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="DeselectIconProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static Symbol? GetDeselectIcon(DependencyObject element) => (Symbol?)element.GetValue(DeselectIconProperty);

    /// <summary>
    /// Sets the value of the <see cref="DeselectIconProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="DeselectIconProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetDeselectIcon(DependencyObject element, Symbol? value) =>
        element.SetValue(DeselectIconProperty, value);
    
    /// <summary>
    /// Sets the value of the <see cref="SizeProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="SizeProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetSize(DependencyObject element, double value) => element.SetValue(SizeProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="SizeProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="SizeProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="SizeProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static double GetSize(DependencyObject element) => (double)element.GetValue(SizeProperty);

    /// <summary>
    /// Sets the value of the <see cref="StyleProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="StyleProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetStyle(DependencyObject element, SymbolStyle value) => element.SetValue(StyleProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="StyleProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="StyleProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="StyleProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static SymbolStyle GetStyle(DependencyObject element) => (SymbolStyle)element.GetValue(StyleProperty);

    /// <summary>
    /// Sets the value of the <see cref="FillProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FillProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFill(DependencyObject element, bool value) => element.SetValue(FillProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FillProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FillProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FillProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetFill(DependencyObject element) => (bool)element.GetValue(FillProperty);

    /// <summary>
    /// Sets the value of the <see cref="FillOnHoverProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FillOnHoverProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFillOnHover(DependencyObject element, bool value) =>
        element.SetValue(FillOnHoverProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FillOnHoverProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FillOnHoverProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FillOnHoverProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetFillOnHover(DependencyObject element) => (bool)element.GetValue(FillOnHoverProperty);

    /// <summary>
    /// Sets the value of the <see cref="FillOnPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FillOnPressedProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFillOnPressed(DependencyObject element, bool value) =>
        element.SetValue(FillOnPressedProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FillOnPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FillOnPressedProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FillOnPressedProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetFillOnPressed(DependencyObject element) => (bool)element.GetValue(FillOnPressedProperty);

    /// <summary>
    /// Sets the value of the <see cref="FillOnSelectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FillOnSelectProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFillOnSelect(DependencyObject element, bool value) =>
        element.SetValue(FillOnSelectProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FillOnSelectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FillOnSelectProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FillOnSelectProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetFillOnSelect(DependencyObject element) => (bool)element.GetValue(FillOnSelectProperty);

    /// <summary>
    /// Sets the value of the <see cref="FillOnDeselectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FillOnDeselectProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFillOnDeselect(DependencyObject element, bool value) =>
        element.SetValue(FillOnDeselectProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FillOnDeselectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FillOnDeselectProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FillOnDeselectProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetFillOnDeselect(DependencyObject element) => (bool)element.GetValue(FillOnDeselectProperty);
    
    /// <summary>
    /// Sets the value of the <see cref="WeightProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="WeightProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetWeight(DependencyObject element, FontWeight value) => element.SetValue(WeightProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="WeightProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="WeightProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="WeightProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static FontWeight GetWeight(DependencyObject element) => (FontWeight)element.GetValue(WeightProperty);

    /// <summary>
    /// Sets the value of the <see cref="WeightOnHoverProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="WeightOnHoverProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetWeightOnHover(DependencyObject element, FontWeight value) =>
        element.SetValue(WeightOnHoverProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="WeightOnHoverProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="WeightOnHoverProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="WeightOnHoverProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static FontWeight GetWeightOnHover(DependencyObject element) =>
        (FontWeight)element.GetValue(WeightOnHoverProperty);

    /// <summary>
    /// Sets the value of the <see cref="WeightOnPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="WeightOnPressedProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetWeightOnPressed(DependencyObject element, FontWeight value) =>
        element.SetValue(WeightOnPressedProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="WeightOnPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="WeightOnPressedProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="WeightOnPressedProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static FontWeight GetWeightOnPressed(DependencyObject element) =>
        (FontWeight)element.GetValue(WeightOnPressedProperty);

    /// <summary>
    /// Sets the value of the <see cref="WeightOnSelectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="WeightOnSelectProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetWeightOnSelect(DependencyObject element, FontWeight value) =>
        element.SetValue(WeightOnSelectProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="WeightOnSelectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="WeightOnSelectProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="WeightOnSelectProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static FontWeight GetWeightOnSelect(DependencyObject element) =>
        (FontWeight)element.GetValue(WeightOnSelectProperty);
    
    /// <summary>
    /// Sets the value of the <see cref="WeightOnDeselectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="WeightOnDeselectProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetWeightOnDeselect(DependencyObject element, FontWeight value) =>
        element.SetValue(WeightOnDeselectProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="WeightOnDeselectProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="WeightOnDeselectProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="WeightOnDeselectProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static FontWeight GetWeightOnDeselect(DependencyObject element) =>
        (FontWeight)element.GetValue(WeightOnDeselectProperty);
}