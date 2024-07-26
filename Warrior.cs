using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Warrior
    {
        private Random _decisionPicker;

        private string _name;
        private string _gender;
        private int _health;
        private int _maxHealth;
        private int _totalHPDeducted = 0;
        private int _totalHPAdded = 0;
        private List<string> _skills;
        private List<string> _defense;
        private List<string> _winningMessages;
        private List<string> _lostInGameMessages;

        private List<string> _defaultSkills = new()
        {
            "Passive Attack",
            "Normal Attack",
            "Magic Attack",
            "Ranged Attack",
            "Special Attack",
            "Combo Attack",
            "Area of Effect Attack",
            "Poison Attack",
            "Sneak Attack",
            "Elemental Attack",
            "Heavy attack"
        };

        private List<string> _defaultDefense = new()
        {
            "Passive Defense",
            "Normal Defense",
            "Dodge",
            "Counter",
            "Magic Shield",
            "Evasion",
            "Reflect",
            "Absorption",
            "Barrier",
            "Fortify",
            "Ultimate Shield"
        };

        private List<string> _defaultWinningMessages = new()
        {
            "My blade sings with the joy of victory!",
            "The crowd roars, and I stand victorious!",
            "Skill triumphs over luck once again!",
            "Another foe falls before my might!",
            "A worthy adversary, but not worthy enough.",
            "Remember this defeat—it will fuel your growth.",
            "Victory dances in my veins!",
            "Good game, my friend. Victory is sweet.",
            "You fought valiantly, but I am the champion!",
            "Haha! Keep practicing until you beat me!"
        };

        private List<string> _defaultLostInGameMessages = new()
        {
            "I fought with all my heart, but it wasn’t enough.",
            "Defeat stings, but I’ll come back stronger.",
            "My best wasn’t good enough this time.",
            "The battlefield was unforgiving.",
            "I’ll train harder for our next encounter.",
            "Mommy, this one was really tough!",
            "I gave it my all, but fate had other plans.",
            "The taste of defeat is bitter.",
            "Back to the drawing board.",
            "I’ll learn from this and rise again."
        };

        public Warrior(Random decisionPicker, string name, string gender, int health, List<string>? skills = null, List<string>? defense = null, List<string>? winningMessages = null, List<string>? lostInGameMessages = null)
        {
            _name = name;
            _gender = gender;
            _health = health;
            _maxHealth = health;

            skills ??= new();
            defense ??= new();
            winningMessages ??= new();
            lostInGameMessages ??= new();

            _skills = skills.Count == 0 ? _defaultSkills : skills;
            _defense = defense.Count == 0 ? _defaultDefense : defense;

            _winningMessages = winningMessages.Count == 0 ? _defaultWinningMessages : winningMessages;
            _lostInGameMessages = lostInGameMessages.Count == 0 ? _defaultLostInGameMessages : lostInGameMessages;

            _decisionPicker = decisionPicker;
        }

        public Warrior RestoreHP(string winningPlayer)
        {
            _name = winningPlayer;
            _health = _maxHealth;

            return this;
        }

        public string GetWinningMessage()
        {
            return _winningMessages[_decisionPicker.Next(_winningMessages.Count)];
        }

        public string GetLostInGameMessage()
        {
            return _lostInGameMessages[_decisionPicker.Next(_lostInGameMessages.Count)];
        }

        public string GetWarriorName()
        {
            return _name;
        }

        public string GetWarriorGender()
        {
            return _gender.ToLower();
        }

        public int GetMaxHealth() 
        {
            return _maxHealth;
        }

        public int GetHealth()
        {
            return _health;
        }

        public string GetSkillUse(int skillLevel)
        {
            return _skills[skillLevel];
        }

        public string GetDefenseUse(int defenseLevel)
        {
            return _defense[defenseLevel];
        }

        public void HealthRecovery(int heal)
        {
            _health += heal;
            _totalHPAdded = heal;
        }

        public void DamageTaken(int hit)
        {
            _health -= hit;
            _totalHPDeducted =  hit;

            if (_health < 0) _health = 0; 
        }

        public string GetHPUpdate()
        {
            string status = "";

            if (_totalHPDeducted > 0) status = $"(- {_totalHPDeducted})";
            if (_totalHPAdded > 0) status = $"(+ {_totalHPAdded})";

            _totalHPAdded = 0;
            _totalHPDeducted = 0;

            return status;
        }

        public bool Alive()
        {
            return _health > 0;
        }

        public int Attack()
        {
            return _decisionPicker.Next(_skills.Count);
        }

        public int Defend()
        {
            return _decisionPicker.Next(_defense.Count);
        }
    }
}
