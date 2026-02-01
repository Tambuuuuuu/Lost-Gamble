using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
public abstract class ClassDado : MonoBehaviour
{
    protected Rigidbody body;
    public bool lanzando;
    

    [SerializeField] private float maxRandomforcevalue = 200, rollingforce = 300;
    private float forceX, forceY, forceZ;
    public int dicefacenum;
    [SerializeField] private List<Transform> colliders;
    [SerializeField] private List<Transform> fakeColliders;
    //protected DiceDuelSoundManager sound;
    protected virtual void Awake()
    {
        Iniciar();
        //sound = FindObjectOfType<DiceDuelSoundManager>();
    }

    protected void ObtenerColliders(string tagPj, string number1, string number2, string number3, string tagCara)
    {
        colliders = new List<Transform>();
        fakeColliders = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag(tagPj))
            {
                if (child.name == number1)
                {
                    colliders.Add(child);
                }

                if (child.name == number2)
                {
                    colliders.Add(child);
                }

                if (child.name == number3)
                {
                    colliders.Add(child);
                }
            }
            else if (child.CompareTag(tagCara))
            {
                fakeColliders.Add(child);
            }
        }
    }
    public virtual void ActivarTruco()
    {
        CambiarColliders(true);
    }

    protected virtual void DesactivarTruco()
    {
        CambiarColliders(false);
    }
    protected void CambiarColliders(bool activarFake)
    {
        foreach (Transform collider in colliders)
        {
            collider.gameObject.SetActive(!activarFake);
        }
        foreach (Transform fakeCollider in fakeColliders)
        {
            fakeCollider.gameObject.SetActive(activarFake);
        }
    }

    public virtual void LanzarDado()
    {
        lanzando = true;
        
        body.isKinematic = false;

        forceX = Random.Range(0, maxRandomforcevalue);
        forceY = Random.Range(0, maxRandomforcevalue);
        forceZ = Random.Range(0, maxRandomforcevalue);

        body.AddForce(Vector3.up * rollingforce);
        body.AddTorque(forceX, forceY, forceZ);

        StartCoroutine(FinalizarLanzamiento());
    }

    protected virtual IEnumerator FinalizarLanzamiento()
    {
        yield return new WaitForSeconds(4f);

        lanzando = false;
    }

    public virtual void ReiniciarDado()
    {
        lanzando = false;
        body.isKinematic = true;
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        transform.position = new Vector3(7.09f, 3.96f, -2.387f);
        lanzando = false;
        dicefacenum = 0;
        DesactivarTruco();
    }

    protected virtual void Iniciar()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        ReiniciarDado();
    }
}