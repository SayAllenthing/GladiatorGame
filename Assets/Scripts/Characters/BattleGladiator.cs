using UnityEngine;
using System.Collections;

public class BattleGladiator : MonoBehaviour 
{
	public BattleReportPanel Panel;

	public GladiatorStats stats;

	int ChargeTime = 0;

	BattleGladiator Target;

	Gladiator gladiator;

	public enum BattleStatus
	{
		HEALTHY,
		INJURED,
		INCAPACITATED
	}

	BattleStatus Status;

	float AvgScore = 0;
	int Turns = 0;

	public enum BattleAction
	{
		ATTACK,
		BLOCK
	}

	public string Name = "";

	// Use this for initialization
	void Start () 
	{
		Status = BattleStatus.HEALTHY;
	}
	
	public void Init(Gladiator glad = null)
	{
		if(glad != null)
		{
			gladiator = glad;
		}
		else
		{			
			gladiator = new Gladiator();
			gladiator.Init();
		}

		stats = gladiator.Stats;

		float height = (float)stats.GetRawHeight()/200f;
		float weight = (float)stats.GetRawWeight()/300f;

		float dir = transform.localScale.x > 0 ? 1 : -1;
		transform.localScale = new Vector3((0.9f + weight) * dir, 0.9f + height, 1);
		GetComponent<SpriteRenderer>().color = DataManager.Instance.SkinColours[stats.SkinColour];

		Name = stats.Name;

		Panel.Init(gladiator);
	}

	public bool ChargeTurnMeter()
	{
		int critRange = (90 - stats.GetStats().Willpower/2);
		bool crit = Random.Range(0,100) >= critRange;

		int charge = 5 + stats.GetStats().Quickness/2;

		ChargeTime += crit ? charge * 2 : charge;

		if(ChargeTime >= 50)
			return true;

		return false;
	}

	public void TakeAction(out BattleAction action, out float score)
	{
		action = BattleAction.ATTACK;
		score = GetAttackScore();

		//After turn
		int critRange = (90 - stats.GetStats().Willpower);
		bool crit = Random.Range(0,100) >= critRange;

		ChargeTime = crit ? 25 : 0;
	}

	public void TakeDefensiveAction(out BattleAction action, out float score)
	{
		action = BattleAction.BLOCK;
		score = GetDefendScore();
	}

	public bool TakeDamage(int damage)
	{
		//Check half damage
		int tou = gladiator.BaseStats.Toughness;
		int will = gladiator.BaseStats.Willpower;

		int critRange = (90 - will/2);
		bool crit = Random.Range(0,100) >= critRange;

		critRange = (90 - tou - (crit ? tou : 0));
		crit = Random.Range(0,100) >= critRange;

		if(crit)
		{
			Debug.Log("Toughness Block");
			damage/= 2;
		}

		stats.CurrentHealth -= damage;

		Panel.SetHP(stats.CurrentHealth);

		return stats.CurrentHealth <= 0;
	}

	float GetAttackScore()
	{
		int str = gladiator.BaseStats.Strength;
		int will = gladiator.BaseStats.Willpower;

		int critRange = (90 - will/2);
		bool crit = Random.Range(0,100) >= critRange;

		int score =  Random.Range(0,10) + str + (crit ? 10 : 0);

		Panel.SetTurns(++Turns);
		SetScore(score);

		return score;
	}

	float GetDefendScore()
	{
		int tou = gladiator.BaseStats.Toughness;
		int will = gladiator.BaseStats.Willpower;

		int critRange = (90 - will/2);
		bool crit = Random.Range(0,100) >= critRange;

		int score =  Random.Range(0,10) + tou + (crit ? 10 : 0);

		SetScore(score);

		return score;
	}

	public bool HasTarget()
	{
		if(Target == null)
			return false;

		if(Target.Status != BattleStatus.HEALTHY)
			return false;

		return true;
	}

	public Gladiator GetGladiator()
	{
		return gladiator;
	}

	public BattleGladiator GetTarget()
	{
		return Target;
	}

	public void SetTarget(BattleGladiator t)
	{
		Target = t;
	}

	void SetScore(int score)
	{
		float newScore = Panel.SetScore(AvgScore, (float)score);

		AvgScore = newScore;
	}
}
