using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;


    //speed at which the appletree moves
    public float speed = 1f;

    //distance where appletree turns around
    public float leftAndRightEdge = 10f;

    //change that appletree will change directions
    public float chanceToChangeDirections = 0.1f;

    //rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;


    private float appleDropps = 1f;

    private void Start()
    {
        // Dropping apples every second
        //Invoke("DropApple", 2f);
        StartCoroutine(DropApple());
    }

    IEnumerator DropApple()
    {
        yield return new WaitForSeconds(appleDropps);

        GameObject apple = Instantiate<GameObject>(applePrefab);

        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);

        StartCoroutine(DropApple());
    }
    

    private void Update()
    {
        Move();
        

    }
    void Move()
    {
        // Basic Movement
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
