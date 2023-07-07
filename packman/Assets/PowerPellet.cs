using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    protected override void Eat()
    {
        base.Eat();
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Ghost>().Frighten();
        }
    }
}
