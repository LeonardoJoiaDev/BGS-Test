using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonController : MonoBehaviour
{
    [SerializeField, Tooltip("insert text mesh pro object for show value")]
    TextMeshProUGUI valueText;

    [SerializeField, Tooltip("Insert child with Image component")]
    Image itemImage;

    Image selectionImage;
    ShopController shopController;

    public bool IsEquipped { get; private set; }
    public bool IsPurchased { get; private set; }
    public Item CurrentItem { get; private set; }
    public bool Selected { get; private set; }
    
    public void SetItem(Item item, ShopController shopController)
    {
        CurrentItem = item;
        valueText.text = item.value.ToString();
        this.shopController = shopController; 
        itemImage.sprite = item.sprite;

    }

    public void SetIsSelected(bool isSelected)
    {
        if (selectionImage == null)
            selectionImage = GetComponent<Image>();

        selectionImage.color = isSelected ? new Color(0.4f, 0.8f, 0.8f, 1) : Color.white;
        Selected = isSelected;
    }
    public void OnCLick()
    {
        if (Selected)
        {
            shopController.RemoveSelectedItem(this);
        }
        else
        {
            shopController.AddSelectedItem(this);
        }
        SetIsSelected(!Selected);
    }







}
