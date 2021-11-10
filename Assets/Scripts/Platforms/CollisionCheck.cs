using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject puzzleManager;
    private PuzzleResolve _puzzleResolve;

    private void Start()
    {
        _puzzleResolve = puzzleManager.GetComponent<PuzzleResolve>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Resolve"))
        {
            Debug.Log("Colisioné con la resolución."); 
            Debug.Log("Avisé que colisione.");
            _puzzleResolve.SetResolution(true);
        }
    }
    
}
