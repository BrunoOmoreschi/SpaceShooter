using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject explosion;

    //Ação que acontece on trigger - ative o on trigger no elemento que for tocar nele.
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        //Linha para destruir o tiro, ou objeto que tocar no inimigo.
        Destroy (collision.gameObject);
        //Destroy e demora tanto tempo para animação de explosão.
        Destroy (boom, 0.8f);
        //Destroi o inimigo em questão, self.
        Destroy(gameObject);
    }
}
