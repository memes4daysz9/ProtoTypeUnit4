using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 2.5f;
    private Rigidbody EnemyRB;
    private GameObject player;
    void Start()
    {
       EnemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirecton = (player.transform.position - transform.position).normalized; // ai momento numero dos
        EnemyRB.AddForce(lookDirecton* speed);
        if (transform.position.y < -10 ){Destroy(gameObject);}//kill enemy
    }
}
