using UnityEngine;
using System.Collections;

[System.Serializable]  // Serializa os valores desta classe para que estes possam ser manipulados direto no Inspector
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;


    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)   // check from left to right
        {
            nextFire = Time.time + fireRate;   //reset the nextFire
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);  //instantiate the the Bolt
        }
    }

    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Rigidbody rbPlayer = GetComponent<Rigidbody>();  // fiz o cache do componente que sera usado repetidas vezes
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rbPlayer.velocity = movement * speed;
		
		rbPlayer.position = new Vector3  // faz o clamp - limita a nave numa certa area
			(
				Mathf.Clamp (rbPlayer.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rbPlayer.position.z, boundary.zMin, boundary.zMax)
			);
		
		rbPlayer.rotation = Quaternion.Euler (0.0f, 0.0f, rbPlayer.velocity.x * -tilt);  // calcula o tilt
	}
}