using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    public static string playerName;

    public static bool male;
    public static bool female;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
