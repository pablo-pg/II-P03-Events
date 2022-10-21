using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipoB : MonoBehaviour {

    public Player player;
    public tipoA tipoA;

    public delegate void Mensaje();
    public event Mensaje MoveAtoC;

    // Start is called before the first frame update
    void Start() {
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Color.green;
        GetComponent<Renderer>().material = material;

        player.OnCollisionB += response;
        player.orientToSomeone += orient;
        tipoA.OnMakeBiggerB += makeBigger;
    }

    // Update is called once per frame
    void Update() {
    }

    void response() {
        MoveAtoC();
    }

    void makeBigger() {
        Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        gameObject.transform.localScale += scaleChange;
    }

    void orient() {
        Transform transformOfA = tipoA.GetComponent<Transform>();
        transform.LookAt(transformOfA, Vector3.left);
    }
}
