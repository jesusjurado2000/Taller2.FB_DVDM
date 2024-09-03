using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        
        if (transform.position.x < -10f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        if (GameManager.Instance.isGameOver)
            return;
        transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
