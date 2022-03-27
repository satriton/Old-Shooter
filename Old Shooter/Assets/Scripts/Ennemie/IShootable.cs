using System;
using System.Collections.Generic;
using UnityEngine;

interface IShootable
{
    public void OnSpawn();
    public void GetShoot(SC_Player scplayer);
    public void DoAction();
    public void Move(List<Vector2> listOfPointPath);
}
