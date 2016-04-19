/// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class MineBot: MonoBehaviour {

	protected Animator avatar;
	public AudioClip[] servoSteps;

	AudioSource legs;

	public float DirectionDampTime = .25f;
    public bool step = false;
	int count;


	void OnGUI()
	{

		GUILayout.Label("Mecanim now works with generic skeletons!");	
	}

	// Use this for initialization
	void Start () 
	{
		legs = GetComponent<AudioSource>();
		avatar = GetComponent<Animator>();
	}

	void Update () 
	{
		if(avatar)
		{
			bool j = Input.GetButton("Fire1");
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			if (h > 0.0f | h < 0.0f)
			{ 
				if(!legs.isPlaying)
				{
					legs.Play();
				}
			}
			else
			{
				
				legs.Stop();
				legs.PlayOneShot(servoSteps[0]);
			}

			avatar.SetFloat("Speed", h*h+v*v);
			avatar.SetFloat("Direction", Mathf.Atan2(h,v) * 180.0f / 3.14159f);
			avatar.SetBool("Jump", j);

            if (step)
            {
                Stepping();
            }

			Rigidbody rigidbody = GetComponent<Rigidbody>();

			if(rigidbody)
			{
				Vector3 speed = rigidbody.velocity;
				speed.x = 4 * h;
				speed.z = 4 * v;
				rigidbody.velocity = speed;
				if (j)
				{
					rigidbody.AddForce(Vector3.up * 20);
				}
			}
		}		
	}

	void Stepping () 
	{
        //play sound of servo step
        legs.PlayOneShot(servoSteps[UnityEngine.Random.Range(0, servoSteps.Length)]);
        
	}
}
