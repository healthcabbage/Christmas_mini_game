using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;

    void Awake()
    {
        for (int i = 0; i<Mobs.Length; i++)
        {
            for (int a = 0; a < objCnt; a++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }

    private void Start()
    {
        StartCoroutine(CreateMob());
    }

    IEnumerator CreateMob()
    {
        while(true)
        {
            MobPool[Random.Range(0, MobPool.Count)].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
