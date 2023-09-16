using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 200f;
    public Text text;
    public int score = 0;
    public int maxScore = 5;
    public bool key = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        text.text = "Score: " + score + " / " + maxScore;
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6 && score == maxScore)
        {
            SceneManager.LoadScene(0);
        }
        else if (score == maxScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _rb.velocity = transform.TransformDirection(new Vector3(h, _rb.velocity.y, v) * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            score++;
            text.text = "Score: " + score + " / " + maxScore;
        }

        if (other.gameObject.name == "barrier")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.tag == "key")
        {
            other.gameObject.SetActive(false);
            key = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "coins")
        {
            score++;
            text.text = "Score: " + score + " / " + maxScore;
        }
        if (other.gameObject.tag == "movePlatform")
        {
            this.transform.parent = other.transform;
        }
        if (other.gameObject.tag == "moveWall" && key == true)
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, 2, other.transform.position.z);
            key = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "movePlatform")
        {
            this.transform.parent = null;
        }
    }
}
