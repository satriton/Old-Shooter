using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_EnnemieManager : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabsEnemies;

    public static float gameTime;

    public float timeBetweenSpawn;

    private SpawnPositions spawnPositions;


    void Awake()
    {
        SC_Player.isGame = true;
        spawnPositions = new SpawnPositions();
        gameTime = 120;
        SC_ScoreUI.scoreP1 = 0;
        SC_ScoreUI.scoreP2 = 0;


        InvokeRepeating("SpawnEnnemie", 0, timeBetweenSpawn);

    }

    private void Update()
    {
        if(gameTime < 0)
        {
            CancelInvoke();
            SC_Player.isGame = false;
            SceneManager.LoadScene("MenuFin");
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

            int indicePrefab = (int) Random.Range(0f, prefabsEnemies.Length);

            Instantiate(prefabsEnemies[indicePrefab], spawnPos.position, spawnPos.angleSpawn);
        }
    }
}
