using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public FollowCurve followCurve;
    private bool storedInput = false;

    // Start is called before the first frame update
    void Start()
    {
       followCurve = GameObject.FindObjectOfType<FollowCurve>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !followCurve.isFollowing())
            {
                followCurve.initFollow(true);
            }
            else if (touch.phase == TouchPhase.Began && followCurve.isFollowing())
            {
                storedInput = true;
            }
        }
        else if (storedInput && !followCurve.isFollowing())
        {
            storedInput = false;
            followCurve.initFollow(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
    }
}
