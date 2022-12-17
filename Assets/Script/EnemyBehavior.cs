using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public float aggroRange;
    public float speed;
    Rigidbody2D rb;
    public LayerMask attackMask;
	public int AttackDamage = 25;
    public Transform player;
    public bool isFlipped = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        //jika jarak enemy dan player kurang dari aggroRange maka kejar player
        if(distToPlayer < aggroRange)
        {
            chasePlayer();
        }
        //selain itu berhenti
        else
        {
            stopChasing();
        }
    }

	public void Attack () {

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if(colInfo != null)
		{
			colInfo.GetComponent<Health>().TakeDamage(AttackDamage);
		}

	}
    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void chasePlayer()
    {
        anim.SetBool("chase", true);
        if(transform.position.x < player.position.x)
        {
            //kalo di kiri, kejar ke kiri
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            //selain itu kejar ke kanan
            rb.velocity = new Vector2(-speed, 0);
        }
    }
    void stopChasing()
    {
        anim.SetBool("chase", false);
        rb.velocity = Vector2.zero;
    }
}