using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour {
    
    public Notificador notificador;
    
    // Start is called before the first frame update
    void Start() {
        notificador.OnMyEvent += response;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Update is called once per frame
    void Update() {
    }


    void response() {

        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Random.ColorHSV();

        // assign the material to the renderer
        GetComponent<Renderer>().material = material;
    }
}
