using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WarpPortal : MonoBehaviour {

    public SceneField scene;

    void onTriggerEnter(Collider other) {

        Debug.Log(other);

        if (other.gameObject.tag.Equals("Player")) {

            if (scene != null) {
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }else {
                Debug.LogError("No Scene to Load!");
            }

        }


    }
        
}
