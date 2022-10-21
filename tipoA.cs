using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipoA : MonoBehaviour {

    public Player player;
    public tipoB tipoB;

    public tipoC objectC;
    
    public delegate void Mensaje();
    public event Mensaje OnMakeBiggerB;

    // Start is called before the first frame update
    void Start() {
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Color.red;
        GetComponent<Renderer>().material = material;

        player.OnCollisionA += response;
        player.changeColorAndJumpA += changeColorAndJump;
        tipoB.MoveAtoC += moveToC;
    }

    // Update is called once per frame
    void Update() {
    }

    void response() {
        OnMakeBiggerB();
    }

    void moveToC() {
        Transform transformOfC = objectC.GetComponent<Transform>();
        transform.LookAt(transformOfC, Vector3.left);
        transform.position += transform.forward * 0.5f;
    }

    void changeColorAndJump() {
        // Change color
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Random.ColorHSV();
        GetComponent<Renderer>().material = material;

        // Jump
        Vector3 jump = new Vector3(0, 0.1f, 0);
        transform.position = transform.position + jump;
    }
}
