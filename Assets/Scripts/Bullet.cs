using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float power;
    public float trajectoryError;

    void Start () {
        GetComponent<Rigidbody2D>().AddForce((transform.up + new Vector3(0.0f, Random.Range(-trajectoryError, trajectoryError), 0.0f)) * speed);
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag != "Player")
        Destroy(gameObject);
    }
}
