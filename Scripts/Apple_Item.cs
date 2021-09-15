using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Item : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;

    public int pontuacao = 10;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player") //Verefica se o colisor da maça vai se chocar com o do player
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            GameContoller.instance.pontuacaoTotal += pontuacao;
            GameContoller.instance.updateScoreText();

            Destroy(gameObject, 1f); // Se ele se chocar vai ser destruido
        }
    }

}
