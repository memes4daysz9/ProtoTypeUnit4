using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 300.0f;
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
        EnemyRB.AddForce((player.transform.position - transform.position) * speed);
    }
}
