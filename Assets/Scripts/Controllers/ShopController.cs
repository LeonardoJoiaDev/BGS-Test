using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert Board Controller 1")]
    BoardController boardController1;

    [SerializeField, Tooltip("Insert Board Controller 2")]
    BoardController boardController2;

    [SerializeField, Tooltip("Insert prefab Shop Button")]
    GameObject shopButton;

    [SerializeField,Tooltip("Insert itens Library")]
    ShopItensLibrary shopItensLibrary;


    private void OnEnable()
    {
        ButtonBuy();
    }

    public void ButtonBuy()
    {
        UpdateBoards();
    }

    public void ButtonSell()
    {

    }

    public void ButtonInventory()
    {

    }

    private void UpdateBoards()
    {
        boardController1.InitializeBoard(shopButton, shopItensLibrary.headItens);
    }

    public void PutInCart(Transform button)
    {
        boardController2.AddItem(button);
    }
    public void RemoveFromCart(Transform button) 
    {
        boardController1.AddItem(button);
    }


}
