using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AllPuzzlesResolve : MonoBehaviour
{
    public static int allPuzzlesResolved;
    public Transform platformBridge1;
    public Transform platformBridge2;
    public Transform platformBridge3;
    
    
    public GameObject winExitMenu;
    
    
    void Start()
    {
        allPuzzlesResolved = 0;
        

    }

    
    void Update()
    {
        if (allPuzzlesResolved == 3){
            //winExitMenu.SetActive(true);
            //Time.timeScale = 0f;
            BridgeMovement();
            
        }
        else
        {
            //winExitMenu.SetActive(false);
        }
        
    }

    public void countPuzzlesSolved()
    {
        allPuzzlesResolved++;
    }

    private void BridgeMovement()
    {
        var platform1V3 = platformBridge1.position; 
        Vector3 movement1 = new Vector3(platform1V3.x, platform1V3.y,
            platform1V3.z + 1.8f);
        Vector3.Lerp(platform1V3, movement1, 1f);
    }
}
