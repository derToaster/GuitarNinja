using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectQueue : MonoBehaviour
{   
   
    #region /////////////////////PoolClass///////////////////////////    [System.Serializable]    public class Pool {        public string tag;        public GameObject prefab;        public int size;    }#endregion     public List<Pool> pools;    public static Dictionary<string, List<GameObject>> poolDictionary;    [HideInInspector]    public List<string> tagList;    // Start is called before the first frame update    private void Awake() {

        poolDictionary = new Dictionary<string, List<GameObject>>();


        foreach (Pool pool in pools) {

            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < pool.size; i++) {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);
        }        tagList = new List<string>(poolDictionary.Keys);    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {


        if (!poolDictionary.ContainsKey(tag)) {            Debug.LogWarning("Pool with tag " + tag + " does not exist");            return null;
        }        for (int i = 0; i < poolDictionary[tag].Count; i++) {            if (!poolDictionary[tag][i].activeInHierarchy) {                GameObject objectToSpawn = poolDictionary[tag][i];                //Reactivate Collectables after Collection by the Player                 for (int j = 0; j < objectToSpawn.transform.childCount; j++) {                    if (!objectToSpawn.transform.GetChild(j).gameObject.activeInHierarchy) {                        objectToSpawn.transform.GetChild(j).gameObject.SetActive(true);                    }                }                ///////////////////////////////////////////////////////////////////////////                                objectToSpawn.SetActive(true);                objectToSpawn.transform.position = position;                objectToSpawn.transform.rotation = rotation;                poolDictionary[tag].Add(objectToSpawn);                return objectToSpawn;            }        }        Debug.LogWarning("Insufficient Pool");        return null;    }
}
