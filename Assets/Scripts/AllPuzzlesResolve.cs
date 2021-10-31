using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPuzzlesResolve : MonoBehaviour
{
    public static int allPuzzlesResolved;
    
    public GameObject winExitMenu;
    
    
    void Start()
    {
        allPuzzlesResolved = 0;
        

    }

    
    void Update()
    {
        if (allPuzzlesResolved == 3){
            winExitMenu.SetActive(true);
            Time.timeScale = 0f;
            //allPuzzlesResolved = 0;
        }
        else
        {
            winExitMenu.SetActive(false);
        }
        
    }

    public void countPuzzlesSolved()
    {
        allPuzzlesResolved++;
    }
}
