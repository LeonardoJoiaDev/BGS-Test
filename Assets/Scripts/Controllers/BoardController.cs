using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField, Tooltip("Insert button to confirm")]
    Button buttonConfirm;

    [SerializeField, Tooltip("Insert button TmPro")]
    TextMeshProUGUI buttonText;

    BoardType boardType = BoardType.Buy;

    public BoardType BoardType { get => boardType; }

    public void SetItemOnBoard(Transform transform)
    {
        transform.SetParent(content,false);
    }
    public void RemoveItemOnBoard(Transform transform)
    {
        transform.SetParent(content, false);
    }

    public void SetBoardType(BoardType boardType)
    {
        this.boardType = boardType;
        shopController.RemoveSelectedItems(shopController.SelectedItens);

        buttonConfirm.onClick.RemoveAllListeners();

        switch (boardType)
        {
            case BoardType.Buy:
                OrderBoard(shopController.ShopItens);
                buttonText.text = "Confirm Buy";
                buttonConfirm.onClick.AddListener(shopController.ButtonConfirmToBuy);
                break;
            case BoardType.Sell:
                OrderBoard(shopController.ShopItens);
                buttonText.text = "Confirm Sell";
                buttonConfirm.onClick.AddListener(shopController.ButtonConfirmToSell);
                break;
            case BoardType.Inventory:
                OrderBoard(PlayerManager.Instance.InventoryController.PlayerItens);
                buttonText.text = "Equip/Remove";
                buttonConfirm.onClick.AddListener(shopController.ButtonEquip);
                break;
        }

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
     
}

public enum BoardType
{
    Buy,
    Sell,
    Inventory
}

//TODO: mudar texto e funcionalidade de confirm para equip/unequip
//fazer aba de sell listar toso os itens menos os que estao equipados