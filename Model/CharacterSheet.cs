using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CharacterSheet
    {

        public string Name { get; set; }
        public int MagicPower { get; set; }
        public int WillPower { get; set; }
        public Protego ProtegoActive { get; set; }

        public CharacterSheet(string name, int magicPower, int willPower)
        {
            Name = name;
            MagicPower = magicPower;
            WillPower = willPower;
        }

        public Spell RollSpell(int bonusam, int bonusampercent, int bonuswill, int bonuswillpercent)
        {
            Random rand = new Random();
            int randNumber = rand.Next(1, 100);
            int randSpell = (randNumber + WillPower + bonuswill) + (randNumber + WillPower + bonuswill) * bonuswillpercent/ 100;
            int powerLevel = 0;
            if(Model.isBadCrit(randNumber, WillPower))
            {
                 powerLevel = 0;
            }
            else
            if(randSpell >= 50)
            {
                if (Model.isCrit(randNumber, WillPower))
                {
                    powerLevel = 3;
                }
                else
                {
                    powerLevel = 2;
                }
            }
            else
            {
                powerLevel = 1;
            }

            randNumber = rand.Next(1, 100);
            int randAccuracy = (randNumber + MagicPower + bonusam) + (randNumber + MagicPower + bonusam) * bonusampercent  / 100;
            bool accuracyLevel = false;
            if (randAccuracy >= 50)
            {
                accuracyLevel = true;
            }
            else
            {
                accuracyLevel = false;
            }

            return new Spell(randAccuracy, randSpell, accuracyLevel, powerLevel);
        }

        public string MakeSentenceSpell(Spell spell, int resultProtego)
        {
            string sentence = Name ;
            if (spell.PowerLevel == 0)
            {
                sentence += " rate (critique) son sort.";
            }
            else if(spell.PowerLevel == 1)
            {
                sentence += " rate son sort.";
            }
            else if (spell.PowerLevel == 2)
            {
                sentence += " réussit son sort ";
                if (spell.AccuracyLevel)
                {
                    sentence += "et touche sa cible.";
                    if (resultProtego == 2)
                        sentence += " Cependant, le Protego adverse renvoie le sort.";
                    else if (resultProtego == 1)
                        sentence += " Cependant, le Protego adverse absorbe le sort.";
                    else if (resultProtego ==  0)
                        sentence += " Le Protego adverse se brise.";
                }
                else
                {
                    sentence += "mais rate sa cible.";
                }
            }
            else if (spell.PowerLevel == 3)
            {
                sentence += " réussit (critique) son sort ";
                if (spell.AccuracyLevel)
                {
                    sentence += "et touche sa cible.";
                    if (resultProtego == 2)
                        sentence += " Cependant, le Protego adverse renvoie le sort.";
                    else if (resultProtego == 1)
                        sentence += " Cependant, le Protego adverse absorbe le sort.";
                    else if (resultProtego == 0)
                        sentence += " Le Protego adverse se brise.";
                }
                else
                {
                    sentence += "mais rate sa cible.";
                }

            }
            return sentence;
        }

        public int AttackProtego(Spell spell, CharacterSheet character)
        {
            if (spell.Accuracy > character.ProtegoActive.Power)
            {
                spell.Power -= character.ProtegoActive.Power / 2;
                character.ProtegoActive.Power = 0;
                return 0;
            }
            else
            {
                if ((character.ProtegoActive.Power - 70) >= spell.Accuracy && character.ProtegoActive.CritLevel < 2)
                {
                    character.ProtegoActive.Power -= spell.Accuracy / 2;
                    spell.Power = 0;
                    return 2;
                }
                else
                {
                    character.ProtegoActive.Power -= spell.Accuracy / 2;
                    spell.Power = 0;
                    return 1;
                }
            }
        }

        public void RollProtego(int bonus, int bonuspercent)
        {
            Random rand = new Random();
            int randNumber = rand.Next(1, 100);
            Console.WriteLine(bonuspercent);
            int randProtego = (randNumber + MagicPower + bonus) + (randNumber + MagicPower + bonus) * bonuspercent / 100;
            if (Model.isCrit(randNumber, WillPower))
                ProtegoActive = new Protego(randProtego*2, 2);
            else if (Model.isBadCrit(randNumber, WillPower))
                ProtegoActive = new Protego(0, 0);
            else
                ProtegoActive = new Protego(randProtego, 1);
        }
    }

    public class Spell
    {
        int accuracy;
        int power;
        bool accuracyLevel;
        int powerLevel;


        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Power { get => power; set => power = value; }
        public bool AccuracyLevel { get => accuracyLevel; set => accuracyLevel = value; }
        public int PowerLevel { get => powerLevel; set => powerLevel = value; }

        public Spell(int accuracy, int power, bool accuracyLevel, int powerLevel)
        {
            Accuracy = accuracy;
            Power = power;
            AccuracyLevel = accuracyLevel;
            PowerLevel = powerLevel;
        }
    }

    public class Protego
    {
        int power;
        int critLevel;

        public int Power { get => power; set => power = value; }
        public int CritLevel { get => critLevel; set => critLevel = value; }

        public Protego(int power, int critLevel)
        {
            Power = power;
            CritLevel = critLevel;
        }
    }
}
