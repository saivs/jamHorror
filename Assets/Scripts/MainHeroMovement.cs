using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroMovement : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody _rb;

    public GameObject cam;

    private float mouseX, mouseY, mouseSens = 200f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cam = transform.Find("Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputP();
        GetInputC();
    }

    private void GetInputP(){
        if(Input.GetAxis("Horizontal") != 0)
            if(Input.GetAxis("Horizontal") > 0)
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            if(Input.GetAxis("Horizontal") < 0)
                transform.localPosition -= transform.forward * speed * Time.deltaTime;

        if(Input.GetAxis("Vertical") != 0)
            if(Input.GetAxis("Vertical") > 0)
                transform.localPosition -= transform.right * speed * Time.deltaTime;
            if(Input.GetAxis("Vertical") < 0)
                transform.localPosition += transform.right * speed * Time.deltaTime;
    }

    private void GetInputC(){
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        transform.Rotate(mouseX * new Vector3(0,1,0));
        cam.transform.Rotate(-mouseY * new Vector3(1,0,0));

    }

    void FixedUpdate() {

        // Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed;
        // mov = Vector3.ClampMagnitude(mov,speed);

        // if (mov != Vector3.zero){
        //     _rb.MovePosition(transform.position = mov * Time.deltaTime);
        //     //_rb.MovePosition(q.eulerAngels.LookRotation(mov));
        // }

        // float moveHorizontal = Input.GetAxis("Horizontal");

        // float moveVertical = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // _rb.AddForce(movement * Speed);
    }
}
