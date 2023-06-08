using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOff : MonoBehaviour
{
    public GameObject toolTip;
    private void OnTriggerEnter(Collider other)
    {
        toolTip.SetActive(false);
    }
}
