using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SC_StaticEnnemie : MonoBehaviour, IShootable
{
    public const int STATIC_ENNEMIE_POINTS = 100;
    private SC_Player scplayer;

    public void DoAction()
    {
        // will do shoot action under certains contidions
    }

    public void GetShoot(SC_Player scplayer)
    {
        this.scplayer = scplayer;
        
        Die();
    }

    public void OnSpawn()
    {
        // Trigger animation
    }

    public void Move(List<Vector2> listOfPointPath)
    {
        // Nothing because Static ennemie
    }

    private void Die()
    {
        var currentPosition = SpawnPositions.getSpawnPos(transform.position);
        currentPosition.isEmpty = true;

        scplayer.updateScore(STATIC_ENNEMIE_POINTS);

        Destroy(this.gameObject);
    }
}
