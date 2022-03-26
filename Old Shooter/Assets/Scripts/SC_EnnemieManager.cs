using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnnemieManager : MonoBehaviour
{
    public GameObject prefabEnemie;

    public float gameTime;

    public float timeBetweenSpawn;


    void Start()
    {
        InvokeRepeating("SpawnEnnemie", 0, timeBetweenSpawn);
    }

    private void Update()
    {
        if(gameTime < 0)
        {
            CancelInvoke();
        }
        gameTime -= Time.deltaTime;
    }

    void SpawnEnnemie()
    {
        var x = Random.Range(-5f, 5f);
        var y = Random.Range(-5f, 5f);

        Instantiate(prefabEnemie, new Vector3(x, y, 0f), Quaternion.identity);
    }
}
