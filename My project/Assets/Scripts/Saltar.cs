using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    public bool brincar = false;
    private Animator anim;
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Suelo")
        {
            brincar = true;
            anim.SetBool("Salto", !brincar);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Suelo")
        {
            brincar = false;
            anim.SetBool("Salto", !brincar);
        }
    }
}
