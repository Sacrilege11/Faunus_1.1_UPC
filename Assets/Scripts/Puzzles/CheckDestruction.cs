using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestruction : MonoBehaviour
{
    public void DestroyWall()
    {
        Destroy(gameObject);
    } 
}
