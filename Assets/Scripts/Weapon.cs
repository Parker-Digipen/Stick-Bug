using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    private Rigidbody2D paRB;
    public Transform paTr;
    private FollowingCamera cam;
    private SpriteRenderer mySR;
    public GameObject particles;
    public float LerpVal;
    public float recoil;
    public float verticalKick = 1;
    public float horizontalKick = 1;
    public float shake = 1;
    public float shakeTime = 0.1f;
    public float speed;
    public float delay;
    private float lastShot;
    private bool facingRight = true;
    private Vector3 startPos;
    private Vector3 backPos;

    // Start is called before the first frame update
    void Start()
    {
        paRB = GetComponentInParent<Rigidbody2D>();
        cam = FindObjectOfType<FollowingCamera>();
        mySR = GetComponent<SpriteRenderer>();
        startPos = transform.localPosition;
        backPos = new Vector3(-transform.localPosition.x, transform.localPosition.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
        
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShot+delay)
        {
            lastShot = Time.time;
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = (transform.up*speed);
            //recoil
            paRB.AddForce(-recoil * new Vector3(transform.up.x + horizontalKick, transform.up.y + verticalKick, 0) + new Vector3(paRB.velocity.x, paRB.velocity.y, 0));
            //screen shake
            cam.TriggerShake(shakeTime, shake);
            //particle burst
            GameObject clun = Instantiate(particles, transform.position, transform.rotation);
        }

        if (paTr.localScale.x > 0)
        {
            if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 180)
            {
                //transform.localPosition = startPos;
                transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * LerpVal);
                mySR.flipX = false;
            }
            else if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180)
            {
                //transform.localPosition = -startPos;
                transform.localPosition = Vector3.Lerp(transform.localPosition, backPos, Time.deltaTime * LerpVal);
                mySR.flipX = true;
            }
        }
        else if (paTr.localScale.x < 0)
        {
            if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 180)
            {
                //transform.localPosition = -startPos;
                transform.localPosition = Vector3.Lerp(transform.localPosition, backPos, Time.deltaTime * LerpVal);
                mySR.flipX = true;
            }
            else if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180)
            {
                //transform.localPosition = startPos;
                transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * LerpVal);
                mySR.flipX = false;
            }
        }
    }
}
