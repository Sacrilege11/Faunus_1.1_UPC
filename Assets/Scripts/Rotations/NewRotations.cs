using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRotations : MonoBehaviour
{
    private Quaternion _currentRotation;
    public float degrees;

    void Update()
    {
        _currentRotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.E))
        {
            var angle = transform.localEulerAngles.x;
            {
                
                transform.rotation = Quaternion.Euler(_currentRotation.x++, _currentRotation.y, _currentRotation.x);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < degrees; i++)
            {
                transform.rotation = Quaternion.Euler(_currentRotation.x--, _currentRotation.y, _currentRotation.x);
            }
            
        }
        
    }
}
