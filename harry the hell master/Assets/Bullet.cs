using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public GameObject oject;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyB", lifetime);
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        //transform.Translate(transform.position * speed * Time.deltaTime);
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void DestroyB()
    {
        Instantiate(oject,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
