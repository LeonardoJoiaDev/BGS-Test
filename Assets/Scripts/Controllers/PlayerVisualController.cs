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
            spriteRenderers[Item.GetIndexOfType(type)].sprite = itemSprite; 
        }
        else
        {
            spriteRenderers[Item.GetIndexOfType(type)].sprite = spritesEquiped[Item.GetIndexOfType(type)];
        }
    }
    public void EquipItem(Type type, Sprite itemSprite = null)
    {
        int index = Item.GetIndexOfType(type);
        spritesEquiped[index] = (itemSprite != null) ? itemSprite : spritesDefault[index];
        spriteRenderers[index].sprite = spritesEquiped[index];


    }

    
}



