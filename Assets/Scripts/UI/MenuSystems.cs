using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystems : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode inventorykey;

    private GameObject getInventory;
    private int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        getInventory = GameObject.FindGameObjectWithTag("Inventory");
        getInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(inventorykey) && check == 0)
        {
            check++;
            getInventory.SetActive(true);
        } else if(Input.GetKeyUp(inventorykey) && check == 1)
        {
            check = 0;
            getInventory.SetActive(false);
        }
    }
}
