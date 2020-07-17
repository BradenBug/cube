using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    Vector2 spawnPosition = new Vector2(0, 5);
    public GameObject[] obstacles;
    public float speed = 3.0f;
    public float startWait = 0.5f;
    public float spawnWait = 0.5f;
    public bool go = true;
    int randObstacle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(startWait);
        int counter = 0; 

        while (go)
        {
            if (counter >= 5) {
                Time.timeScale += 0.1f;
                counter = 0;
            }
            randObstacle = Random.Range(0, obstacles.Length); 
            GameObject localObject = Instantiate(obstacles[randObstacle]); 
            localObject.GetComponent<ObstacleBehavior>().speed = speed;
            counter++;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
