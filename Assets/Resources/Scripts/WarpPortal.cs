using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WarpPortal : MonoBehaviour {

    public SceneField scene;
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag.Equals("Player")) {

            SceneManager.LoadScene(scene, LoadSceneMode.Single);

        }


    }

}
