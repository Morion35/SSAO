using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA;

public class bossIA : MonoBehaviour {

	public bool isFocused;

	public bool hint;

	public GameObject capsule;

	public Transform Player;

	public float HP = 100;
	
	private GameObject[] Players;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	public float firetime = 5f;

	public float damage = 10f;

	private float fireuse;

	public GameObject spawn;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
		
		initialDir = transform.rotation;

		Players = GameObject.FindGameObjectsWithTag("Player");

		int i = 0;
		while (i < Players.Length && !Players[i].activeSelf)
		{
			i++;
		}
		Player = Players[i].transform;

		isFocused = false;

		audio = Players[0].GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
		fireuse = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HP <= 0)
		{
			nav.isStopped = true;
			Destroy(gameObject, 3f);
			return;
		}
	    NavMeshHit hit;
		Vector3 targetDir = Player.position - transform.position;
		if (Vector3.Angle((Player.position - transform.position), Vector3.forward) < 20f && Time.time > fireuse && !nav.Raycast(Player.position, out hit))
		{
			Instantiate(capsule, spawn.transform.position, transform.rotation, transform);
			fireuse = Time.time + firetime;
		}
		else
		{
			nav.SetDestination(Player.position);
		}
    }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("porte"))
		{
			other.gameObject.GetComponent<porte>().HP = 0;
		}
	}
}
