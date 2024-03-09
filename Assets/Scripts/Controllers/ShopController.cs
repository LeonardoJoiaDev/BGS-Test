using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert Board Controller 1")]
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

    public List<ShopButtonController> SelectedItens { get; private set; }

    private void Start()
    {
        InitializeShopItens(shopButtonPrefab, shopItensLibrary.Itens);
        SelectedItens = new List<ShopButtonController>();
        ChangeCost(0);
    }

    private void OnEnable()
    {
        ButtonBuy();
    }

    public void ButtonBuy()
    {
    }

    public void ButtonSell()
    {

    }

    public void ButtonInventory()
    {

    }

    public void ButtonConfirm()
    {

    }

    private void UpdateBoards()
    {
    }

    public void InitializeShopItens(GameObject prefab, List<Item> itens)
    {
        foreach (Item item in itens)
        {
            GameObject go = Instantiate(prefab);
            go.GetComponent<ShopButtonController>().SetItem(item, this);
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
        
    }

}
