using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private float _rotationSpeed = 15f;
    // for mobile use very low rotation speed. 
    //private float _rotationSpeed = 270f; 
    private void Start()
    {
        //lock the cursor so it won't leave the game scene
        //Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameStarted)
            return;
        // For PC
        //if (Input.GetMouseButton(0))
        //{
        //    transform.Rotate(0f, -Input.GetAxisRaw("Mouse X") * _rotationSpeed * Time.deltaTime, 0f);
        //}

        //// For Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float deltaX = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0f, -deltaX * _rotationSpeed * Time.deltaTime, 0f);

        }
    }
}
