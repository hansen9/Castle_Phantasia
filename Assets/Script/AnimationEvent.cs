using UnityEngine;
using System;
using System.Collections;

//Just for demonstration, you can replace it with your own code logic.
public class AnimationEvent : MonoBehaviour {

	public GameObject enemy;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
	public int bossAttackDamage = 50;

	public void AttackStart () {
		Debug.Log ("Attack Start");

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if(colInfo != null)
		{
			colInfo.GetComponent<Health>().TakeDamage(bossAttackDamage);
		}

	}

	public void AttackStartEffectObject () {
		Debug.Log ("Fire Effect Object");
	}

}
