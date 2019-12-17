using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectQueue : MonoBehaviour
{   
   
    #region /////////////////////PoolClass///////////////////////////    [System.Serializable]    public class Pool {        public string tag;        public GameObject prefab;        public int size;    }#endregion     public List<Pool> pools;    public static Dictionary<string, Queue<GameObject>> poolDictionary;    public List<string> tagList;    // Start is called before the first frame update    private void Awake() {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach (Pool pool in pools) {

            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);
        }        tagList = new List<string>(poolDictionary.Keys);    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {


        if (!poolDictionary.ContainsKey(tag)) {            Debug.LogWarning("Pool with tag " + tag + " does not exist");            return;
        }        GameObject objectToSpawn = poolDictionary[tag].Dequeue();        objectToSpawn.SetActive(true);        objectToSpawn.transform.position = position;        objectToSpawn.transform.rotation = rotation;        poolDictionary[tag].Enqueue(objectToSpawn);                
    }
}
