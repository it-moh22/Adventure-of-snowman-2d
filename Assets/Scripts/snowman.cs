using UnityEngine;

public class snowman : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rotationSpeed = 100.0f;

    float translation = 0, rotation = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = speed * Time.deltaTime;
        rotation = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(-translation, 0);        
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(translation, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(0, translation);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(0, -translation);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(0, rotation, 0);
        }
    }
}
