using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipoC : MonoBehaviour {
    public Player notificadorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Color.blue;
        GetComponent<Renderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
