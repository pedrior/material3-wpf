﻿using System.Windows.Markup;

namespace WPF.Material.Theming;

/// <summary>
/// A specialized <see cref="ResourceDictionary"/> that provides the necessary resources for the Material Design
/// components. This resource dictionary is responsible for initializing the theme resources and applying the
/// application's <see cref="Theme"/>. It also initializes the <see cref="ThemeService"/> for theme management.
/// </summary>
[Ambient]
[UsableDuringInitialization(true)]
[Localizability(LocalizationCategory.Ignore)]
public sealed class ThemeResources : ResourceDictionary
{
    private ThemeRunner? runner;
    private Theme? theme;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeResources"/> class.
    /// </summary>
    public ThemeResources() => Initialize();

    /// <summary>
    /// Gets or sets the current <see cref="Theme"/> of the application.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the getter is accessed and the <see cref="Theme"/> is not set.
    /// </exception>
    public Theme Theme
    {
        get => theme ?? throw new InvalidOperationException("Theme is not set.");
        set
        {
            if (theme == value)
            {
                return;
              
            }

            runner!.ApplyTheme(value);
            theme = value;
        }
    }

    private void Initialize()
    {
        if (ThemeService.Instance.IsInitialized)
        {
            throw new InvalidOperationException("Attempt to initialize theme resources more than once detected, " +
                                                "which is not allowed. Make sure that " +
                                                $"'{nameof(ThemeResources)}' is only being instantiated once, " +
                                                "and preferably in App.xaml as a merged resource dictionary.");
        }

        runner = new ThemeRunner(this);

        MergeComponentResources();

        ThemeService.Instance.Initialize(this);
    }

    private void MergeComponentResources()
    {
        string[] components =
        {
            "Button",
            "Container",
            "Divider",
            "FloatingActionButton",
            "Icon",
            "IconButton",
            "NavigationRail",
            "Ripple",
            "ToggleButtonGroup",
            "ToolTip"
        };

        foreach (var component in components)
        {
            MergedDictionaries.Add(new ResourceDictionary
            {
                Source = Resources.PackUri($"/Theming/XAML/{component}.xaml")
            });
        }
    }
}