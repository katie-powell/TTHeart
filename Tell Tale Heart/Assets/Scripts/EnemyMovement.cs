using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public NavMeshAgent nav;
	public float speed;

	bool is_waiting = false;

	void Start ()
	{
		StartCoroutine ("TenSecondTimer");

	}

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
    }

	IEnumerator TenSecondTimer()
	{
		while (true) {
			yield return new WaitForSeconds(10);
			is_waiting = true;
			yield return new WaitForSeconds(1.5f);
			is_waiting = false;
		}
	}

    void Update ()
    {

		if (is_waiting == false) {
			nav.SetDestination (player.position);
		} else {
			nav.SetDestination (this.transform.position);
		}

    }
}
