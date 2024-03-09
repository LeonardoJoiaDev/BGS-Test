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

    public PlayerVisualController VisualController { get => visualController; }
    public PlayerInventory InventoryController { get => inventoryController; }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
