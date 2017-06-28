using UnityEngine;

public class RandomMusic2D : MonoBehaviour {

    string[] musicNames = { "2DMusic1", "2DMusic2" };

    void Start () {

        float random = Random.Range(0f, 1.99f);

        SoundManager.GetInstance().LoadComplexAudio(GetComponent<ComplexAudio>(), musicNames[(int)random], true);

	}
}
