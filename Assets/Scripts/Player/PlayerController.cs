using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LayerMask whatIsGround;

    [SerializeField] float xMoveSpeed, feetCheckRadius, jumpForce, jumpTime;
    [SerializeField] Transform feetPosition;

    [SerializeField] bool isFacingRight, isGrounded, isJumping;

    float jumpTimeCounter;
    Rigidbody2D rb2d;
    Animator anim;
    PlayerSoundEffects soundEffects;

    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        soundEffects = GetComponent<PlayerSoundEffects>();
        anim = GetComponent<Animator>();
        isFacingRight = true;
    }

    // Esto ocurre al menos 60 vece por segun, sí o sí
    void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, feetCheckRadius, whatIsGround);

        if (isGrounded && rb2d.velocity.y < 0.01) {
            isJumping = false;

        }

        float moveX = Input.GetAxisRaw("Horizontal"); 

        rb2d.velocity = new Vector2(moveX * xMoveSpeed, rb2d.velocity.y);

        anim.SetBool("Idle", (moveX == 0) && isGrounded);
        anim.SetBool("Running", (moveX != 0) && isGrounded);
        anim.SetBool("Jumping", !isGrounded);

        // Ya sea que el player está viendo a la derecha, y el usuario aprieta a la izquierda, O
        // el player está viendo a la izquiera, y el usuario aprieta a la derecha => flip()
        //    true        true     true   true    !false     true      true
        if ((isFacingRight && (moveX < 0)) || (!isFacingRight && (moveX > 0))) {
            flip();
        }
    }

    // Update is called once per frame, o sea, debe esperar a que se calcule un frame visual
    void Update () {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb2d.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            isJumping = true;
            soundEffects.jumpSound();
        }
        if (Input.GetButton("Jump") && isJumping) {
            if (jumpTimeCounter > 0) {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }
    }

    void flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPosition.position, feetCheckRadius);
    }

}



/*
 Operadores Lógicos:
    AND: es el Y lógico, quiere decir que dos condiciones deben cumplirse para que el operador
        devuelva verdadero. Ejemplo: Si haces la tarea y limpias tu cuarto, vamos al McDonals; entonces
        si una de las dos condiciones no se cumple, no vas a McDonals.
        En programación se tienen dos operadores AND, el de bits (&), y el de booleans (&&).
    OR:  es el O lógico, quiere decir que con que se cumpla una de las dos condiciones, el operador
        devuelve verdadero. Ejemplo: Si lavas el baño o lavas los trastes, puedes jugar al Fornai; entonces
        basta con que hagas una de las dos labores, para que te dejen jugar.
        En programación se tiene dos operadores, el de bits (|), y el de booleans (||)
    NOT: es la negación, y da lo opuesto al valor inicial.
        En programación se usa así !true => false, !false => true
 
 Operadores de Comparación:
    a > b : Mayor qué, si a > b => true, de lo contrario => false; (5 > 2) => true, (2 > 4) => false
    a < b : Menor qué, si a < b => true, de lo contrario => false; (3 < 9) => true, (4 < 1) => false
    a >= b : Mayor o igual qué, si a >= b => true, de lo contrario => false; (3 >= 0) => true, (3 >= 3) => true
    a <= b : Menor o igual qué, si a <= b => true, de lo contrario => false; (-9 <= 0) => true, (-9 >= -9) => true
    a == b : Igual qué, si a es igual b => true, de lo contrario => false; (-9 == 0) => false, (-9 == -9) => true
 
 */