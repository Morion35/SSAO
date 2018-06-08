using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour {
	
	public GameObject ennemies;

	private int max_ennemies;
	
	private float _time;

	public float count;
	// Use this for initialization
	void Start ()
	{
		max_ennemies = ennemies.transform.childCount;
		_time = 10f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			GetComponent<TextMeshProUGUI>().SetText("Enemies To Kill :" + (ennemies.transform.childCount - max_ennemies/2));
			if (transform.parent.parent.position.x <= -16f)
			{
				if (ennemies.transform.childCount - max_ennemies/2 <= 0)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				}
				if (count == 0f)
				{
					count = _time + Time.time;
					return;
				}
				if (count < Time.time)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				}
				GetComponent<TextMeshProUGUI>().text += "\n time before next map : " + (int) (count - Time.time + 1);
			}
		}
		else
		{
			if (SceneManager.GetActiveScene().buildIndex == 2 && transform.parent.parent.position.x <= -101f)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}
