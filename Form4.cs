using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTrainer
{
    public partial class Form4 : Form
    {
        private int numWords = 0;
        private int PresentNum = 0;
        private Form2 parent = null;
        private string PresentCorrectWord = string.Empty;
        private bool Switch = false;

        private Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            { "event", "подія" }, { "suburb", "передмістя" }, { "crown", "корона" }, { "jewels", "коштовності" }, { "cathedral", "собор" }, { "magnificent", "чудовий" }, { "district", "район"}, { "exchange", "обмін"}, { "flats", "квартири (не apartments)"}, { "hall", "зал, коридор"}, { "concrete", "бетон"}, {"headquarters", "штаб"}, {"department", "відділ"}, {"court", "суд"}, {"institution", "установа"}, {"hope", "надія"}, {"fuel", "пальне"}, {"roof", "дах"}, { "contains", "містить"}, {"interfered", "заважав"}, {"merchant", "купець"}, {"ordinary", "звичайний"}, {"situated", "розташований"}, {"former", "колишній (не ex)"}, {"vast", "величезний (не huge)"}, {"hell", "пекло"}, {"residential", "житловий"}, {"attractions", "пам'ятки"}, {"handful", "жменька"}, {"shore", "берег (не bank)"}, {"inhabit", "населяти"}, {"nuclear", "ядерний"}, {"mate", "товариш"}, {"sick", "хворий (не ill)"}, {"dust", "пил"}, {"steam", "пар"}, {"tool", "інструмент"}, {"revolve", "обертатися"}, {"fission", "розщеплення"}, {"apart", "окремо (не separate)"}, {"released", "звільнений"}, {"explosion", "вибух"}, {"petrol", "бензин"}, {"chain", "ланцюг"}, {"rod", "стрижень"}, {"otherwise", "інакше"}, {"raise", "підняти"}, {"absorb", "поглинати"}, {"advantage", "перевага"}, {"fusion", "злиття (не merge)"}, {"waste", "відходи"}, {"diseases", "хвороби"}, {"comb", "гребінець"}, {"knob", "ручка (не handle)"}, {"limitless", "безмежний"}, {"raw", "сирий"}, {"durable", "міцний"}, {"manufactured", "виготовлені"}, {"pregnant", "вагітна"}, {"benefit", "користь"}, {"observed", "спостерігається"}, {"respectively", "відповідно"}, {"origin", "походження"}, {"besides", "крім того"}, {"research", "дослідження"}, {"supply", "постачання"}, {"election", "вибори"}, {"inner", "внутрішній"}, {"moderate", "помірний"}, {"tribe", "плем'я"}, {"settlers", "переселенці"}, {"servant", "слуга"}, {"copper", "мідь"}, {"wheat", "пшениця"}, {"discovery", "відкриття"}, {"freedom", "свобода"}, {"equality", "рівність"}, {"fascinating", "захоплюючий"}, {"pattern", "візерунок"}, {"dwarf", "карлик"}, {"expand", "поширити (не spread)"}, {"collapses", "руйнується"}, {"pour", "наливати"}, {"prevent", "запобігти"}, {"cell", "клітина"}, {"pluck", "зривати"}, {"seed", "насіння"}, {"shelf", "полиця"}, {"oven", "піч"}, {"powder", "порошок"}, {"flavour", "аромат"}, {"brewed", "заварений"}, {"soak", "замочити"}, {"poverty", "бідність"}, {"invention", "винахід"}, {"loan", "кредит"}, {"stock", "запас"}, {"borrow", "позичати"}, {"deal", "справа"}, {"promise", "обіцянка"}, {"stretch", "розтягуватись"}, {"grassland", "пасовища"}, {"invader", "загарбник"}, {"peasant", "селянин"},  {"brick", "цегла"}, {"valley", "долина"}, {"landscape", "пейзаж"}, {"sediment", "осад"}, {"soil", "грунт"}, {"temple", "храм"}, {"crop", "урожай"}, {"ditch", "канава"}, {"artificial", "штучні"}, {"fertile", "родючі"}, {"award", "премія"}, {"achieve", "досягти"}, {"receive", "отримати (не get)"}, {"violence", "насильство"}, {"union", "спілка, союз"}, {"honor", "честь"}, {"noblemen", "дворян"}, {"wealth", "багатство"}, {"exploration", "розвідка"}, {"endure", "терпіти"}, {"journey", "подорож"}, {"silk", "шовк"}, {"valuable", "цінний"}, {"priest", "священик"}, {"prosper", "процвітати (не flourish)"}, {"scholar", "вчений (не scientist)"}, {"instead", "замість цього"}, {"wool", "шерсть"}, {"guild", "гільдія"}, {"duke", "герцог"}, {"betray", "зрадити"}, {"shepherd", "пастух"}, {"flock", "зграя"}, {"alarm", "тривога (не anxiety)"}, {"effort", "зусилля"}, {"quote", "цитата"}, {"glossy", "глянцевий"}, {"surpass", "перевершити (не outdo)"}, {"forgive", "пробачити"}, {"plight", "важке становище (не difficult situation)"}, {"gnaw", "гризти"}, {"rope", "мотузка"}, {"merry", "веселий" }, {"puddle", "калюжа"}, {"persuade", "переконувати"}, {"guess", "вгадати"}, {"bruise", "синяк"}, {"notify", "повідомити"}, {"replace", "замінити"}, {"unique", "унікальний"}, {"justify", "виправдати"}, {"intrusion", "вторгнення"}, {"opportunity", "можливість"}, {"necessary", "необхідно"}, {"bride", "наречена"}, {"groom", "наречений"}, {"aisle", "прохід"}, {"catch", "виловити"}, {"couple", "пара"}, {"reception", "прийом"}, {"camel", "верблюд"}, {"unit", "одиниця"}, {"current", "поточний"}, {"equipment", "обладнання"}, {"infant", "немовля"}, {"shift", "зміна"}, {"optional", "необов'язковий"}, {"bend", "згинати"}, {"confirm", "підтвердити"}, {"impress", "справити враження"}, {"hide", "приховати"}, {"advance", "заздалегідь"}, {"choose", "вибирати"}, {"cling", "чіплятися, липнути"}, {"dig", "копати"}, {"youth", "молодість"}, {"general", "загальний"}, {"offer", "пропозиція"}, {"activity", "діяльність"}, {"compulsory", "обов'язковий"}, {"feed", "годувати"}, {"fling", "кидати"}, {"forecast", "прогнозувати, передбачити (не foresee)"}, {"freeze", "замерзати"}, {"outstanding", "видатний"}, {"sudden", "раптовий"}, {"railway", "залізниця"}, {"degree", "ступінь"}, {"wish", "бажання"}, {"serve", "служити"}, {"sail", "вітрило"}, {"adult", "дорослий"}, {"hang", "вішати, висіти"}, {"response", "відповідь"}, {"issue", "проблема"}, {"attend", "відвідувати"}, {"recycle", "переробляти"}, {"tin", "олово"}
        };

        private List<string> EnglishWords = new List<string>();
        public Form4(int numWords, Form2 parent)
        {
            InitializeComponent();
            Word.BackColor = Color.White;
            progressBar.BackColor = Color.White;
            this.numWords = numWords > dict.Count ? dict.Count : numWords;
            this.parent = parent;
            foreach (var el in dict.Keys)
            {
                EnglishWords.Add(el);
            }
            progressBar.Maximum = this.numWords * 100;
        }
        private void back_Click(object sender, EventArgs e)
        {
            Close();
            parent.Show();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (PresentNum < numWords)
            {
                Answer.Text = string.Empty;
                Word.BackColor = Color.White;
                Random rand = new Random();
                int wordNum = rand.Next(0, EnglishWords.Count);
                PresentCorrectWord = EnglishWords[wordNum];
                Word.Text = dict[PresentCorrectWord];
                EnglishWords.Remove(PresentCorrectWord);
                PresentNum++;
                Switch = true;
            }
            else
                Word.Text = "You have already translated all the words";
        }

        private void CheckAnswer_Click(object sender, EventArgs e)
        {
            if (Answer.Text != null && Switch)
            {
                string answer = Answer.Text.ToLower().Trim();
                if (answer == PresentCorrectWord)
                {
                    Word.Text = "its correct";
                    Word.BackColor = Color.LightGreen;
                    for (int i = 0; i < 100; i++)
                        ++progressBar.Value;
                    Switch = false;
                }
                else if (CompareStr(PresentCorrectWord, answer) != string.Empty)
                {
                    Word.Text = $"Maybe you meant {PresentCorrectWord}?";
                    Word.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    Word.Text = $"its wrong, correct answer - {PresentCorrectWord})";
                    Word.BackColor = Color.OrangeRed;
                    Switch = false;
                }
            }
        }
        private static string CompareStr(string wordInDict, string word)
        {
            string result = string.Empty;
            int longest_sub_sequence = 0;
            var sub_string = new int[word.Length, wordInDict.Length];
            for (int j = 0; j < word.Length; j++)
            {
                for (int k = 0; k < wordInDict.Length; k++)
                {
                    if (wordInDict[k] == word[j] && j != 0 && k != 0)
                        sub_string[j, k] = sub_string[j - 1, k - 1] + 1;
                    else if (wordInDict[k] == word[j] && (j == 0 || k == 0))
                        sub_string[j, k] = 1;
                    else if (wordInDict[k] != word[j] && j == 0 && k == 0)
                        sub_string[j, k] = 0;
                    else
                    {
                        if (j - 1 < 0)
                            sub_string[j, k] = sub_string[j, k - 1];
                        else if (k - 1 < 0)
                            sub_string[j, k] = sub_string[j - 1, k];
                        else
                            sub_string[j, k] = Math.Max(sub_string[j - 1, k], sub_string[j, k - 1]);
                    }
                }
            }
            foreach (var el in sub_string)
            {
                if (el > longest_sub_sequence)
                    longest_sub_sequence = el;
            }
            if (longest_sub_sequence >= wordInDict.Length - 1)
                result = wordInDict;
            return result;
        }
    }
}
