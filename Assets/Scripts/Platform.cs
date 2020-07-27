using UnityEngine;

public class Platform : MonoBehaviour {
    private PlatformEffector2D effector2D;
    public float waitTimeBeforeActive;
    private float waitTime;

    void Start() {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            waitTime = waitTimeBeforeActive;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (waitTime <= 0) {
                effector2D.rotationalOffset = 180f;
                waitTime = waitTimeBeforeActive;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Jump")) {
            effector2D.rotationalOffset = 0f;
        }
    }
}
