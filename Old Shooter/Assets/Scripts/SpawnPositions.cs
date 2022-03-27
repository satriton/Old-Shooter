using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SpawnPositions
{
    private static List<SpawnPosition> spawnPosList;

    public SpawnPositions()
    {
        spawnPosList = new List<SpawnPosition> {
            new SpawnPosition(new Vector3(-9f,-3.5f,1f)),       // Caisse gauche: droite
            new SpawnPosition(new Vector3(-10f,-2.7f,1f)),      // Caisse gauche: dessus
            new SpawnPosition(new Vector3(-4f,-3.9f,-5f)),      // Carosse: droite
            new SpawnPosition(new Vector3(-8f,-3.8f,-5f)),      // Carosse: gauche
            new SpawnPosition(new Vector3(-6.3f,-2f,-5f)),      // Carosse: dessus
            new SpawnPosition(new Vector3(-7.8f,-4.5f,-15f)),   // Double Caisse gauche: top droite
            new SpawnPosition(new Vector3(-9.3f,-4.3f,-15f)),   // Double Caisse gauche: top gauche
            new SpawnPosition(new Vector3(0.5f,-4.9f,-15f)),    // Double Caisse milieu: top droite
            new SpawnPosition(new Vector3(-1f,-4.9f,-15f)),     // Double Caisse milieu: top gauche
            new SpawnPosition(new Vector3(6.3f,-4f,-15f)),      // Caisse droite
            new SpawnPosition(new Vector3(2.4f,-4.65f,-15f)),   // Squelette
            new SpawnPosition(new Vector3(-30f,0f,-15f))        // Truc random
        };
    }

    public void addPos(SpawnPosition spawnPos)
    {
        spawnPosList.Add(spawnPos);
    }

    public static List<SpawnPosition> getSpawnPosList()
    {
        return spawnPosList;
    }

    public static List<SpawnPosition> getEmptyList()
    {
        var spawnEmptyList = new List<SpawnPosition>();
        
        for(int i = 0; i < spawnPosList.Count; i++)
        {
            if (spawnPosList[i].isEmpty)
            {
                spawnEmptyList.Add(spawnPosList[i]);
            }
        }

        return spawnEmptyList;
    }

    public static SpawnPosition getSpawnPos(Vector3 position)
    {
        for (int i = 0; i < spawnPosList.Count; i++)
        {
            if (spawnPosList[i].position == position)
            {
                return spawnPosList[i];
            }
        }

        return null;
    }

    public class SpawnPosition
    {
        public Vector3 position { get; set; }
        public bool isEmpty { get; set; }

        public Quaternion angleSpawn;

        public SpawnPosition(Vector3 pos)
        {
            position = pos;
            isEmpty = true;
            angleSpawn = Quaternion.identity;
        }

        public SpawnPosition(Vector3 pos, Quaternion quat)
        {
            position = pos;
            isEmpty = true;
            angleSpawn = quat;
        }
    }
}
