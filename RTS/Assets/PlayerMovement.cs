using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float forwardSpeed = 5f;
    public float rotationSpeed = 75f;
    public float rotationResetSpeed = 75f;
    public Rigidbody rb;

    float zRotation = 0f;
    float yRotation = 0f;

    void Update()
    {

        float x = Input.GetAxis("Horizontal") * Time.deltaTime;

        Vector3 Move = (Vector3.right * (-zRotation/30 * 100) * Time.deltaTime) + Vector3.forward * forwardSpeed * Time.deltaTime;
        //Vector3 Move = (Vector3.right * x * speed) + Vector3.forward * forwardSpeed * Time.deltaTime;


        zRotation -= x * rotationSpeed;

        //yRotation += x * rotationSpeed;

        zRotation = Mathf.Clamp ( zRotation , -30 , 30 );
        //yRotation = Mathf.Clamp ( yRotation , -6 , 6 );

        if (x == 0f ) {

            //zRotation -= zRotation > 0 ? rotationSpeed * Time.deltaTime : 0;
            zRotation += zRotation < -1 ? rotationResetSpeed * Time.deltaTime : zRotation > 1 ? -rotationResetSpeed * Time.deltaTime: 0;
            zRotation = zRotation >= -1 && zRotation <= 1 ? 0 : zRotation;

            //yRotation += yRotation < -0.5 ? rotationResetSpeed * Time.deltaTime : yRotation > 0.5 ? -rotationResetSpeed * Time.deltaTime : 0;
            //yRotation = yRotation >= -0.5 && yRotation <= 0.5 ? 0 : yRotation;

        }

        transform.localRotation = Quaternion.Euler ( 0 , yRotation , zRotation );

        transform.Translate(Move, Space.World);

        if ( Input.GetKey ( KeyCode.Space ) ) {
            //rb.drag = 100;
            //Debug.Log ( "space" );
            //rb.AddForce ( Vector3.up * 5000f );
            //rb.drag = 5000;
        }
        

    }

    private void OnCollisionEnter ( Collision collision ) {
        if ( collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle") ) {
            SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex );
        }
    }
}
