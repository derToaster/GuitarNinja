using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private ObjectSpawner objectSpawner;
    // Start is called before the first frame update
    void Start()
    {        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.EMPTY_PLATFORM) ||           target.CompareTag(Tags.NOTE_PLATFORM) ||           target.CompareTag(Tags.COL_PLAT_MID) ||           target.CompareTag(Tags.COL_PLAT_RIGHT) ||           target.CompareTag(Tags.COL_PLAT_LEFT)) {                       target.gameObject.SetActive(false);            objectSpawner.RecycleObjects();        }    }                              }
