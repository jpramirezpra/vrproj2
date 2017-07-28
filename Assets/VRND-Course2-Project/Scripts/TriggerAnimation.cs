using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {
    public string AnimationName;
    public Animator stateMachine;

    private bool created = false;
    private GvrViewer viewer;

    void Start() {
        viewer = (GvrViewer)FindObjectOfType(typeof(GvrViewer));

        if (viewer == null)
        {
            Debug.LogError("No GvrViewer found. Please drag the GvrViewerMain prefab into the scene.");
            return;
        }

        if (viewer != null) {
            foreach (Camera c in GvrViewer.Instance.GetComponentsInChildren<Camera>()) {
                //c.enabled = false; // to use the Gvr SDK without adding cameras we have to disable them
            }
        }

    }

    void Update() {

        if (viewer == null)
        {
            return;
        }

        if (viewer.Triggered)
        {
            if (stateMachine.GetBool(AnimationName))
            {
                stateMachine.SetBool(AnimationName, false);
            } else
            {
                stateMachine.SetBool(AnimationName, true);
            }
        }
            
    }

}