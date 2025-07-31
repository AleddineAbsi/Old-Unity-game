using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPluie : MonoBehaviour
{
    //gameobject
    public GameObject goutte;

    //bool
    public static bool gameStarted = false;
    bool canSpawn = true;
    bool augmenterDifficulter = true;
    bool raining = true;

    //int
    int difficultyLevel = 0;
    public int difficultyLevelMax;

    //float
    public float waitSpawnTime;
    public float difficultyLevelDuration;
    


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sol.vie > 0 && gameStarted)
        {
            difficultyFunction();
            spawnGoutte();
        }
    }

    
    // apparaitre des gouttes de pluie sur le terrain
    void spawnGoutte()
    {
        if (canSpawn == true)
        {
            Instantiate(goutte, new Vector2(Random.Range(-2.50f, 2.50f), Random.Range(5.5f,7f)), Quaternion.identity);
            StartCoroutine(WaitSpawn());
        }
    }

    //attendre un peu avant de faire apparaitre l'autre goutte
    IEnumerator WaitSpawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(waitSpawnTime);
        canSpawn = true;
    }

    //Augmenter la difficulter

    void difficultyFunction()
    {
        if (augmenterDifficulter == true && difficultyLevel < difficultyLevelMax)
        {
            waitSpawnTime -= 0.1f;                                                  //on retrecit le temps que prend les goutes à arriver
            difficultyLevel++;
            StartCoroutine(difficultyEnumerator());
        }
    }
    IEnumerator difficultyEnumerator()
    {
        augmenterDifficulter = false;
        yield return new WaitForSeconds(difficultyLevelDuration);                   //durée de chaque niveau de difficulter
        augmenterDifficulter = true;
    }
}
