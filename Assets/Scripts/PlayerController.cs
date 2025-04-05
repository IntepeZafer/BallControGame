using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp;
    public float powerStrength = 15.0f;
    public GameObject PowerIndicator;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        PowerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            PowerIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerCountDownRoutine());
        }
    }
    IEnumerator PowerCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PowerIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Collied With" + collision.gameObject.name + "with powerup set to" + hasPowerUp);
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }
}
