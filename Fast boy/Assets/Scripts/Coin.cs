using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnDestroy()
    {
        Destroy(this.gameObject);   
    }
}
