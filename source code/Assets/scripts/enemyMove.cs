using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed = 2f;
    bool move = true;
    public float Start;
    public float End;
    public enum directions
    {
        x,
        z
    }
    public directions direction;
    private void Update()
    {
        switch (direction)
        {
            case directions.z:
                if (transform.position.z > Start)
                {
                    move = false;
                }
                else if (transform.position.z < End)
                {
                    move = true;
                }
                if (move)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                }
                break;

            case directions.x:
                if (transform.position.x > Start)
                {
                    move = false;
                }
                else if (transform.position.x < End)
                {
                    move = true;
                }
                if (move)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                break;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
