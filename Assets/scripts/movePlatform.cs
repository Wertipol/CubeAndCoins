using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
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
}
