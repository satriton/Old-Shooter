using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnnemieManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabsEnemies;

    public float gameTime;

    public float timeBetweenSpawn;

    private SpawnPositions spawnPositions;


    void Start()
    {
        spawnPositions = new SpawnPositions();
        
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
        List<SpawnPositions.SpawnPosition> emptySpawn = SpawnPositions.getEmptyList();

        if (emptySpawn != null && emptySpawn.Count > 0)
        {
            int indicePos = (int) Random.Range(0f,emptySpawn.Count);

            SpawnPositions.SpawnPosition spawnPos = emptySpawn[indicePos];
            spawnPos.isEmpty = false;

            int indicePrefab = (int)Random.Range(0f, prefabsEnemies.Length);

            Instantiate(prefabsEnemies[indicePrefab], spawnPos.position, spawnPos.angleSpawn);
        }
    }
}
