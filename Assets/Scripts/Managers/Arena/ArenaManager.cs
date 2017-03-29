using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaManager : MonoBehaviour {

	public List<BattleGladiator> TeamOne = new List<BattleGladiator>();
	public List<BattleGladiator> TeamTwo = new List<BattleGladiator>();

	public List<BattleGladiator> ReadyGladiators = new List<BattleGladiator>();

	public BattleDirector battleDirector;
	public Director director;

	public enum BattleState
	{
		SELECT,
		PRE_BATTLE,
		BATTLE,
		POST_BATTLE
	};

	public BattleState state = BattleState.SELECT;

	float NextTurnTime = 0;

	public struct BattleAction
	{
		public string Action;
		public float Score;
	}

	// Use this for initialization
	void Start () 
	{
		director.onComplete += OnDirectorComplete;
	}

	public void SelectGladiator(Gladiator g)
	{
		TeamOne[0].Init(g);
		TeamTwo[0].Init();

		director.play();
		state = BattleState.PRE_BATTLE;
	}

	void OnDirectorComplete()
	{
		if(state == BattleState.PRE_BATTLE)
		{
			NextTurnTime = Time.time;
			state = BattleState.BATTLE;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(state == BattleState.BATTLE)
			BattleTick();
		else if(state == BattleState.POST_BATTLE)
			PostBattleTick();

	}

	void BattleTick()
	{
		if(Time.time < NextTurnTime)
		{
			return;
		}

		if(ReadyGladiators.Count > 0)
			OnTurnBegin();
		else
			TurnTick();
	}

	void PostBattleTick()
	{
		if(Time.time > NextTurnTime)
		{
			//List<Gladiator> glads = 

			/*
			Gladiator g = Player.Instance.Gladiators.Find(x => TeamOne[0].GetGladiator() == x);

			int e = g.Stats.CurrentHealth;

			g.Stats.CurrentHealth = TeamOne[0].GetGladiator().Stats.CurrentHealth;

			Debug.Log("1 " + e + " 2 " + g.Stats.CurrentHealth);
			*/
			Debug.Log("Game over man");
			NextTurnTime += 1000;

		}
	}

	void TurnTick()
	{
		int i;
		for(i = 0; i < TeamOne.Count; i++)
			if(TeamOne[i].ChargeTurnMeter())
				ReadyGladiators.Add(TeamOne[i]);

		for(i = 0; i < TeamTwo.Count; i++)
			if(TeamTwo[i].ChargeTurnMeter())
				ReadyGladiators.Add(TeamTwo[i]);

		NextTurnTime += 0.5f;
		//Debug.Log("No Turn, Charging");
	}

	void OnTurnBegin()
	{
		BattleGladiator glad = ReadyGladiators[0];

		BattleGladiator.BattleAction action;
		float attackScore;
		glad.TakeAction(out action, out attackScore);

		if(!glad.HasTarget())
		{
			SetTargets();
		}

		ResolveAttack(glad, attackScore, glad.GetTarget());

		ReadyGladiators.Remove(glad);

	}

	void SetTargets()
	{
		int i;
		for(i = 0; i < TeamOne.Count; i++)
			if(!TeamOne[i].HasTarget())
				TeamOne[i].SetTarget(TeamTwo[0]);

		for(i = 0; i < TeamTwo.Count; i++)
			if(!TeamTwo[i].HasTarget())
				TeamTwo[i].SetTarget(TeamOne[0]);
	}

	//Resolutions
	void ResolveAttack(BattleGladiator attacker, float AttackScore, BattleGladiator defender)
	{
		BattleGladiator.BattleAction action;
		float defendScore;

		defender.TakeDefensiveAction(out action, out defendScore);

		if(AttackScore > defendScore)
		{		

			int damage = attacker.stats.GetStats().Strength/2;

			if(defender.TakeDamage(damage))
			{
				defender.GetComponent<SpriteRenderer>().enabled = false;
				state = BattleState.POST_BATTLE;
				NextTurnTime += 3;
			}
			else
			{
				battleDirector.FlashColor(defender.GetComponent<SpriteRenderer>(), Color.red, 0.8f);
				//Debug.Log(defender.Name + " Takes a hit for " + damage + " damage!");
			}
		}
		else
		{
			battleDirector.FlashColor(defender.GetComponent<SpriteRenderer>(), Color.white, 0.8f);

			//Debug.Log(defender.Name + " Blocks it");
		}

		NextTurnTime += 2.0f;
	}
}

