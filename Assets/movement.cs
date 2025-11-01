using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public float gravity = -2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool grounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
       
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = transform.TransformDirection(move);


        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
            grounded = true;
        }
    }
}
