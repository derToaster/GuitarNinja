using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageCollection : MonoBehaviour
{    private platformManager _platformManager;        private void OnEnable() {        _platformManager = FindObjectOfType<platformManager>();                                     }    private void OnBecameInvisible() {        _platformManager.RecyclePlatform(this.gameObject);                                      }  }
