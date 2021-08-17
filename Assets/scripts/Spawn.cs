using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            float time = Random.Range(0.3f, 0.6f);
            int index = Random.Range(0, enemies.Length - 1);
            float x = Random.Range(-3, 3);

            yield return new WaitForSeconds(time);

            Vector3 position = transform.position;
            position.x = x;

            GameObject enemy = Instantiate(enemies[index], position, transform.rotation);

            Destroy(enemy, 5);
        }
    }


    
}
