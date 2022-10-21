using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void Mensaje();
    public event Mensaje OnCollisionA;
    public event Mensaje OnCollisionB;

    public event Mensaje changeColorAndJumpA;
    public event Mensaje orientToSomeone;

    public tipoC objectC;
    public float originalDistanceToC;
    // public event Mensaje OnCollisionC;

    // Start is called before the first frame update
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = true;

        originalDistanceToC = Vector3.Distance(transform.position, objectC.transform.position);
    }

    // Update is called once per frame
    void Update() {
        Vector3 movementInput = Vector3.zero;
        if (Input.GetKey("w")) {
            movementInput.z = 1;
        }
        if (Input.GetKey("s")) {
            movementInput.z = -1;
        }
        if (Input.GetKey("d")) {
            movementInput.x = 1;
        }
        if (Input.GetKey("a")) {
            movementInput.x = -1;
        }
        gameObject.transform.position += movementInput.normalized * 4 * Time.deltaTime;

        float newDistanceToC = Vector3.Distance(transform.position, objectC.transform.position);
        if (newDistanceToC < originalDistanceToC) {
            changeColorAndJumpA();
            orientToSomeone();
        }
        originalDistanceToC = newDistanceToC;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "tipoA") {
            Debug.Log("Colisión con tipo A");
            OnCollisionA();
        }

        if (other.gameObject.tag == "tipoB") {
            Debug.Log("Colisión con tipo B");
            OnCollisionB();
        }

    }
}
