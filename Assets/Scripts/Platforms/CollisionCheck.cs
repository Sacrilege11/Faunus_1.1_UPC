using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject pieceManager;
    private PuzzleResolve _puzzleResolve;

    private void Start()
    {
        _puzzleResolve = pieceManager.GetComponent<PuzzleResolve>();
        
    }


    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Resolve"))
        {
            Debug.Log("Colisioné con la resolución."); 
            
            _puzzleResolve.SetResolution(true);
        }
    }
    
}
