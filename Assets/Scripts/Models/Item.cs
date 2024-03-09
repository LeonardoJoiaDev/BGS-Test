using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item: ScriptableObject
{
    public Sprite sprite;
    public float value;
    public Type type;

    public static Dictionary<Type, int> typeToIndex = new Dictionary<Type, int>
    {
        { Type.bootL, 0 },
        { Type.bootR, 1 },
        { Type.elbowL, 2 },
        { Type.elbowR, 3 },
        { Type.face, 4 },
        { Type.hood, 5 },
        { Type.legL, 6 },
        { Type.legR, 7 },
        { Type.pelvis, 8 },
        { Type.shoulderL, 9 },
        { Type.shoulderR, 10 },
        { Type.torso, 11 },
        { Type.wristL, 12 },
        { Type.wristR, 13 }
    };

    public static int GetIndexOfType(Type type)
    {
        int index;
        if (typeToIndex.TryGetValue(type, out index))
        {
            return index;
        }
        else
        {
            Debug.LogError("Type not found in dictionary: " + type);
            return -1;
        }
    }
}

public enum Type
{
    bootL,
    bootR,
    elbowL,
    elbowR,
    face,
    hood,
    legL,
    legR,
    pelvis,
    shoulderL,
    shoulderR,
    torso,
    wristL,
    wristR
}




