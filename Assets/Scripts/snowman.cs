using UnityEngine;

public class snowman : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rotationSpeed = 100.0f;

    float translation = 0, rotation = 0;
    public GameObject[] snowball;
    private void Awake()
    {
        snowball = GameObject.FindGameObjectsWithTag("snowball");
    }

    void Start()
    {
        
    }

    //called once per frame
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
        Vector2 targetPosition = transform.position;

        foreach (GameObject snowball in snowball)
        {
            if (snowball != null) 
            {
                snowball.transform.position = Vector2.MoveTowards(snowball.transform.position, targetPosition, (speed / 5) * Time.deltaTime);
            }
        }
    }
    
    void OnTriggerEnter2D (Collider2D obj){
        if (obj.CompareTag("Balloon"))
        {
            Destroy(obj.gameObject);
        }
 
    }

}
