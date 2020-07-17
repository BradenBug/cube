using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    public FollowCurve followCurve;
    private Color newColor;
    public float speed;
    public bool isMover;
    private bool changeColor = false;
    private float colorFade = -0.01f;
    public bool goRight;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isMover) {
            followCurve = GameObject.FindObjectOfType<FollowCurve>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + Vector2.down * speed * Time.deltaTime);
        if (changeColor)
        {
            newColor = spriteRenderer.color;
            newColor.b += colorFade;
            spriteRenderer.color = newColor;
        }
        if (isMover && (rigidBody.position.y <= 0))
        {
            followCurve.setVerticalSpeed(-speed);
            followCurve.initFollow(goRight);
            isMover = false;
            colorFade = -colorFade * 5;
        }
    }
    
    void OnBecameVisible()
    {
       changeColor = isMover; 
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
