using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject columnPrefab;

    public float spawnYMin;
    public float spawnYMax;

    public float spawnX;

    public int numberColumn = 4;
    public float timeDelay = 1f;

    float delay;

    List<GameObject> poolList = new List<GameObject>();

    void Start()
    {
        float randomY = Random.Range(spawnYMin, spawnYMax);
        GameObject newColumn = Instantiate(columnPrefab, new Vector2(spawnX, randomY), Quaternion.identity);
        poolList.Add(newColumn);
    }

    void Update()
    {
        if (GameController.instance.gameover) return;

        delay += Time.deltaTime;

        if(delay >= timeDelay)
        {
            delay = 0;

            GameObject newColumn = GetColumn();

            if (newColumn == null)
            {
                float randomY = Random.Range(spawnYMin, spawnYMax);
                newColumn = Instantiate(columnPrefab, new Vector2(spawnX, randomY), Quaternion.identity);
                poolList.Add(newColumn);
            }
            else
            {
                float randomY = Random.Range(spawnYMin, spawnYMax);
                newColumn.transform.position = new Vector2(spawnX, randomY);
                newColumn.SetActive(true);
            }
        }
    }

    GameObject GetColumn()
    {
        foreach (GameObject pool in poolList)
        {
            if(!pool.activeInHierarchy)
            {
                return pool;
            }
        }

        return null;
    }
}
