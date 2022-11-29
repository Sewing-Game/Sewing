#nullable enable

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// 게임 플레이에 대한 상태 값을 저장하는 데 사용되는 Dictionary입니다.
/// </summary>
public class GamePlayProperties
{
    internal const string StoreNameKey = ".storeName";
    internal const string UtcDateTimeFormat = "r";

    /// <summary>
    /// Initializes a new instance of the <see cref="GamePlayProperties"/> class.
    /// </summary>
    public GamePlayProperties()
        : this(items: null)
    { }


    /// <summary>
    /// Initializes a new instance of the <see cref="GamePlayProperties"/> class.
    /// </summary>
    /// <param name="items">State values dictionary to use.</param>
    [JsonConstructor]
    public GamePlayProperties(IDictionary<string, string?>? items)
    {
        Items = items ?? new Dictionary<string, string?>(StringComparer.Ordinal);
    }

    /// <summary>
    /// Gets or sets the full path or absolute URI to be used as an http redirect response value.
    /// </summary>
    [JsonIgnore]
    public string? StoreName
    {
        get => GetString(StoreNameKey);
        set => SetString(StoreNameKey, value);
    }


    /// <summary>
    /// Return a copy.
    /// </summary>
    /// <returns>A copy.</returns>
    public GamePlayProperties Clone()
        => new(new Dictionary<string, string?>(Items, StringComparer.Ordinal));

    /// <summary>
    /// State values about the game play.
    /// </summary>
    public IDictionary<string, string?> Items { get; }

    /// <summary>
    /// Get a string value from the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <returns>Retrieved value or <c>null</c> if the property is not set.</returns>
    public string? GetString(string key)
    {
        return Items.TryGetValue(key, out var value) ? value : null;
    }

    /// <summary>
    /// Set or remove a string value from the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <param name="value">Value to set or <see langword="null" /> to remove the property.</param>
    public void SetString(string key, string? value)
    {
        if (value != null)
        {
            Items[key] = value;
        }
        else
        {
            Items.Remove(key);
        }
    }
   
    /// <summary>
    /// Get a nullable <see cref="bool"/> from the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <returns>Retrieved value or <see langword="null" /> if the property is not set.</returns>
    protected bool? GetBool(string key)
    {
        if (Items.TryGetValue(key, out var value) && bool.TryParse(value, out var boolValue))
        {
            return boolValue;
        }
        return null;
    }

    /// <summary>
    /// Set or remove a <see cref="bool"/> value in the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <param name="value">Value to set or <see langword="null" /> to remove the property.</param>
    protected void SetBool(string key, bool? value)
    {
        if (value.HasValue)
        {
            Items[key] = value.GetValueOrDefault().ToString();
        }
        else
        {
            Items.Remove(key);
        }
    }

    /// <summary>
    /// Get a nullable <see cref="DateTimeOffset"/> value from the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <returns>Retrieved value or <see langword="null" /> if the property is not set.</returns>
    protected DateTimeOffset? GetDateTimeOffset(string key)
    {
        if (Items.TryGetValue(key, out var value)
            && DateTimeOffset.TryParseExact(value, UtcDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dateTimeOffset))
        {
            return dateTimeOffset;
        }
        return null;
    }

    /// <summary>
    /// Sets or removes a <see cref="DateTimeOffset" /> value in the <see cref="Items"/> collection.
    /// </summary>
    /// <param name="key">Property key.</param>
    /// <param name="value">Value to set or <see langword="null" /> to remove the property.</param>
    protected void SetDateTimeOffset(string key, DateTimeOffset? value)
    {
        if (value.HasValue)
        {
            Items[key] = value.GetValueOrDefault().ToString(UtcDateTimeFormat, CultureInfo.InvariantCulture);
        }
        else
        {
            Items.Remove(key);
        }
    }
}
