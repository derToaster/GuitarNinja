using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
    [SerializeField]
    private int amountOfPlatforms = 0;
    [SerializeField]
    private float platformLength = 0f;
    public float zOffset;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platformPrefabs.Length; i++) {

            Instantiate(platformPrefabs[i], new Vector3(0, 0, i * platformLength), Quaternion.identity);
            zOffset += platformLength;

        }
       
    }

    // Update is called once per frame

    public void RecyclePlatform(GameObject platform) {

        platform.transform.position = new Vector3(0, 0, zOffset);        zOffset += platformLength;

    }}
