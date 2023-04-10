using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    EnemyController EnemyControllerScript;
    SpawnManager SpawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        EnemyControllerScript = GameObject.Find("Enemy").GetComponent<EnemyController>();
        SpawnManagerScript = GameObject.Find("Enemy").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
