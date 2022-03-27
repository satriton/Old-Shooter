using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_StaticEnnemie : MonoBehaviour, IShootable
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DoAction()
    {
        // will do shoot action under certains contidions
    }

    public void GetShoot()
    {
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

        Destroy(this.gameObject);
    }

}
