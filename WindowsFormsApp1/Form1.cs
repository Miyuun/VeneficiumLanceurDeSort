using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        CharacterSheet character_1 = null;
        CharacterSheet character_2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void am2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void will2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void am1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void will1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void bonus1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void bonus2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void roll1_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_1.Name != ""
                && character_1.MagicPower > 0
                && character_1.WillPower > 0
                && Int32.TryParse(am1.Text, out magic)
                && Int32.TryParse(will1.Text, out will)
                && Int32.TryParse(bonusam1.Text, out bonusam)
                && Int32.TryParse(bonuswill1.Text, out bonuswill)
                && Int32.TryParse(bonusampercent1.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent1.Text, out bonuswillpercent))
            {
                if ((string)comboboxam1.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill1.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent1.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent1.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                character_1.MagicPower = magic;
                character_1.WillPower = will;
                Spell spell = character_1.RollSpell(bonusam, bonusampercent, bonuswill, bonuswillpercent);
                power1.Text = spell.Power.ToString();
                accuracy1.Text = spell.Accuracy.ToString();
                rollresult.Visible = true;
                rollresult.Text = character_1.MakeSentenceSpell(spell, -1);
            }
            else
            {
                MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private void roll2_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_2.Name != ""
                && character_2.MagicPower > 0
                && character_2.WillPower > 0
                && Int32.TryParse(am2.Text, out magic)
                && Int32.TryParse(will2.Text, out will)
                && Int32.TryParse(bonusam2.Text, out bonusam)
                && Int32.TryParse(bonuswill2.Text, out bonuswill)
                && Int32.TryParse(bonusampercent2.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent2.Text, out bonuswillpercent))
            {

                if ((string)comboboxam2.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill2.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent2.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent2.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                character_2.MagicPower = magic;
                character_2.WillPower = will;
                Spell spell = character_2.RollSpell(bonusam, bonusampercent, bonuswill, bonuswillpercent);
                power2.Text = spell.Power.ToString();
                accuracy2.Text = spell.Accuracy.ToString();
                rollresult.Visible = true;
                rollresult.Text = character_2.MakeSentenceSpell(spell, -1);
            }
            else
            {
                MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private void protego1_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_1.Name != ""
                && character_1.MagicPower > 0
                && character_1.WillPower > 0
                && Int32.TryParse(am1.Text, out magic)
                && Int32.TryParse(will1.Text, out will)
                && Int32.TryParse(bonusam1.Text, out bonusam)
                && Int32.TryParse(bonuswill1.Text, out bonuswill)
                && Int32.TryParse(bonusampercent1.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent1.Text, out bonuswillpercent))
            {
                if ((string)comboboxam1.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill1.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent1.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent1.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                character_1.MagicPower = magic;
                character_1.WillPower = will;
                character_1.RollProtego(bonusam, bonusampercent);
                rollresult.Visible = true;
                if(protegoPoint1.Text != 0.ToString())
                {
                    if (MessageBox.Show(
                "Voulez-vous remplacer le Protego actuellement érigé ?",
                "Remplacer le Protego",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        protegoPoint1.Text = character_1.ProtegoActive.Power.ToString();
                        if (character_1.ProtegoActive.CritLevel > 0)
                            rollresult.Text = "Le Protego érigé par " + character_1.Name + " est actif et possède " + character_1.ProtegoActive.Power + " PV." + (character_1.ProtegoActive.CritLevel == 2 ? " (critique)" : null);
                        else
                            rollresult.Text = "Le Protego érigé par " + character_1.Name + " est un échec critique.";
                    }
                }
                else
                {
                    if (character_1.ProtegoActive.CritLevel > 0)
                        rollresult.Text = "Le Protego érigé par " + character_1.Name + " est actif et possède " + character_1.ProtegoActive.Power + " PV." + (character_1.ProtegoActive.CritLevel == 2 ? " (critique)" : null);
                    else
                        rollresult.Text = "Le Protego érigé par " + character_1.Name + " est un échec critique.";
                    protegoPoint1.Text = character_1.ProtegoActive.Power.ToString();
                }
                if (protegoPoint1.Text != 0.ToString())
                    attackprotego2.Enabled = true;
                else
                    attackprotego2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private void protego2_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_2.Name != ""
                && character_2.MagicPower > 0
                && character_2.WillPower > 0
                && Int32.TryParse(am2.Text, out magic)
                && Int32.TryParse(will2.Text, out will)
                && Int32.TryParse(bonusam2.Text, out bonusam)
                && Int32.TryParse(bonuswill2.Text, out bonuswill)
                && Int32.TryParse(bonusampercent2.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent2.Text, out bonuswillpercent))
            {
                if ((string)comboboxam2.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill2.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent2.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent2.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                Console.WriteLine(bonusam);
                Console.WriteLine(bonusampercent);

                character_2.MagicPower = magic;
                character_2.WillPower = will;
                character_2.RollProtego(bonusam, bonusampercent);
                rollresult.Visible = true;
                if (protegoPoint2.Text != 0.ToString())
                {
                    if (MessageBox.Show(
                "Voulez-vous remplacer le Protego actuellement érigé ?",
                "Remplacer le Protego",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        protegoPoint2.Text = character_2.ProtegoActive.Power.ToString();
                        if (character_2.ProtegoActive.CritLevel > 0)
                            rollresult.Text = "Le Protego érigé par " + character_2.Name + " est actif et possède " + character_2.ProtegoActive.Power + " PV." + (character_2.ProtegoActive.CritLevel == 2 ? " (critique)" : null);
                        else
                            rollresult.Text = "Le Protego érigé par " + character_2.Name + " est un échec critique.";
                    }
                }
                else
                {
                    if (character_2.ProtegoActive.CritLevel > 0)
                        rollresult.Text = "Le Protego érigé par " + character_2.Name + " est actif et possède " + character_2.ProtegoActive.Power + " PV." + (character_2.ProtegoActive.CritLevel == 2 ? " (critique)" : null);
                    else
                        rollresult.Text = "Le Protego érigé par " + character_2.Name + " est un échec critique.";
                    protegoPoint2.Text = character_2.ProtegoActive.Power.ToString();
                }
                if (protegoPoint2.Text != 0.ToString())
                    attackprotego1.Enabled = true;
                else
                    attackprotego1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private async void loadProfile2_ClickAsync(object sender, EventArgs e)
        {
            if (character2.Text != "")
            {
                loaded2.Visible = true;
                loaded2.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                loaded2.Text = "Loading...";
                character_2 = await Model.Model.requestAsync(character2.Text);
                loaded2.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                loaded2.Text = "Chargée !";
                character2.Text = character_2.Name;
                am2.Text = character_2.MagicPower.ToString();
                amlabel2.Visible = true;
                am2.Visible = true;
                will2.Text = character_2.WillPower.ToString();
                willlabel2.Visible = true;
                will2.Visible = true;
                roll2.Visible = true;
                bonusamlabel2.Visible = true;
                bonusam2.Text = "0";
                bonusam2.Visible = true;
                bonuswilllabel2.Visible = true;
                bonuswill2.Text = "0";
                bonuswill2.Visible = true;
                protego2.Visible = true;
                comboboxwillpercent2.SelectedItem = "Bonus";
                comboboxampercent2.SelectedItem = "Bonus";
                comboboxwill2.SelectedItem = "Bonus";
                comboboxam2.SelectedItem = "Bonus";
                comboboxwillpercent2.Visible = true;
                comboboxampercent2.Visible = true;
                comboboxwill2.Visible = true;
                comboboxam2.Visible = true;
                bonusampercent2.Visible = true;
                bonusampercent2.Text = "0";
                bonuswillpercent2.Visible = true;
                bonuswillpercent2.Text = "0";
                protegoPoint2.Text = "0";
                bonusamlabelpercent2.Visible = true;
                bonuswilllabelpercent2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                protegoPoint2.Visible = true;
                pictureBox2.Visible = true;
                accuracy.Visible = true;
                accuracy2.Visible = true;
                power.Visible = true;
                power2.Visible = true;
                attackprotego2.Visible = true;
                modifyprotego2.Visible = true;
                removeprotego2.Visible = true;
                powerafterroll.Visible = true;
                powerafterprotego2.Visible = true;
            }
        }

        private async void loadProfile1_ClickAsync(object sender, EventArgs e)
        {
            if (character1.Text != "")
            {
                loaded1.Visible = true;
                loaded1.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                loaded1.Text = "Loading...";
                character_1 = await Model.Model.requestAsync(character1.Text);
                loaded1.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                loaded1.Text = "Chargée !";
                character1.Text = character_1.Name;
                am1.Text = character_1.MagicPower.ToString();
                amlabel1.Visible = true;
                am1.Visible = true;
                will1.Text = character_1.WillPower.ToString();
                willlabel1.Visible = true;
                will1.Visible = true;
                roll1.Visible = true;
                bonusamlabel1.Visible = true;
                bonusam1.Text = "0";
                bonusam1.Visible = true;
                bonuswilllabel1.Visible = true;
                bonuswill1.Text = "0";
                bonuswill1.Visible = true;
                protego1.Visible = true;
                comboboxwillpercent1.SelectedItem = "Bonus";
                comboboxampercent1.SelectedItem = "Bonus";
                comboboxwill1.SelectedItem = "Bonus";
                comboboxam1.SelectedItem = "Bonus";
                comboboxwillpercent1.Visible = true;
                comboboxampercent1.Visible = true;
                comboboxwill1.Visible = true;
                comboboxam1.Visible = true;
                bonusampercent1.Visible = true;
                bonusampercent1.Text = "0";
                bonuswillpercent1.Visible = true;
                bonuswillpercent1.Text = "0";
                protegoPoint1.Text = "0";
                bonusamlabelpercent1.Visible = true;
                bonuswilllabelpercent1.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                protegoPoint1.Visible = true;
                pictureBox3.Visible = true;
                accuracy.Visible = true;
                accuracy1.Visible = true;
                power.Visible = true;
                power1.Visible = true;
                attackprotego1.Visible = true;
                modifyprotego1.Visible = true;
                removeprotego1.Visible = true;
                powerafterroll.Visible = true;
                powerafterprotego1.Visible = true;
            }
        }

        private void modifyprotego1_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Quelle est la nouvelle valeur du Protego ?", "Modifier Protego", protegoPoint1.Text, -1, -1);
            if (Int32.TryParse(input, out int result))
                protegoPoint1.Text = result.ToString();
            if (protegoPoint1.Text != 0.ToString())
                attackprotego2.Enabled = true;
            else
                attackprotego2.Enabled = false;
        }

        private void modifyprotego2_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Quelle est la nouvelle valeur du Protego ?", "Modifier Protego", protegoPoint2.Text, -1, -1);
            if (Int32.TryParse(input, out int result))
                protegoPoint2.Text = result.ToString();
            if (protegoPoint2.Text != 0.ToString())
                attackprotego1.Enabled = true;
            else
                attackprotego1.Enabled = false;
        }

        private void attackprotego1_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_1.Name != ""
                && character_1.MagicPower > 0
                && character_1.WillPower > 0
                && Int32.TryParse(am1.Text, out magic)
                && Int32.TryParse(will1.Text, out will)
                && Int32.TryParse(bonusam1.Text, out bonusam)
                && Int32.TryParse(bonuswill1.Text, out bonuswill)
                && Int32.TryParse(bonusampercent1.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent1.Text, out bonuswillpercent)
                && protegoPoint2.Text != 0.ToString())
            {
                if ((string)comboboxam1.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill1.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent1.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent1.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                character_1.MagicPower = magic;
                character_1.WillPower = will;
                Spell spell = character_1.RollSpell(bonusam, bonusampercent,  bonuswill, bonuswillpercent);
                power1.Text = spell.Power.ToString();
                accuracy1.Text = spell.Accuracy.ToString();
                rollresult.Visible = true;
                int protegoresult = -1;
                if (spell.PowerLevel > 1 && spell.AccuracyLevel)
                {
                    protegoresult = character_1.AttackProtego(spell, character_2);
                    protegoPoint2.Text = character_2.ProtegoActive.Power.ToString();
                }
                powerafterprotego1.Text = spell.Power.ToString();
                rollresult.Text = character_1.MakeSentenceSpell(spell, protegoresult);
                if (protegoPoint2.Text != 0.ToString())
                    attackprotego1.Enabled = true;
                else
                    attackprotego1.Enabled = false;
            }
            else
            {
                if(protegoPoint2.Text == 0.ToString())
                    MessageBox.Show("Le Protego adverse n'est pas érigé.");
                else
                    MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private void attackprotego2_Click(object sender, EventArgs e)
        {
            int magic;
            int will;
            int bonusam;
            int bonuswill;
            int bonusampercent;
            int bonuswillpercent;
            if (character_2.Name != ""
                && character_2.MagicPower > 0
                && character_2.WillPower > 0
                && Int32.TryParse(am2.Text, out magic)
                && Int32.TryParse(will2.Text, out will)
                && Int32.TryParse(bonusam2.Text, out bonusam)
                && Int32.TryParse(bonuswill2.Text, out bonuswill)
                && Int32.TryParse(bonusampercent2.Text, out bonusampercent)
                && Int32.TryParse(bonuswillpercent2.Text, out bonuswillpercent)
                && protegoPoint1.Text != 0.ToString())
            {
                if ((string)comboboxam2.SelectedItem == "Malus")
                    bonusam *= -1;
                if ((string)comboboxwill2.SelectedItem == "Malus")
                    bonuswill *= -1;
                if ((string)comboboxampercent2.SelectedItem == "Malus")
                    bonusampercent *= -1;
                if ((string)comboboxwillpercent2.SelectedItem == "Malus")
                    bonuswillpercent *= -1;

                character_2.MagicPower = magic;
                character_2.WillPower = will;
                Spell spell = character_2.RollSpell(bonusam, bonusampercent, bonuswill, bonuswillpercent);
                power2.Text = spell.Power.ToString();
                accuracy2.Text = spell.Accuracy.ToString();
                rollresult.Visible = true;
                int protegoresult = -1;
                if (spell.PowerLevel > 1 && spell.AccuracyLevel)
                {
                    protegoresult = character_2.AttackProtego(spell, character_1);
                    protegoPoint1.Text = character_1.ProtegoActive.Power.ToString();
                }
                powerafterprotego2.Text = spell.Power.ToString();
                rollresult.Text = character_2.MakeSentenceSpell(spell, protegoresult);
                if (protegoPoint1.Text != 0.ToString())
                    attackprotego2.Enabled = true;
                else
                    attackprotego2.Enabled = false;
            }
            else
            {
                if (protegoPoint1.Text == 0.ToString())
                    MessageBox.Show("Le Protego adverse n'est pas érigé.");
                else
                    MessageBox.Show("Le personnage n'a pas été trouvé ou les informations sont incorrectes. Vérifiez-les, SVP. (l'AM et la Volonté ne peuvent pas être égales à 0)");
            }
        }

        private void removeprotego1_Click(object sender, EventArgs e)
        {
            protegoPoint1.Text = 0.ToString();
            if (protegoPoint1.Text != 0.ToString())
                attackprotego2.Enabled = true;
            else
                attackprotego2.Enabled = false;
        }

        private void removeprotego2_Click(object sender, EventArgs e)
        {
            protegoPoint2.Text = 0.ToString();
            if (protegoPoint2.Text != 0.ToString())
                attackprotego1.Enabled = true;
            else
                attackprotego1.Enabled = false;
        }
    }
}
