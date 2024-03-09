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
    }

    private void OnEnable()
    {
        boardController.UpdateBoard(BoardType.Buy);
    }

    public void ButtonConfirm()
    {
        //if(!have money)
        //        return;
        shopItens.RemoveAll(shopButtonController => SelectedItens.Contains(shopButtonController));
        foreach (ShopButtonController item in SelectedItens)
        {
            item.gameObject.SetActive(false);
            item.SetIsSelected(false);
        }

        PlayerManager.Instance.InventoryController.SetNewItem(SelectedItens);

        boardController.UpdateBoard(BoardType.Buy);

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
        
        SelectedItens.Add(obj);
        ChangeCost(obj.CurrentItem.value);
    }

    public void RemoveSelectedItem(ShopButtonController obj)
    {
        SelectedItens.Remove(obj);
        ChangeCost(-obj.CurrentItem.value);
    }

    private void ChangeCost(float value)
    {
        cost += value;
        textCost.text = cost.ToString("F2");

        //if(!have money)
        //        return;
    }

}
