using System;
using UnityEngine;

/// <summary>
/// Note attribute
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class NoteAttribute : PropertyAttribute
{
    public string Text = string.Empty;
    public MessageType messageType = MessageType.None;

    public NoteAttribute(string text) => Text = text;
}
