using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    private GameObjectQueue objectQueue;
    public int amountOfStartingPlatforms;
    public float platformLength;
    private float zOffset;


    private int randomIndex;


    void Start() {
        objectQueue = FindObjectOfType<GameObjectQueue>();

        for (int i = 0; i < amountOfStartingPlatforms; i++) {// a defined amount of platforms will be instatiated at the beginning 
            objectQueue.SpawnFromPool(objectQueue.tagList[0], new Vector3(0, 0, i * platformLength),
                Quaternion.identity);
            zOffset += platformLength;
        }
    }


    public void RecycleObjects() {    // a random prefab will be drawn from the objectQueue and transferred at the given position
        randomIndex = Random.Range(0, objectQueue.tagList.Count);

        objectQueue.SpawnFromPool(objectQueue.tagList[randomIndex], new Vector3(0, 0, zOffset), Quaternion.identity);
        zOffset += platformLength;
    }
}