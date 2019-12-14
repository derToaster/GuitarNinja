using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
    private List<GameObject> platformList = new List<GameObject>();
    [SerializeField]
    private int amountOfStartPlatforms;
    [SerializeField]
    private float platformLength;
    public float zOffset;
    [SerializeField]
    int maxListSize;
        int randomPoolIndex;    // Start is called before the first frame update    void Start() {        for (int i = 0; i < platformList.Count; i++) {            platformList.Add(platformPrefabs[i]);        }        for (int i = 0; i < platformPrefabs.Length; i++) {

            Instantiate(platformPrefabs[i], new Vector3(0, 0, i * platformLength), Quaternion.identity);
            zOffset += platformLength;

        }
        //Filling the PlatformPool    }

    // Update is called once per frame

    public void RecyclePlatform(GameObject platform) {        if (platformList.Count < maxListSize) {            platformList.Add(platform);            randomPoolIndex = Random.Range(0, platformList.Count - 1);            Instantiate(platformList[randomPoolIndex], new Vector3(0, 0, zOffset), Quaternion.identity);            zOffset += platformLength;        } else {            platformList.Add(platform);            platformList[randomPoolIndex].transform.position = new Vector3(0, 0, zOffset);            zOffset += platformLength;            platformList.RemoveAt(randomPoolIndex);        }    }}
