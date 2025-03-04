using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpmainplayer : MonoBehaviour
{

    public int health = 20 ;
    public int healinfo ;
    public  int mana = 10;
    public int manainfo ; 
    public float recoverymana = 2f ;

    void Start()
    {
        healinfo = health ;
        manainfo = mana;
    }
    void Update ()
    {
        manarecovery ();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if ( health < 0 )
        {
            Die();
        }
    }
    public bool usemana(int amount)
    {
        if (manainfo >= amount)
        {
            manainfo -= amount;
            return true ;
        }
        else 
        {
            return false ;
        }
    }
    void manarecovery ()
    {
        if (manainfo < mana)
        {
            manainfo += Mathf. RoundToInt(recoverymana * Time.deltaTime );
            manainfo = Mathf.Min(manainfo , mana);
        }
    }

    void Die ()
    {
        Debug.Log(gameObject.name + " die ");
        Destroy(gameObject);
    }
    
}
