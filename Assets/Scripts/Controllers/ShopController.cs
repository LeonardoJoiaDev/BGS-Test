using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert Board Controller")]
    BoardController boardController; 

    [SerializeField, Tooltip("Insert prefab Shop Button")]
    GameObject shopButtonPrefab;

    [SerializeField,Tooltip("Insert itens Library")]
    ShopItensLibrary shopItensLibrary;

    [SerializeField, Tooltip("Insert player visual controller ")]
    PlayerVisualController playerVisualController;

    [SerializeField, Tooltip("insert textmesh pro for cost")]
    TextMeshProUGUI textCost;

    [SerializeField, Tooltip("insert textmesh pro for Balance")]
    TextMeshProUGUI textBalance;

    [SerializeField, Tooltip("insert PopUp transform")]
    Transform popup;

    [SerializeField, Tooltip("insert store ")]
    Transform store;

    [SerializeField, Tooltip("insert exit Store Point ")]
    Transform exitStorePoint;

    float cost;

    List<ShopButtonController> shopItens = new List<ShopButtonController>();

    List<ShopButtonController> selectedItens = new List<ShopButtonController>();
    public List<ShopButtonController> SelectedItens { get => selectedItens; }
    public List<ShopButtonController> ShopItens { get => shopItens;  }

    private void Start()
    {
        InitializeShopItens(shopButtonPrefab, shopItensLibrary.Itens);
        selectedItens = new List<ShopButtonController>();
        ChangeCost(0);
        textBalance.text = PlayerManager.Instance.PlayerBalance.ToString("F2");
        popup.gameObject.SetActive(false);

        textBalance.text = PlayerManager.Instance.PlayerBalance.ToString();
    }

    private void OnEnable()
    {
        boardController.SetBoardType(BoardType.Buy);
        if(PlayerManager.Instance!=null)
            textBalance.text = PlayerManager.Instance.PlayerBalance.ToString();
        
    }

    public void ButtonConfirmToBuy()
    {
        if(PlayerManager.Instance.PlayerBalance < cost)
        {
            popup.gameObject.SetActive(true);
            return;
        }
        PlayerManager.Instance.ChangeBalance(-cost);
        textBalance.text = PlayerManager.Instance.PlayerBalance.ToString();

        shopItens.RemoveAll(shopButtonController => SelectedItens.Contains(shopButtonController));

        selectedItens.ForEach(item => item.gameObject.SetActive(false));

        PlayerManager.Instance.InventoryController.SetNewItem(SelectedItens);

        RemoveSelectedItems(selectedItens);
    }
    public void ButtonConfirmToSell()
    {
        PlayerManager.Instance.ChangeBalance(cost);
        textBalance.text = PlayerManager.Instance.PlayerBalance.ToString();
        shopItens.AddRange(SelectedItens);
        selectedItens.ForEach(item => item.gameObject.SetActive(false));

        PlayerManager.Instance.InventoryController.RemovePlayerItens(SelectedItens);
        RemoveSelectedItems(selectedItens);
    }

    public void ButtonEquip()
    {
        foreach(ShopButtonController item in selectedItens)
        {
            PlayerManager.Instance.InventoryController.EquipItem(item);
        }

        RemoveSelectedItems(selectedItens);
    } 

    public void InitializeShopItens(GameObject prefab, List<Item> itens)
    {
        foreach (Item item in itens)
        {
            GameObject go = Instantiate(prefab);
            ShopButtonController shopButtonController = go.GetComponent<ShopButtonController>();
            shopButtonController.SetItem(item, this);
            shopItens.Add(shopButtonController);
            boardController.SetItemOnBoard(go.transform);
        }
    }

    public void AddSelectedItem(ShopButtonController obj)
    {
        if (boardController.BoardType != BoardType.Sell)
        {
            if (SelectedItens.Any(item => item.CurrentItem.type == obj.CurrentItem.type))
            {
                List<ShopButtonController> itemsToRemove;
                itemsToRemove = SelectedItens.FindAll(item => item.CurrentItem.type == obj.CurrentItem.type);

                foreach (ShopButtonController item in itemsToRemove)
                {
                    RemoveSelectedItem(item);
                    item.SetIsSelected(false);
                }
            }
        }

        SelectedItens.Add(obj);
        obj.SetIsSelected(true);
        ChangeCost(obj.CurrentItem.value);
    }

    public void RemoveSelectedItem(ShopButtonController obj)
    {
        obj.SetIsSelected(false);
        ChangeCost(-obj.CurrentItem.value);
        SelectedItens.Remove(obj);
    }

    public void RemoveSelectedItems(List<ShopButtonController> objs)
    {
        foreach (ShopButtonController obj in objs)
        {
            obj.SetIsSelected(false);
            ChangeCost(-obj.CurrentItem.value);
        }
        SelectedItens.RemoveAll(shopButtonController => SelectedItens.Contains(shopButtonController));
    }

    private void ChangeCost(float value)
    {
        cost += value;
        textCost.text = cost.ToString("F2");
        textCost.color = (PlayerManager.Instance.PlayerBalance < cost) ? Color.red : Color.black;
        
    }

    public void ButtonBuy()
    {
        boardController.SetBoardType(BoardType.Buy);
    }

    public void ButtonSell()
    {
        boardController.SetBoardType(BoardType.Sell);
    }

    public void ButtonInventory()
    {
        boardController.SetBoardType(BoardType.Inventory);
    }

    public void ButtonBack()
    {
        store.gameObject.SetActive(false);
        PlayerManager.Instance.PlayerController.IsNearShop = false;
        PlayerManager.Instance.transform.parent = null;
        PlayerManager.Instance.transform.localScale = Vector3.one;
        PlayerManager.Instance.transform.position = exitStorePoint.position;

    }

    public void OpenStore()
    {
        PlayerManager.Instance.transform.parent = store.GetChild(0).GetChild(0);

        store.gameObject.SetActive(true);
    }
}
