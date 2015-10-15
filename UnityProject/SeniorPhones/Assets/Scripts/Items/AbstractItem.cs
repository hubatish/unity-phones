using UnityEngine;
using System.Collections;

public abstract class AbstractItem : MonoBehaviour {

    public string id;

    public abstract void Use(Vector3 vector);


}
