using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputmapping : MonoBehaviour
{
    public float speed ;
    public float rotationSpeed ;

    public float collisionDistance ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float depthInput = Input.GetAxis("Jump");
        float rotationInput = Input.GetAxis("Mouse X");

        Vector3 movement = new Vector3(horizontalInput, depthInput, verticalInput) * speed * Time.deltaTime;
        Vector3 rotation = new Vector3(0, rotationInput, 0) * rotationSpeed * Time.deltaTime;
        transform.Translate(movement);
        transform.Rotate(rotation);

         Vector3 desiredPosition = transform.position + transform.forward * Input.GetAxis("Vertical") +
                                  transform.right * Input.GetAxis("Horizontal") +
                                  transform.up * Input.GetAxis("Jump");

        // Liste des directions à vérifier
        Vector3[] directions = { transform.forward, -transform.forward, transform.right, -transform.right, transform.up, -transform.up };

        foreach (Vector3 direction in directions)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, collisionDistance))
            {
                // Si un rayon heurte un obstacle, ajuste la position de la caméra
                desiredPosition = hit.point - direction * collisionDistance;
            }
        }

        transform.position = desiredPosition;
    }

}
