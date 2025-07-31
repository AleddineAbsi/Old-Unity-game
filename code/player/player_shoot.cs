using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour
{
    //bool 
    bool canShoot = true;
    //gameObject
    public GameObject projectile;

    //int
    //float
    public float shootTime;                 //attente entre chaque shoot
    //other
    public Camera cam;
    public static Vector2 mousePos;
    //Vector


    void Start()
    {
        GetComponent<Renderer>().enabled = true;
    }

    void Update()
    {
        MosePosInt();
        DetectionTouche();
        if (sol.vie <= 0)
        {
            Die();
        }
    }
    
    
    //on recherche la position de la souris par rapport au jeu 
    void MosePosInt()
    {
        //mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    
    
    //On detecte ou est-ce que la souris a frappé
    void DetectionTouche()
    {
        if (Input.GetMouseButtonDown(0) && mousePos.y > transform.position.y + 0.5 && canShoot == true && sol.vie > 0 && Time.timeScale != 0)
            {
                Instantiate(projectile,transform.position, Quaternion.identity);
                GetComponent<Animator>().SetBool("Shoot", true);
                StartCoroutine(waitShoot());
            }
    }

    //quand il meurt
    void Die()
    {
        GetComponent<Animator>().SetTrigger("Death");
    }


    //on desactive le rendu
    public void rendererDesactivate()
    {
        GetComponent<Renderer>().enabled = false;
    }



    //On attend a chaque shoot 
    IEnumerator waitShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootTime);
        GetComponent<Animator>().SetBool("Shoot", false);
        canShoot = true;
    }


}
