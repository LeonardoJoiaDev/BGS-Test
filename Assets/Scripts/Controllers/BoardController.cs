using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    [SerializeField, Tooltip("Insert Board Content")]
    Transform content;

    [SerializeField,Tooltip("Insert ShopController")]
    ShopController shopController;

    public void InitializeBoard(GameObject prefab, List<Item> itens)
    {
        foreach (Item item in itens)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(content, false);
            go.GetComponent<ShopButtonController>().SetItem(
                item,
                ShopButtonController.STATE.sell,
                this
                );
        }

            
    }

    public void AddItem(Transform transform)
    {
        transform.SetParent(content);
    }
    public void PutInCart(Transform button)
    {
        shopController.PutInCart(button);
    }
    public void RemoveFromCart(Transform button)
    {
        shopController.RemoveFromCart(button);
    }
}
