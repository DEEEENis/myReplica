using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GAME Game;
    private void OnCollisionEnter(Collision collision)
    {
        Game.Win();
    }

}