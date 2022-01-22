using UnityEngine;
using System;

public enum HelpBoxType
{
    /// <summary>
    ///   <para>Neutral message.</para>
    /// </summary>
    None,
    /// <summary>
    ///   <para>Info message.</para>
    /// </summary>
    Info,
    /// <summary>
    ///   <para>Warning message.</para>
    /// </summary>
    Warning,
    /// <summary>
    ///   <para>Error message.</para>
    /// </summary>
    Error
}

[AttributeUsage(AttributeTargets.Field)]
public class HelpBoxAttribute : PropertyAttribute
{
    public HelpBoxAttribute(string text, HelpBoxType type = HelpBoxType.Info)
    {
        Text = text;
        Type = type;
    }

    public string Text { get; }
    public HelpBoxType Type { get; }
}