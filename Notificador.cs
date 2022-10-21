using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificador : MonoBehaviour {
    
    public delegate void Mensaje();
    public event Mensaje OnMyEvent;
    public int counter; 

    // Start is called before the first frame update
    void Start() {
        counter = 0;

        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Color.red;
        GetComponent<Renderer>().material = material;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Update is called once per frame
    void Update() {
        counter = counter + 1;
        if (counter % 1000 == 0) {
            OnMyEvent();
        }
    }
}
