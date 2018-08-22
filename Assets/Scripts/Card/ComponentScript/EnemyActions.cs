using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyActions {

    public List<Action> actions;
    private System.Random random;
    private Action nextAction;

    // @TODO: maybe consider using the automatic constructor? how would that work?
    public EnemyActions(EnemyActions enemyActions) {
        actions = enemyActions.actions;
        random = new System.Random();
        nextAction = GetAction();
    }

    public void PerformAction()
    {
        switch (nextAction.action)
        {
            case ComponentType.Armor:
                {
                    EnemyStats.enemyStatsInstance.Armor(nextAction.modifier);
                    break;
                }
            case ComponentType.Attack:
                {
                    PlayerStats.playerStatsInstance.Damage(nextAction.modifier + EnemyStats.enemyStatsInstance.baseAttack);
                    Debug.Log("Enemy Attacked");
                    break;
                }
            case ComponentType.Heal:
                {
                    EnemyStats.enemyStatsInstance.Heal(nextAction.modifier);
                    break;
                }
            case ComponentType.Buff:
                {
                    EnemyStats.enemyStatsInstance.baseAttack += nextAction.modifier;
                    Debug.Log("Enemy buffed");
                    break;
                }
            case ComponentType.Debuff:
                {
                    Debug.Log("Not implemented");
                    break;
                }
        }
        nextAction = GetAction();
    }

    public Action GetNextAction()
    {
        return nextAction;
    }

    private Action GetAction()
    {
        Action ret = actions[random.Next(actions.Count)];
        Debug.Log("Next action is " + ret.explanation);
        return ret;
    }
        
}

[System.Serializable]
public class Action
{
    public string explanation;
    public ComponentType action;
    public int modifier;
}