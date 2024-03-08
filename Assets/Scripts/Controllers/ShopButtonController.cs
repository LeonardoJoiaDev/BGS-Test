using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonController : MonoBehaviour
{
    Item item;

    [SerializeField, Tooltip("insert text mesh pro object for show value")]
    TextMeshProUGUI valueText;

    [SerializeField, Tooltip("Insert child with Image component")]
    Image image;

    BoardController boardController;

    STATE state;

    public Item Item { get => item; }

    public void SetItem(Item item, STATE state, BoardController boardController)
    {
        this.item = item;
        valueText.text = item.value.ToString();
        image.sprite = item.sprite;

        this.state = state;
        this.boardController = boardController;
    }

    public void OnClick()
    {
        switch (state)
        {
            case STATE.sell:
                boardController.PutInCart(transform);
                state = STATE.cart;
                break;
            case STATE.cart:
                boardController.RemoveFromCart(transform); 
                state = STATE.sell;
                break;
            case STATE.inventory:
                break;

        }
        
    }

    public enum STATE
    {
        sell,
        cart,
        inventory
    }

}
