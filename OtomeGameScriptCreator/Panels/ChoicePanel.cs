namespace OtomeGameScriptCreator.Panels
{
    public class ChoicePanel : Panel
    {
        public string choiceText1;
        public int choice1NextPanel;
        public string choice1AffectedPerson;
        public int choice1Points;
        public string choiceText2;
        public int choice2NextPanel;
        public string choice2AffectedPerson;
        public int choice2Points;
        public string choiceText3;
        public int choice3NextPanel;
        public string choice3AffectedPerson;
        public int choice3Points;

        public ChoicePanel(string mainText,
                     int characterNumber,
                     string character,
                     string secondCharacter,
                     string expression,
                     string secondExpression,
                     string background,
                     string choiceText1,
                     int choice1NextPanel,
                     string choice1AffectedPerson,
                     int choice1Points,
                     string choiceText2,
                     int choice2NextPanel,
                     string choice2AffectedPerson,
                     int choice2Points,
                     string choiceText3,
                     int choice3NextPanel,
                     string choice3AffectedPerson,
                     int choice3Points)
        {
            this.mainText = mainText;
            this.characterNumber = characterNumber;
            this.character = character;
            this.secondCharacter = secondCharacter;
            this.expression = expression;
            this.secondExpression = secondExpression;
            this.background = background;
            this.choiceText1 = choiceText1;
            this.choice1NextPanel = choice1NextPanel;
            this.choice1AffectedPerson = choice1AffectedPerson;
            this.choice1Points = choice1Points;
            this.choiceText2 = choiceText2;
            this.choice2NextPanel = choice2NextPanel;
            this.choice2AffectedPerson = choice2AffectedPerson;
            this.choice2Points = choice2Points;
            this.choiceText3 = choiceText3;
            this.choice3NextPanel = choice3NextPanel;
            this.choice3AffectedPerson = choice3AffectedPerson;
            this.choice3Points = choice3Points;
            type = "choice";
        }
    }
}
