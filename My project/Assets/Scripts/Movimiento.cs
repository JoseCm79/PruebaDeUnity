using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer SR;
    private Animator anim;

    [Header("Atributos")]

    [SerializeField] public int vida;
    [Header("Movimiento")]
    

    private float MovimientoHorizontal = 0f;
    [SerializeField] public float velocidadDeMovimiento;
    [Range(0f, 0.3f)] [SerializeField] private float Suavizado;
    private Vector3 velocidad = Vector3.zero;
    private bool Derecha = true;

    [Header("Salto")]
    [Range(0f, 7f)][SerializeField] private float FuerzaSalto;
    [HideInInspector] public Saltar saltarScript;
    void Start()
    {
        saltarScript = FindObjectOfType<Saltar>();
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

         MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        anim.SetFloat("Horizontal", Mathf.Abs(MovimientoHorizontal));
        if (Input.GetButtonDown("JumpPc") && saltarScript.brincar)
        {
            rb.velocity = new Vector2(rb.velocity.x, FuerzaSalto);
        }
        if(vida < 40)
        {
            velocidadDeMovimiento = 180;
        }
        else
        {
            velocidadDeMovimiento = 300;
        }
    }
    private void FixedUpdate()
    {
        Mover(MovimientoHorizontal * Time.fixedDeltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidadDeObjetivo = new Vector2(mover, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidadDeObjetivo, ref velocidad, Suavizado);
        if (mover>0 && !Derecha)
        {
            Derecha = !Derecha;
        }
        else if (mover < 0 && Derecha)
        {
            Derecha = !Derecha;
        }

        if (!Derecha)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
        

    }

}
