using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert all Sprite renderer components according to the order of the Type enum")]
    SpriteRenderer[] spriteRenderers = new SpriteRenderer[13];

    Sprite[] spritesDefault = new Sprite[13];

    Sprite[] spritesEquiped = new Sprite[13];

    private void Awake()
    {
        for (int i = 0; i < spritesEquiped.Length; i++)
        {
            spritesEquiped[i] = spriteRenderers[i].sprite;

            spritesDefault[i] = spriteRenderers[i].sprite;
        }
    }

    public void SetTemporaryVisual(Type type, bool setting, Sprite itemSprite = null)
    {
        if (setting)
        {
            spriteRenderers[GetIndexOfType(type)].sprite = itemSprite; 
        }
        else
        {
            spriteRenderers[GetIndexOfType(type)].sprite = spritesEquiped[GetIndexOfType(type)];
        }
    }
    public void EquipItem(Type type, Sprite itemSprite = null)
    {
        int index = GetIndexOfType(type);
        spriteRenderers[index].sprite = (itemSprite != null) ? itemSprite: spritesDefault[index];
        
    }

    public Dictionary<Type, int> typeToIndex = new Dictionary<Type, int>
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

    public int GetIndexOfType(Type type)
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



