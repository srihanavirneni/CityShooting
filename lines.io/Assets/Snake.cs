using UnityEngine;

public class Snake : MonoBehaviour {

    public float speed = 3f;
    public float rotationSpeed = 200f;

    public string InputAxis = "Horizontal";

    float horizontal = 0f;
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxisRaw(InputAxis);
	}

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "killable")
        {
            speed = 0f;
            rotationSpeed = 0f;

            GameObject.FindObjectOfType<GameManager>().EndGame();

        }
    }
}
