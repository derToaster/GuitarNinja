﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectQueue : MonoBehaviour
{
   
   

        poolDictionary = new Dictionary<string, List<GameObject>>();


        foreach (Pool pool in pools) {

            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < pool.size; i++) {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);
        }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {


        if (!poolDictionary.ContainsKey(tag)) {
        }
}