using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NewRotations : MonoBehaviour
{
    public Transform starPosition;
    public Transform endPosition;
    private Quaternion _currentRotation;
    public float degrees;
    public float lerpSlider = 1f;
    public float distanceToSleerp;

    void Update()
    {
       BridgeMovement();
        _currentRotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.E))
        {
            BridgeMovement();
            // var angle = transform.localEulerAngles.x;
            // {
            //     
            //     transform.rotation = Quaternion.Euler(_currentRotation.x++, _currentRotation.y, _currentRotation.x);
            // }
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < degrees; i++)
            {
                transform.rotation = Quaternion.Euler(_currentRotation.x--, _currentRotation.y, _currentRotation.x);
            }
            
        }
        
    }
    private void BridgeMovement()
    {
        
        Vector3 movement1 = new Vector3(transform.position.x, transform.position.y,
            transform.position.z + distanceToSleerp);
        transform.position = Vector3.Lerp(starPosition.position, endPosition.position,  lerpSlider * Time.deltaTime * 0.01f);
    }
}
