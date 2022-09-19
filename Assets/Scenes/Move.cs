using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform enemy;
    // Start is called before the first frame update
    public bool canThrow = false;

    private Rigidbody rb;

    Vector3 lastVelocity;

    public float PowEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = gameObject.GetComponent<Transform>();
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(MoveEnemy(2f));
        if(canThrow)
        {
            StartCoroutine(ThrowEnemy(2f));
        }
        lastVelocity = rb.velocity;
    }
/*
    IEnumerator MoveEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        enemy.Translate(Vector3.left * Time.deltaTime);
    }*/

    IEnumerator ThrowEnemy(float waitTime)
    {
        canThrow = false;
        yield return new WaitForSeconds(waitTime);
        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 10) * PowEnemy, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);

        if (collision.gameObject.tag == "Player")
        {
            //Thuc hien viec chup lai qua banh
            
            //Sau 2s thực hiện việc ném quả banh
        }

        //thuc hien viec pha huy vat can
    }
}
