using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    List<ShopButtonController> playerItens = new List<ShopButtonController>();

    public List<ShopButtonController> PlayerItens { get => playerItens; }

    public void SetNewItem(ShopButtonController shopButtonController)
    {
        playerItens.Add(shopButtonController);
    }
    public void SetNewItem(List<ShopButtonController> shopButtonControllers)
    {
        playerItens.AddRange(shopButtonControllers);
    }

    public void RemovePlayerItem(ShopButtonController shopButtonController)
    {
        playerItens.Remove(shopButtonController);
    }
}
