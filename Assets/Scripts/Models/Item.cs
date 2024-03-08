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
    

