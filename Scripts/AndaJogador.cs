using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaJogador : MonoBehaviour
{

    [Header("Configurações de Pulo")]
        public float Speed = 5;
        public float JumpForce = 10;
        private Rigidbody2D rig;

        public bool isJumping;
        public bool doubleJump;
        private Animator animacao;

    [Header("Camera")]
    public Transform cameraTarget;
    [Range(0.0f, 5.0f)]
    public float cameraTargetOffsetX = 2.0f;
    [Range(0.5f, 50.0f)]
    public float cameraTargetFlipSpeed = 2.0f;
    [Range(0.0f, 5.0f)]
    public float characterSpeedInfluence = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Cria a instancia para movimentar apenas o eixo x, esse 0f é para nao mover essas partes
        transform.position += Move * Time.fixedDeltaTime * Speed; //Isso é padrão de movimentação
        
        if (Input.GetAxis("Horizontal") > 0f)
        {
            animacao.SetBool("walk", true); // Essa variavel pega o walk e coloca true lá na unity.
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // Essa função vira 180 graus o personagem
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            
            animacao.SetBool("walk", true); // Essa variavel pega o walk e coloca true lá na unity.
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            animacao.SetBool("walk", false); // Essa variavel pega o walk e coloca true lá na unity.
        }



    }
    //Esse Jump comentado faz o personagem pular apenas uma vez
    //void Jump() //Uma das formas de fazer pulo é essa
    //{                                      //isJumping == false;
    //    if (Input.GetButtonDown("Jump") && !isJumping) //Se eu apertar space
    //    {
    //        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    //    }

    //}

    //Dessa segunda forma o personagem pula duas vezes...
    void Jump()
    {
        if (Input.GetButtonDown("Jump")) // Se apertar espaço
        {
            if (!isJumping) // Ele vai pular
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);// Fazer o movimento de pulo
                doubleJump = true; //Double jump habilitado
                animacao.SetBool("jump", true); //Roda a animação de pulo
                
            }else //se ele estiver no ar ele vai poder fazer essa parte depois
            {
                if (doubleJump == true) // Com o double Jump habilitado eu posso dar o segundo uplo
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);// Codigo do pulo
                    doubleJump = false; //Nega a possibilidade de mais um pulo
                    animacao.SetBool("doubleJump", true); //Roda a animação do double jump
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // Esse 8 é o layer que lá na unity é o ground/ terreno 
        {
            isJumping = false;
            animacao.SetBool("jump", false); // parando animação do jump
            animacao.SetBool("doubleJump", false); //Parando animação do double jump
        }

        if (collision.gameObject.tag == "Spike") // Esse 8 é o layer que lá na unity é o ground/ terreno 
        {
            GameContoller.instance.ShowGameOver();
            Destroy(gameObject);
            Debug.Log("Tocou o espinho");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true; //Está pulando
        }
    }
}
