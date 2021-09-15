using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime = 1;
    private BoxCollider2D boxCollider2D;
    private TargetJoint2D targetJoint2D;

    // Start is called before the first frame update
    void Start()
    {
        targetJoint2D = GetComponent<TargetJoint2D>(); //Referenciar os componetes que vamos mexer
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) // Quando o "Player" tocar no objeto com esse script
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Caindo", fallingTime);// O invoke chama a função depois de um determinado periodo
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer == 10)
        {
            Destroy(gameObject);// O gameObject é o objeto que está usando o script
        }
    }

    void Caindo() //Crio um metodo para quando eu cair fazer uma/ou mais ações
    {
        targetJoint2D.enabled = false;
        boxCollider2D.isTrigger = true;

    }
}
