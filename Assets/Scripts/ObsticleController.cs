using UnityEngine;
using System.Collections;

public class ObsticleController : MonoBehaviour
{
	public Transform LeftPlaceholder;
	public Transform RightPlaceholder;
	public GameObject LeftObsticle;
	public GameObject RightObsticle;
	public float maxSpawnWait;
	public float minSpawnWait;
	public int maxStartWait;
	public int minStartWait;
	public int maxWaveWait;
	public int minWaveWait;
	public int hazardCount;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (Random.Range (minStartWait, maxStartWait));
		while (true) {
			if (GameController.paused)
				break;
		
			for (int i = 0; i < hazardCount; i++) {
				if (GameController.paused)
					break;

				int r = Random.Range (0, 2);
				if (r == 0) {
					Instantiate (LeftObsticle, LeftPlaceholder.position, LeftPlaceholder.rotation);
				} else {
					Instantiate (RightObsticle, RightPlaceholder.position, RightPlaceholder.rotation);
				}
				yield return new WaitForSeconds (Random.Range (minSpawnWait, maxSpawnWait));
			}
			yield return new WaitForSeconds (Random.Range (minWaveWait, maxWaveWait));
		}
	}
}
