using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public GameObject player;
	public GameObject red;
	public float fallDeathDistance = -40.0f;
	public float timer;
	public float wait;
	bool played = false;

	AudioSource audioS;
	public AudioClip deathS;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("RigidBodyFPSController");
		red = GameObject.Find ("red");
		audioS = GetComponent<AudioSource> ();

		red.SetActive (false);

	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;

		if (player.transform.position.y <= fallDeathDistance && !audioS.isPlaying && played == false) {
			
			audioS.clip = deathS;
			audioS.Play ();
			timer = 0;
			timer = wait;
			played = true;
			red.SetActive (true);
		}

		if (timer < 0 && played == true) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}

		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
		

}
