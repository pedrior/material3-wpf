using System.Collections.Specialized;
using WPF.Material.Environment;

namespace WPF.Material.Controls;

/// <summary>
/// Represents a group of segmented toggle buttons that allows users to select one or multiple options.
/// </summary>
public class ToggleButtonGroup : ItemsControl
{
    /// <summary>
    /// Identifies the <see cref="SelectionChanged"/> routed event.
    /// </summary>
    public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent(
        nameof(SelectionChanged),
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(ToggleButtonGroup));

    /// <summary>
    /// Identifies the <see cref="RequireSelection"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty RequireSelectionProperty = DependencyProperty.Register(
        nameof(RequireSelection),
        typeof(bool),
        typeof(ToggleButtonGroup),
        new PropertyMetadata(false));

    /// <summary>
    /// Identifies the <see cref="SelectionMode"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register(
        nameof(SelectionMode),
        typeof(SelectionMode),
        typeof(ToggleButtonGroup),
        new PropertyMetadata(SelectionMode.Single), ValidateSelectionMode);
    
    /// <summary>
    /// Identifies the <see cref="Spacing"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty = SpacedPanel.SpacingProperty.AddOwner(
        typeof(ToggleButtonGroup),
        new PropertyMetadata(0.0, null, CoerceSpacing));

    /// <summary>
    /// Identifies the <see cref="Orientation"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty OrientationProperty = SpacedPanel.OrientationProperty.AddOwner(
        typeof(ToggleButtonGroup),
        new PropertyMetadata(Orientation.Horizontal));

    /// <summary>
    /// Identifies the <see cref="InnerRadius"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty InnerRadiusProperty = DependencyProperty.Register(
        nameof(InnerRadius),
        typeof(double),
        typeof(ToggleButtonGroup),
        new PropertyMetadata(0.0, null, CoerceCornerRadius));

    /// <summary>
    /// Identifies the <see cref="SelectedIndexFallback"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectedIndexFallbackProperty = DependencyProperty.Register(
        nameof(SelectedIndexFallback),
        typeof(int),
        typeof(ToggleButtonGroup),
        new PropertyMetadata(0));

    private readonly HashSet<int> selectedIndices = new();

    private bool shouldUpdateSelectedIndices = true;

    /// <summary>
    /// Initializes static members of the <see cref="ToggleButtonGroup"/> class.
    /// </summary>
    static ToggleButtonGroup()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ToggleButtonGroup),
            new FrameworkPropertyMetadata(typeof(ToggleButtonGroup)));
    }

    /// <summary>
    /// Occurs when the selection of the toggle button group changes.
    /// </summary>
    public event RoutedEventHandler SelectionChanged
    {
        add => AddHandler(SelectionChangedEvent, value);
        remove => RemoveHandler(SelectionChangedEvent, value);
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the user must select an option.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public bool RequireSelection
    {
        get => (bool)GetValue(RequireSelectionProperty);
        set => SetValue(RequireSelectionProperty, value);
    }

    /// <summary>
    /// Gets or sets the selection mode of the toggle button group.
    /// </summary>
    /// <remarks>
    /// The selection mode <see cref="SelectionMode.Extended"/> is not supported.
    /// </remarks>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public SelectionMode SelectionMode
    {
        get => (SelectionMode)GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }

    /// <summary>
    /// Gets or sets the amount of space between the toggle buttons.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Appearance)]
    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    /// <summary>
    /// Gets or sets the orientation of the toggle button group. 
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Appearance)]
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    /// <summary>
    /// Gets or sets the inner radius of the toggle buttons.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Appearance)]
    public double InnerRadius
    {
        get => (double)GetValue(InnerRadiusProperty);
        set => SetValue(InnerRadiusProperty, value);
    }

    /// <summary>
    /// Gets or sets the fallback toggle button index when no button is selected.
    /// </summary>
    [Bindable(true)]
    [Category(UICategory.Common)]
    public int SelectedIndexFallback
    {
        get => (int)GetValue(SelectedIndexFallbackProperty);
        set => SetValue(SelectedIndexFallbackProperty, value);
    }

    /// <summary>
    /// Gets the currently selected toggle button indices.
    /// </summary>
    public IReadOnlySet<int> SelectedIndices => selectedIndices;

    /// <summary>
    /// Selects the toggle button at the specified index.
    /// </summary>
    /// <remarks>
    /// If the <see cref="SelectionMode"/> is <see cref="float"/>, the currently
    /// selected button, if exists, will be deselected before selecting the new button.
    /// </remarks>
    /// <param name="index">The index of the toggle button to select.</param>
    /// <returns>
    /// <see langword="true"/> if the button was selected; otherwise, <see langword="false"/>.
    /// <para>
    /// It returns <see langword="false"/> if the button is already selected.
    /// </para>
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index"/> is less than 0 or greater than or equal to the number of items in the group.
    /// </exception>
    public bool Select(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (selectedIndices.Contains(index))
        {
            return false;
        }

        // For single selection mode, deselect the currently selected button first
        if (SelectionMode is SelectionMode.Single && selectedIndices.Count is 1)
        {
            DeselectButton(selectedIndices.First());
        }

        SelectButton(index);
        return true;
    }

    /// <summary>
    /// Deselects the toggle button at the specified index.
    /// </summary>
    /// <param name="index">The index of the toggle button to deselect.</param>
    /// <returns>
    /// <see langword="true"/> if the button was deselected; otherwise, <see langword="false"/>.
    /// <para>
    /// It returns <see langword="false"/> if the button is not selected or <see cref="RequireSelection"/> is
    /// <see langword="true"/> and the button is the last selected button in the group.
    /// </para>
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index"/> is less than 0 or greater than or equal to the number of items in the group.
    /// </exception>
    public bool Deselect(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (!selectedIndices.Contains(index))
        {
            return false;
        }

        // Do not deselect the last selected button when selection is required
        if (RequireSelection && IsLastSelectedButton(index))
        {
            return false;
        }

        DeselectButton(index);
        return true;
    }

    /// <summary>
    /// Selects all toggle buttons in the group.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if any button was selected; otherwise, <see langword="false"/>.
    /// <para>
    /// It returns <see langword="false"/> if the <see cref="SelectionMode"/> is <see cref="System.Windows.Controls.SelectionMode.Single"/>
    /// or all buttons are already selected.
    /// </para>
    /// </returns>
    public bool SelectAll()
    {
        // Skip if selection mode is single or all buttons are already selected
        if (SelectionMode is SelectionMode.Single || selectedIndices.Count == Items.Count)
        {
            return false;
        }

        // Select all deselected buttons
        for (var i = 0; i < Items.Count; i++)
        {
            if (!IsButtonSelected(i))
            {
                SelectButton(i);
            }
        }

        return true;
    }

    /// <summary>
    /// Deselects all toggle buttons in the group.
    /// </summary>
    /// <remarks>
    /// If <see cref="RequireSelection"/> is <see langword="true"/>, the fallback toggle button will remain selected.
    /// </remarks>
    /// <returns>
    /// <see langword="true"/> if any button was deselected; otherwise, <see langword="false"/>.
    /// <para>
    /// It returns <see langword="false"/> if no buttons are selected.
    /// </para>
    /// </returns>
    public bool DeselectAll()
    {
        // Skip if no buttons are selected
        if (selectedIndices.Count is 0)
        {
            return false;
        }

        // If selection is required, keep the fallback toggle button selected
        var fallbackIndex = RequireSelection
            ? Math.Clamp(SelectedIndexFallback, -1, Items.Count - 1)
            : -1;

        // Select the fallback button if it is not selected
        if (!selectedIndices.Contains(fallbackIndex) && fallbackIndex >= 0)
        {
            Select(fallbackIndex);
        }

        // Deselect all selected buttons
        for (var i = 0; i < Items.Count; i++)
        {
            if (i != fallbackIndex && IsButtonSelected(i))
            {
                DeselectButton(i);
            }
        }

        return true;
    }

    /// <summary>
    /// Occurs when the selection of the toggle button group changes.
    /// </summary>
    /// <param name="e">The event data.</param>
    protected virtual void OnSelectionChanged(RoutedEventArgs e) => RaiseEvent(e);

    protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    {
        base.OnItemsChanged(e);

        if (shouldUpdateSelectedIndices)
        {
            UpdateSelectedIndices();
        }
    }

    internal void Toggle(ToggleButton button)
    {
        var index = Items.IndexOf(button);
        if (index is -1)
        {
            throw new ArgumentException("The button specified is not part of the group.");
        }

        var isSelected = IsButtonSelected(index);
        if (SelectionMode is SelectionMode.Single)
        {
            if (isSelected && !RequireSelection)
            {
                DeselectButton(index);
            }
            else
            {
                DeselectButtonsExcept(index);
                SelectButton(index);
            }
        }
        else
        {
            if (isSelected && !(RequireSelection && IsLastSelectedButton(index)))
            {
                DeselectButton(index);
            }
            else
            {
                SelectButton(index);
            }
        }
    }

    private bool IsButtonSelected(int index) => selectedIndices.Contains(index);

    private void SelectButton(int index) => SetButtonSelectState(index, true);

    private void DeselectButton(int index) => SetButtonSelectState(index, false);

    private void SetButtonSelectState(int index, bool selected)
    {
        if (Items[index] is not ToggleButton item)
        {
            return;
        }

        item.IsChecked = selected;

        if (selected)
        {
            selectedIndices.Add(index);
        }
        else
        {
            selectedIndices.Remove(index);
        }

        OnSelectionChanged(new RoutedEventArgs(SelectionChangedEvent));
    }

    private void DeselectButtonsExcept(int index)
    {
        foreach (var i in selectedIndices.Where(i => i != index))
        {
            DeselectButton(i);
        }
    }

    private bool IsLastSelectedButton(int index) => selectedIndices.Count is 1 && selectedIndices.Contains(index);

    private void UpdateSelectedIndices()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i] is ToggleButton { IsChecked: true })
            {
                selectedIndices.Add(i);
            }
        }

        shouldUpdateSelectedIndices = false;
    }
    
    private static bool ValidateSelectionMode(object value) => 
        value is SelectionMode.Single or SelectionMode.Multiple;


    private static object CoerceSpacing(DependencyObject element, object value) => Math.Max(0.0, (double)value);

    private static object CoerceCornerRadius(DependencyObject element, object value) => Math.Max(0.0, (double)value);
}