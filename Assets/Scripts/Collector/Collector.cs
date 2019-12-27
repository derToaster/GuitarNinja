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

    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.EMPTY_PLATFORM) ||           target.CompareTag(Tags.NOTE_PLATFORM) ||           target.CompareTag(Tags.COL_PLAT_MID) ||           target.CompareTag(Tags.COL_PLAT_RIGHT) ||           target.CompareTag(Tags.COL_PLAT_LEFT) ||           target.CompareTag(Tags.B_PLATFORM) ||           target.CompareTag(Tags.SHARP_PLATFORM) ||           target.CompareTag(Tags.PICK)) {            target.gameObject.SetActive(false);            objectSpawner.RecycleObjects();        } else if (target.CompareTag(Tags.NOTE)) {            target.gameObject.SetActive(false);        } else if (target.CompareTag(Tags.FLAT)) {            target.gameObject.GetComponent<Animator>().SetBool(Tags.ANIMATION_CONDITION_BOOL_FLAT_ROTATION, false);            target.gameObject.SetActive(false);        } else if (target.CompareTag(Tags.SHARP)) {            target.gameObject.GetComponent<Animator>().SetBool(Tags.ANIMATION_CONDITION_BOOL_SHARP_ROTATION, false);            target.gameObject.SetActive(false);        }    }                              }
