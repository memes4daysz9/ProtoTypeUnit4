using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 25f;
    private GameObject focalPoint;
    bool hasPowerUp = false;
    float powerupStrength = 100.0f;
    public GameObject powerupIndecator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed); //WEEEEEEE moment

        powerupIndecator.transform.position = transform.position + new Vector3(0,-0.5f,0);

        
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerupIndecator.gameObject.SetActive(true); //powerup moment
            PowerCountDownRoutine();
        }
        IEnumerator PowerCountDownRoutine(){
            yield return new WaitForSeconds(7);
            hasPowerUp = false;
            powerupIndecator.gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp){

            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); //really fast WEEEEE moment

            Debug.Log("Collided with " + collision.gameObject.name + "with powerup set to " + hasPowerUp);

            enemyRB.AddForce(awayFromPlayer * powerupStrength,ForceMode.Impulse);





        }
    }
}
