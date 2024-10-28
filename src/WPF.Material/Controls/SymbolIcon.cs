﻿using WPF.Material.Environment;

namespace WPF.Material.Controls;

/// <summary>
/// Represents a control that displays a <see cref="Controls.Symbol"/> as an icon.
/// </summary>
public class SymbolIcon : Control
{
    /// <summary>
    /// Identifies the <see cref="Symbol"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
        nameof(Symbol),
        typeof(Symbol?),
        typeof(SymbolIcon),
        new PropertyMetadata(DefaultSymbol, null, CoerceSymbol));

    /// <summary>
    /// Identifies the <see cref="SymbolStyle"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SymbolStyleProperty = DependencyProperty.Register(
        nameof(SymbolStyle),
        typeof(SymbolStyle),
        typeof(SymbolIcon),
        new PropertyMetadata(SymbolStyle.Rounded));

    /// <summary>
    /// Identifies the <see cref="IsFilled"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsFilledProperty = DependencyProperty.Register(
        nameof(IsFilled),
        typeof(bool),
        typeof(SymbolIcon),
        new PropertyMetadata(false));

    private const Symbol DefaultSymbol = Controls.Symbol.Category;
    
    /// <summary>
    /// Initializes static members of the <see cref="SymbolIcon"/> class.
    /// </summary>
    static SymbolIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SymbolIcon),
            new FrameworkPropertyMetadata(typeof(SymbolIcon)));
    }

    /// <summary>
    /// Gets or sets the symbol to display.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public Symbol? Symbol
    {
        get => (Symbol?)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }

    /// <summary>
    /// Gets or sets the style of the symbol.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public SymbolStyle SymbolStyle
    {
        get => (SymbolStyle)GetValue(SymbolStyleProperty);
        set => SetValue(SymbolStyleProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the symbol is filled.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public bool IsFilled
    {
        get => (bool)GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }
    
    private static object CoerceSymbol(DependencyObject element, object? value) => 
        value ?? (((SymbolIcon)element).Symbol ?? DefaultSymbol);
}