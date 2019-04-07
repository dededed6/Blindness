using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 ScreenCenter;
    public static GameObject player;
    public float speed = 2f;
    public float sen = 3f;
    public Camera cam;
    void Start()
    {
        cam = Camera.allCameras[0];
        ScreenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
        player =  this.gameObject;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("a");
            GameObject objectHit = hit.collider.gameObject;
            //if(objectHit.tag == "Player")
            //{
                Destroy(objectHit);
            //}
        }
        
        Move();
    }
    void Move()
    {
        this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime);
        float rotX = Input.GetAxis("Mouse Y") * sen;
        float rotY = Input.GetAxis("Mouse X") * sen;

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
    }
}
