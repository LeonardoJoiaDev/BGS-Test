using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    List<ShopButtonController> playerItens = new List<ShopButtonController>();
    ShopButtonController[] equipedItens = new ShopButtonController[14];
    public List<ShopButtonController> PlayerItens { get => playerItens; }
    public ShopButtonController[] EquipedItens { get => equipedItens; }

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
    public void RemovePlayerItens(List<ShopButtonController> removedItens)
    {
        playerItens.RemoveAll(shopButtonController => removedItens.Contains(shopButtonController));
    }

    public void EquipItem(ShopButtonController shopButtonController)
    {
        int index = Item.GetIndexOfType(shopButtonController.CurrentItem.type);
        if (equipedItens[index] != null)
        {
            equipedItens[index].EquipItem(false);
        }
        if (shopButtonController == equipedItens[index])
        {
            equipedItens[index] = null;
            shopButtonController.EquipItem(false);
            PlayerManager.Instance.VisualController.EquipItem(shopButtonController.CurrentItem.type);
            return;
        }
        equipedItens[index] = shopButtonController;
        shopButtonController.EquipItem(true);
        PlayerManager.Instance.VisualController.EquipItem(
            shopButtonController.CurrentItem.type, 
            shopButtonController.CurrentItem.sprite
            );
        
    }

    public List<ShopButtonController> GetItensToSell()
    {
        List<ShopButtonController> sellItens = new List<ShopButtonController>();
        sellItens = playerItens.Except(equipedItens).ToList();
        return sellItens;
    }

}
