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

    public void SetItemOnBoard(Transform transform)
    {
        transform.SetParent(content,false);
    }

    void OrderBoard()
    {

    }
    
}
