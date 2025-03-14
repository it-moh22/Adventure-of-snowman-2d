using System.Collections;
using UnityEngine;
public class Snowball : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    private Vector3 startPos;
    private float dieTime = 5f;    
    private float respawnTime = 5f;    
    private Renderer render;
    private Collider2D collider;
    private bool hidden = false;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
        if (spawn != null)
        {
            startPos = spawn.position;
        }
        else
        {
            startPos = transform.position;
        }
    }
    private void Start()
    {
        StartCoroutine(SnowballLifeCycle());
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Purly"))
        {
            Destroy(obj.gameObject);
        }
    }
    private IEnumerator SnowballLifeCycle()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(dieTime);

            HideSnowball();

            yield return new WaitForSeconds(respawnTime);

            ShowSnowball();
        }
    }
    private void HideSnowball()
    {
        if (hidden) return;

        if (render != null) render.enabled = false;

        if (collider != null) collider.enabled = false;

        hidden = true;
    
    }
    private void ShowSnowball()
    {
        if (!hidden) return;

        transform.position = startPos;

        if (render != null) render.enabled = true;

        if (collider != null) collider.enabled = true;

        hidden = false;   
    }
}