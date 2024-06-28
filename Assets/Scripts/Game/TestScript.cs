using UnityEngine;

/// <summary>
/// TestScript
/// </summary>
//[Component("Test Script", "A script for testing features such as attributes, templates or utilities.")]
public class TestScript : MonoBehaviour
{
    [Note("This is a very important note, because it is noted!", messageType = MessageType.Warning)]
    [Required]
    [SerializeField] private string description;
}