using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float angle;
    public float offset;
    public int speed;
    
    Vector2 targetPos;
    Vector2 thisPos;
    
    void Start()
    {
        targetPos = player_shoot.mousePos;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        StartCoroutine(WaitDestroy());
    }
    void Update()
    {
        mouvetomouse();
    }
    //bullet will move in the mouse direction
    void mouvetomouse()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);     //Vector2.down car l'asset de la boule de feu est inversé et la velocité depend de la direction, si la direction est contraire a la direction originale elle va forcement aller de l'autre coté
    }

    public void Destroybullet()
    {
        GetComponent<Animator>().SetTrigger("Destroy");
        GetComponent<Collider2D>().enabled = false;
        speed = 0;
    }

    // ll wait several time and then distroy bulllet to optimize the app
    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroybullet();
    }

    public void DestroyBulletAfterAnimation()
    {
        Destroy(gameObject);
    }
}
