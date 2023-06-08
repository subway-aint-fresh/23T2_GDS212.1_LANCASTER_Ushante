using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipOn : MonoBehaviour
{
    //UI tool tip
    public GameObject toolTip;
    
    public void OnTriggerEnter(Collider other)
    {
        toolTip.SetActive(true);
    }
}
