using UnityEngine;
using System.Collections;

public class RandomCurve : MonoBehaviour {

	public AnimationCurve WeightedCurve;
	public AnimationCurve AscendingCurve;

	public float GetRandom()
	{
		float x = Random.value;

		return WeightedCurve.Evaluate(x);
	}

	public float GetRandom(int seed)
	{
		System.Random rand = new System.Random(seed);

		float x = (float)rand.NextDouble();

		return WeightedCurve.Evaluate(x);
	}

	public float GetAscending(float num)
	{
		return AscendingCurve.Evaluate(num);
	}

	public float GetAscending(int min, int max)
	{
		float num = (float)min / (float)max;

		return AscendingCurve.Evaluate(num);
	}
}
