using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potView : MonoBehaviour
{

	//How often (in seconds) VisionTracker will check what is looking at what.
	public static float interval = 0.5f;

	//totalLookAtScore will only increment when the lookAtScore is at least this much.
	public float lookAtThreshold = 0.8f;

	//how many seconds of history VisionTracker will record.
	public float lookAtHistorySeconds = 5;

	//If the main camera is farther than this distance, then LookAtScore will return -1.
	//Set to zero for no maximum distance.
	public float maximumDistance;
	private float maximumDistanceSquared;

	private float totalLookAtScore = 0;
	private GameObject player;
	private float[] lookAtHistory;
	private int historyIndex = 0;
	private WaitForSeconds waitForSeconds;

	private bool gaze = false;
	private bool viewed = false;
	private float startGazeTime;

	private const float minGazeTime = 2f;

	public ParticleSystem potParticles;


	void Start()
	{
		waitForSeconds = new WaitForSeconds(interval);
		maximumDistanceSquared = maximumDistance * maximumDistance;
		player = Camera.main.gameObject;
		lookAtHistory = new float[Mathf.CeilToInt(lookAtHistorySeconds / interval)];
		StartCoroutine(Cycle());
	}

	public float GetHistoryScore()
	{
		//returns a number between [-1,1] where 1 means the player has been directly looking at this object for lookAtHistorySeconds seconds.
		// 0.6 means the player has been somewhat looking at it in these past lookAtHistorySeconds seconds.
		float total = 0;
		foreach (float i in lookAtHistory)
			total += i;
		return total / lookAtHistory.Length;
	}

	public float GetLookAtScore()
	{
		//returns a score between [-1,1] where 1 means the player is looking directly at this object right now, -1 means directly looking away.
		Vector3 playerToObject = gameObject.transform.position - player.transform.position;

		if (maximumDistance != 0 && playerToObject.sqrMagnitude > maximumDistanceSquared)
			return -1;

		playerToObject.Normalize();
		Vector3 lookDirection = Camera.main.transform.forward;

		return Vector3.Dot(playerToObject, lookDirection);
	}

	public float GetTotalLookAtScore()
	{
		//The total number of seconds that the player has been directly looking at this object.
		//"Directly" means having a greater lookAtScore than the threshold value.
		return totalLookAtScore;
	}

	private IEnumerator Cycle()
	{
		yield return new WaitForSeconds(Random.Range(0, interval));
		while (true)
		{
			float score = GetLookAtScore();
			if (score > lookAtThreshold)
				totalLookAtScore += interval;

			lookAtHistory[historyIndex] = score;
			historyIndex++;
			historyIndex = historyIndex % lookAtHistory.Length;

			yield return waitForSeconds;

		}
	}

    void Update()
    {
		//Check for gaze time?
		float score = GetLookAtScore();
		//if (!gaze)
		//{
		//	//            startGazeTime = Time.time;
		//	//            //Debug.Log(startGazeTime);
		//	//            gaze = true;
		//	if (score > lookAtThreshold)
		//	{
  //              startGazeTime = Time.time;
  //              gaze = true;

  //              //Start animation (if gaze time is enough)
  //              Debug.Log("OH YEAH");
		//	}
		//	else
		//	{
		//		gaze = false;
		//		Debug.Log("No, score: " + score);
		//		//Stop Animation
		//	}
		//}
		//else //Not the first frame we have viewed it
  //      {
  //          if ((Time.time - startGazeTime >= minGazeTime) && !viewed)
  //          {
  //              Debug.Log("Viewing POT");
  //              viewed = true;
  //          }

		//}

		if (score > lookAtThreshold) //We're looking at the pot
		{
			if (!gaze)
			{
				startGazeTime = Time.time;
				gaze = true;

				Debug.Log("OH YEAH");
			}
			
			else //Not the first frame we have viewed it
            {
                if (Time.time - startGazeTime >= minGazeTime && !viewed)
                {
					//Start animation (if gaze time is enough)
					potParticles.Play();
					Debug.Log("Viewing POT");
                    viewed = true;
                }
            }
		}
		else //We're not looking at the pot
        {
			potParticles.Stop();
			gaze = false;
			viewed = false;
			Debug.Log("No, score: " + score);
		}
	}

    //public Camera mainCam;

    //private bool isVisible(Camera c)
    //{
    //    var planes = GeometryUtility.CalculateFrustumPlanes(c);
    //    var point = transform.position;

    //    foreach(var plane in planes)
    //    {
    //        if(plane.GetDistanceToPoint(point) > 0)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //void Update()
    //{
    //    var targetRender = GetComponent<Renderer>();

    //    if(isVisible(mainCam))
    //    {
    //        Debug.Log("VIEW!");
    //    }
    //    else
    //    {
    //        Debug.Log("NOT VIEWED");
    //    }
    //}
}
