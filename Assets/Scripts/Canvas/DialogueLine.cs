using System;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    [TextArea(2, 5)]
    public string text;
    public bool isCharacter1;
}
