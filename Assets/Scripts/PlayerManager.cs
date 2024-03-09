using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField]
    PlayerVisualController visualController;

    [SerializeField]
    PlayerInventory inventoryController;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    ShopController shopController;

    float playerBalance = 200;


    public PlayerVisualController VisualController { get => visualController; }
    public PlayerInventory InventoryController { get => inventoryController; }
    public ShopController ShopController { get => shopController;  }
    public float PlayerBalance { get => playerBalance; }
    public PlayerController PlayerController { get => playerController; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(visualController == null)
            visualController = gameObject.GetComponent<PlayerVisualController>();
        if (inventoryController == null)
            inventoryController = gameObject.GetComponent<PlayerInventory>();

    }

    public void ChangeBalance(float value)
    {
        playerBalance += value;
    }

}
