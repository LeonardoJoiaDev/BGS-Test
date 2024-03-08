using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item: ScriptableObject
{
    public Sprite sprite;
    public float value;
    public Type type;
}

public enum Type
{
    head,
    hood
}

