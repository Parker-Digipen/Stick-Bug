using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth = 10;
    public int MaxHealth = 10;

    public bool DestroyAtZero = true;

    public float InvincTime = 0;
    public float InvTimer = 0;

    public float DeathTime = 2.3f;
    bool Dying = false;
    private AudioSource myAD;
    public AudioClip hurt;
    public AudioClip death;
    public void ChangeHealth(int amount)
    {
        if(CurrentHealth - 1 != 0)
        {
            myAD.PlayOneShot(hurt);
        }
        //check if the amount is damage if so check if invincibility currently
        if (amount >= 0 || InvTimer <= 0)
        {
            CurrentHealth += amount;
            if (amount < 0)
                InvTimer = InvincTime;
        }
        // if not add amount

        //if reduced to zero and we need to destroy it
        if (CurrentHealth <= 0 && DestroyAtZero)
        {
            if (!Dying)
                StartCoroutine(TimedDeath());
        }
        //if over max health fix that
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    IEnumerator TimedDeath()
    {
        myAD.PlayOneShot(death);
        Dying = true;
        yield return new WaitForSeconds(DeathTime);
        Death Grim = GetComponent<Death>();
        if (Grim != null)
        {
            Grim.OnDeath.Invoke();
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        myAD = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InvTimer > 0)
        {
            InvTimer -= Time.deltaTime;
        }
    }
}
