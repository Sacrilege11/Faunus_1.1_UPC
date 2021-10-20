using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectRotation : MonoBehaviour
{
    private Quaternion _currentRotation;
    public int counterTab;
    private bool _isSelected = false; 
    [SerializeField] private bool _axisSelector = true;
    [SerializeField] private bool _axisX = true;
    [SerializeField] private bool _axisY = true;
    [SerializeField] private bool _axisZ = true;
    public static bool somePlatformIsSelected;  
    
    
    
    
    
    

    private void Start()
    {
        somePlatformIsSelected = false;
        _currentRotation = transform.rotation;
        
        counterTab = 0;
        Selectors();
    }

    void Update()
    {
        if (_isSelected)
        {
            CounterReset();
            InputRotationManager();
            RotationX();
            RotationX2();
            RotationY();
            RotationZ();
  
        }
        
        //transform.LookAt(transform.position + _currentRotation.eulerAngles);

        
    }

    void CounterReset()
    {
        if (counterTab == 3)
        {
            counterTab = 0;
        }
    }

    void InputRotationManager()
    {
        if (_axisSelector && Input.GetKeyDown(KeyCode.R))
        {
            counterTab++;
        }
        
    }
    
    


    private void RotationX()
    {
        if (counterTab == 0 && _axisX)
        {
            if ( Input.GetKey(KeyCode.E))
            {
                //transform.Rotate( _currentRotation.x + Time.deltaTime * velocity, _currentRotation.y, _currentRotation.z);
                transform.rotation = Quaternion.Euler(_currentRotation.x++, _currentRotation.y, _currentRotation.z);
                
                
            } 
            else if (Input.GetKey(KeyCode.Q))
            {
                //transform.Rotate(_currentRotation.x - Time.deltaTime * velocity, _currentRotation.y, _currentRotation.z);
                transform.rotation = Quaternion.Euler(_currentRotation.x--, _currentRotation.y, _currentRotation.z);
            }
        }
        
    }


    private void RotationX2()
    {
        if (gameObject.CompareTag("PlatformRotate2") && counterTab == 0 && _axisX)
        {
            if (Input.GetKey(KeyCode.T))
            {

                transform.rotation = Quaternion.Euler(_currentRotation.x++, _currentRotation.y, _currentRotation.z);


            }
            else if (Input.GetKey(KeyCode.Y))
            {

                transform.rotation = Quaternion.Euler(_currentRotation.x--, _currentRotation.y, _currentRotation.z);
            }
        }

    }

    private void RotationY()
    {
        if (counterTab == 1 && _axisY)
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y++, _currentRotation.z);
                
                
            } 
            else if (Input.GetKey(KeyCode.Q)) 
            {
                
                transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y--, _currentRotation.z);
            }
        }
        
    }

        private void RotationZ()
    {
        if (counterTab == 2 && _axisZ)
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, _currentRotation.z++);
                

            } 
            else if (Input.GetKey(KeyCode.Q))
            {
                
                transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, _currentRotation.z--);
            }
        }
    }

        private void Selectors()
        {
            if (!_axisSelector && !_axisX && !_axisZ)
            {
                counterTab = 1;
            }
            else if(!_axisSelector && !_axisX && !_axisY)
            {
                counterTab = 2;
            }
        }
        
        public void MouseSelected (bool isSelected)
        {
            if(isSelected)
            {
                _isSelected = true;
            }
            else
            {
                _isSelected = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            _isSelected = false;
        }
}
