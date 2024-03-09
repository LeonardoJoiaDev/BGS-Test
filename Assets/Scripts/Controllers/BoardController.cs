using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BoardController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert Board Content")]
    Transform content;

    [SerializeField,Tooltip("Insert ShopController")]
    ShopController shopController;

    

    public void SetItemOnBoard(Transform transform)
    {
        transform.SetParent(content,false);
    }
    public void RemoveItemOnBoard(Transform transform)
    {
        transform.SetParent(content, false);
    }
    void OrderBoard(List<ShopButtonController> itens)
    {
        foreach (Transform t in content)
        {
            t.gameObject.SetActive(false);
        }
        foreach (ShopButtonController item in itens)
        {
            item.gameObject.SetActive(true);
        }


    }
    public void UpdateBoard(BoardType type)
    {
        shopController.SelectedItens.ForEach(i => { i.SetIsSelected(false); });

        switch(type)
        {
            case BoardType.Buy:
                OrderBoard(shopController.ShopItens);
                break;
            case BoardType.Sell:
                OrderBoard(shopController.ShopItens);
                break;
            case BoardType.Inventory:
                OrderBoard(PlayerManager.Instance.InventoryController.PlayerItens);
                break;
        }
    }
    public void ButtonBuy()
    {
        UpdateBoard(BoardType.Buy);
    }

    public void ButtonSell()
    {

        UpdateBoard(BoardType.Sell);
    }

    public void ButtonInventory()
    {
        UpdateBoard(BoardType.Inventory);
    }

    
}

public enum BoardType
{
    Buy,
    Sell,
    Inventory
}

//TODO: mudar texto e funcionalidade de confirm para equip/unequip
//fazer aba de sell listar toso os itens menos os que estao equipados