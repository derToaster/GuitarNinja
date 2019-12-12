using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recycleScript : MonoBehaviour
{

    private platformManager _platformManager;

    private void OnEnable() {        _platformManager = FindObjectOfType<platformManager>();                              }


    private void OnBecameInvisible() {        //Recycling        _platformManager.RecyclePlatform(this.gameObject);                              }
}
