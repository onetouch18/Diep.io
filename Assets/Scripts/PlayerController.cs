using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    Vector3 movement;
    Rigidbody2D playerRigidbody;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Turning();
        Move(horizontal, vertical);

    }

    void Turning()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, vertical, 0);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
