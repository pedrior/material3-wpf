using WPF.Material.Shapes;

namespace WPF.Material.Assists;

/// <summary>
/// Provides attached properties for shape management.
/// </summary>
public static class ShapeAssist
{
    /// <summary>
    /// Identifies the Family attached property.
    /// </summary>
    public static readonly DependencyProperty FamilyProperty = DependencyProperty.RegisterAttached(
        "Family",
        typeof(ShapeFamily),
        typeof(ShapeAssist),
        new FrameworkPropertyMetadata(ShapeFamily.Rounded, FrameworkPropertyMetadataOptions.Inherits));

    /// <summary>
    /// Identifies the Style attached property.
    /// </summary>
    public static readonly DependencyProperty StyleProperty = DependencyProperty.RegisterAttached(
        "Style",
        typeof(ShapeStyle),
        typeof(ShapeAssist),
        new PropertyMetadata(ShapeStyle.None));

    /// <summary>
    /// Identifies the Corner attached property.
    /// </summary>
    public static readonly DependencyProperty CornerProperty = DependencyProperty.RegisterAttached(
        "Corner",
        typeof(ShapeCorner),
        typeof(ShapeAssist),
        new PropertyMetadata(ShapeCorner.All));

    /// <summary>
    /// Identifies the ShapeRadius attached property.
    /// </summary>
    public static readonly DependencyProperty RadiusProperty = DependencyProperty.RegisterAttached(
        "Radius",
        typeof(CornerRadius?),
        typeof(ShapeAssist),
        new PropertyMetadata(default(CornerRadius?)));

    /// <summary>
    /// Sets the value of the <see cref="FamilyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="FamilyProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetFamily(DependencyObject element, ShapeFamily value) =>
        element.SetValue(FamilyProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="FamilyProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="FamilyProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="FamilyProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static ShapeFamily GetFamily(DependencyObject element) => (ShapeFamily)element.GetValue(FamilyProperty);

    /// <summary>
    /// Sets the value of the <see cref="StyleProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="StyleProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetStyle(DependencyObject element, ShapeStyle value) => element.SetValue(StyleProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="StyleProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="StyleProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="StyleProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static ShapeStyle GetStyle(DependencyObject element) => (ShapeStyle)element.GetValue(StyleProperty);

    /// <summary>
    /// Sets the value of the <see cref="CornerProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="CornerProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetCorner(DependencyObject element, ShapeCorner value) =>
        element.SetValue(CornerProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="CornerProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="CornerProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="CornerProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static ShapeCorner GetCorner(DependencyObject element) => (ShapeCorner)element.GetValue(CornerProperty);

    /// <summary>
    /// Sets the value of the <see cref="RadiusProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="RadiusProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetRadius(DependencyObject element, CornerRadius value) => element.SetValue(RadiusProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="RadiusProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="RadiusProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="RadiusProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static CornerRadius? GetRadius(DependencyObject element) => (CornerRadius?)element.GetValue(RadiusProperty);
}