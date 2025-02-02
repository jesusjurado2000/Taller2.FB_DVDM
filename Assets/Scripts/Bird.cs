using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField, Range(0, 10)]
    private float speed;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    public AudioSource aleteo;
    public AudioSource hit;
    public AudioSource caida;
    public AudioSource point;
    private bool yaSonoCaida = false;
    private bool yaSonoHit = false;


    private void Awake()
    {
        if (rigidbody2D == null)
            rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Code for Andorid
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            Move();

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            Move();
#endif
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Pipe") || collision2D.collider.CompareTag("Ground"))
        {
            Debug.Log(string.Format("Bird :: OnCollisionEnter2D() :: {0}", collision2D.collider.name));
            if (yaSonoHit == false)
            {
                hit.Play();
                yaSonoHit = true;
            }

            GameManager.Instance.GameOver();
        }
        if (collision2D.collider.CompareTag("Pipe"))
        {
            if (yaSonoCaida == false)
            {
                caida.Play();
                yaSonoCaida = true;
            }            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("PipeTrigger"))
        {
            Debug.Log(string.Format("Bird :: OnTriggerEnter2D() :: {0}", collider2D.name));
            point.Play();
            GameManager.Instance.IncreaseScore();
        }
    }

    private void Move()
    {
        Debug.Log("Bird :: Move()");

        rigidbody2D.velocity = Vector2.up * speed;

        if(Time.timeScale == 1f)
        {
            aleteo.Play();
        }
    }

    public void FreezeeBirdPosition()
    {
        Debug.Log("Bird :: FreezeeBirdPosition()");

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

        rigidbody2D.AddForce(Vector2.zero);
    }

    public void UnfrezeeBirdPosition()
    {
        Debug.Log("Bird :: UnfrezeeBirdPosition()");

        rigidbody2D.constraints = RigidbodyConstraints2D.None;

        rigidbody2D.AddForce(Vector2.zero);
    }
}
