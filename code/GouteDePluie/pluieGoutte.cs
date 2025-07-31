using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pluieGoutte : MonoBehaviour
{
    GameObject Camera;

    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("Camera");
    }

    void Update()
    {

    }


    //detruire au sol
    
    //detruire au contact avec la boule
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "feu")
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                Camera.GetComponent<Animator>().SetTrigger("Shake 0");              //trembler la camera 
            }
            else 
            {
                Camera.GetComponent<Animator>().SetTrigger("Shake 1");              //trembler la camera aleatoirement
            }
            scoreManager.playerHitWater++;           //augmente le score du player
            GameObject FireBall = col.gameObject;
            bullet other = (bullet) FireBall.GetComponent(typeof(bullet));
            other.Destroybullet();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "sol")
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                Camera.GetComponent<Animator>().SetTrigger("Shake 0");              //trembler la camera 
            }
            else if (x == 1)
            {
                Camera.GetComponent<Animator>().SetTrigger("Shake 1");              //trembler la camera aleatoirement
            }
            scoreManager.waterHitLava++;             //augmente la valeur qui calcule combient de fois la goutte a toucher la lave
            Destroy(GetComponent<Rigidbody2D>());               //we don't destroy immediatly gameobject to let the animation finish
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("Touch_Sol");
            


        }
    }


    

    public void DestroyAnimation()
    {
        Destroy(gameObject);
    }
}
