using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    SpriteRenderer Sp;
    BoxCollider2D col;
    public bool changeScale = true;
    float addWater;                                      //la valeur qu'on va ajouter chaque fois que la goutte touche le sol
    public float maxWaterPosY;                          //l'hauteur maximale de l'eau que l'on souhaite
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(0, -5);
        col = GetComponent<BoxCollider2D>();
        Sp = GetComponent<SpriteRenderer>();
        addWater = (maxWaterPosY - Sp.size.y) / (float)sol.vie;               //calcule combient il faut ajouter de l'eau en fonction de la vie choisit
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator WaitChangeScale()                                                   //ienumerator pour rendre la transition entre un endroit et un autre smooth
    {
        float WaterNiveau = Sp.size.y + addWater;                      //on va calculer le niveau de l'eau que l'on veut atteindre
        while (Sp.size.y < WaterNiveau)
        {
            if (changeScale == true)
            {
                /*col.size += new Vector2(0, addWater / 15);
                Sp.size += new Vector2(0, addWater / 15);*/
                //transform.localScale += new Vector3(0, addWater / 15, 0);
                Sp.size += new Vector2(0f, addWater / 15);
                yield return new WaitForSeconds(0.01f);

            }
        }
        yield return null;
    }

    public void waterRaise()
    {
        StartCoroutine(WaitChangeScale());
    }
}
