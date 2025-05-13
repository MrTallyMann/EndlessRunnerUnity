using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] levels; //[] makes this a list
    public float zPos = 79f; //z scale of ground
    public bool create = true; //helps when creating levels
    public int lvlnum; //picks a level to load out of the 3
    private int check = 0;
    private float destroyDelay = 15f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (create == true)
        {
            create = false;
            StartCoroutine(GenerateLevel()); //einai methodos (def/sunarthsh) pou elegxoume kathe pote trexei (sec/frames)

        }
    }

    IEnumerator GenerateLevel() //ti tha kanei h GenerateLevel
    {
        lvlnum = Random.Range(0, levels.Length); //Random.Range(0,3) tha htan 0,1,2 OXI 3 auto apla pernei to length ths "levels"
        //mporw na ftiaxw kialla levels kai tha mpoun automata
        GameObject newLevel = Instantiate(levels[lvlnum], new Vector3(93.7f, 0, zPos), Quaternion.identity);
        //levels[lvlnum] einai to GameObject pou kerdise sthn klhwrsh tou Random.Range
        // makes it a game object so it can be deleted to reduce lag
        zPos += 79f;
        StartCoroutine(DestroyLevelAfterDelay(newLevel, destroyDelay));
        yield return new WaitForSeconds(3f); //poso tha perimenei
        create = true;
    }

    IEnumerator DestroyLevelAfterDelay(GameObject level, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (level != null) // Check if the level still exists
        {
            Destroy(level);
        }
    }
}
    