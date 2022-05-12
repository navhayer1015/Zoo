using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanningMovement : MonoBehaviour
{
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(
                transform.position.x + Input.GetAxis("Mouse Y") * Time.deltaTime * speed, 
                transform.position.y, 
                transform.position.z + Input.GetAxis("Mouse X") * Time.deltaTime * speed);
        }
    }
}
