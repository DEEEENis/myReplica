using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GAME Game;
    public ParticleSystem Fire;

    private void OnCollisionEnter(Collision collision)
    {
        Game.Win();
        Fire.Play();
    }

}