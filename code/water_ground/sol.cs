using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sol : MonoBehaviour
{
    public static int vie = 5;
    public static int resetVie;
    byte moin = 255;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        resetVie = vie;
        if (vie != 0)
        {
            x = (int)moin / vie;
            moin = (byte)x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "water")
        {
            vie--;
            //gameObject.GetComponent<SpriteRenderer>().color -= new Color32(moin, 0, 0, 0);
            GameObject Water = this.gameObject;
            WaterScript other = (WaterScript)Water.GetComponent(typeof(WaterScript));
            other.waterRaise();
        }
    }
}
