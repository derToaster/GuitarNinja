using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
    [SerializeField]
    private int amountOfPlatforms;
    [SerializeField]
    private float platformLength;
    public float zOffset;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfPlatforms; i++) {

            Instantiate(platformPrefabs[0], new Vector3(0, 0, i * platformLength), Quaternion.identity);
            zOffset += platformLength;
        }
       
    }

    // Update is called once per frame

    public void RecyclePlatform(GameObject platform) {

        platform.transform.position = new Vector3(0, 0, zOffset);        zOffset += platformLength;

    }}
