﻿namespace WPF.Material.Assists;

/// <summary>
/// Provides attached properties for interaction management.
/// </summary>
public static class InteractionAssist
{
    /// <summary>
    /// Identifies the IsHovered attached property.
    /// </summary>
    public static readonly DependencyProperty IsHoveredProperty = DependencyProperty.RegisterAttached(
        "IsHovered",
        typeof(bool),
        typeof(InteractionAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the IsPressed attached property.
    /// </summary>
    public static readonly DependencyProperty IsPressedProperty = DependencyProperty.RegisterAttached(
        "IsPressed",
        typeof(bool),
        typeof(InteractionAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the IsDragged attached property.
    /// </summary>
    public static readonly DependencyProperty IsDraggedProperty = DependencyProperty.RegisterAttached(
        "IsDragged",
        typeof(bool),
        typeof(InteractionAssist),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the IsEnabled attached property.
    /// </summary>
    public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
        "IsEnabled",
        typeof(bool),
        typeof(InteractionAssist),
        new PropertyMetadata(true));

    /// <summary>
    /// Sets the value of the <see cref="IsHoveredProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="IsHoveredProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetIsHovered(DependencyObject element, bool value) => element.SetValue(IsHoveredProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="IsHoveredProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="IsHoveredProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="IsHoveredProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetIsHovered(DependencyObject element) => (bool)element.GetValue(IsHoveredProperty);

    /// <summary>
    /// Sets the value of the <see cref="IsPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="IsPressedProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetIsPressed(DependencyObject element, bool value) => element.SetValue(IsPressedProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="IsPressedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="IsPressedProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="IsPressedProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetIsPressed(DependencyObject element) => (bool)element.GetValue(IsPressedProperty);

    /// <summary>
    /// Sets the value of the <see cref="IsDraggedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="IsDraggedProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetIsDragged(DependencyObject element, bool value) => element.SetValue(IsDraggedProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="IsDraggedProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="IsDraggedProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="IsDraggedProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetIsDragged(DependencyObject element) => (bool)element.GetValue(IsDraggedProperty);

    /// <summary>
    /// Sets the value of the <see cref="IsEnabledProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to set the value of the <see cref="IsEnabledProperty"/> property.
    /// </param>
    /// <param name="value">The new value to set the property to.</param>
    public static void SetIsEnabled(DependencyObject element, bool value) =>
        element.SetValue(IsEnabledProperty, value);

    /// <summary>
    /// Gets the value of the <see cref="IsEnabledProperty"/> attached property for a specified dependency object.
    /// </summary>
    /// <param name="element">
    /// The dependency object for which to retrieve the value of the <see cref="IsEnabledProperty"/> property.
    /// </param>
    /// <returns>
    /// The current value of the <see cref="IsEnabledProperty"/> attached property on the specified dependency object.
    /// </returns>
    public static bool GetIsEnabled(DependencyObject element) => (bool)element.GetValue(IsEnabledProperty);
}