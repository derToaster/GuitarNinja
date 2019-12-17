using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private ObjectSpawner objectSpawner;
    // Start is called before the first frame update
    void Start()
    {       
    }

    private void OnTriggerEnter(Collider target) {        target.gameObject.SetActive(false);    }                              }
