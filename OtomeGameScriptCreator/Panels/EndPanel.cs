namespace OtomeGameScriptCreator.Panels
{
    public class EndPanel : Panel
    {
        public string nextChapter;

        public EndPanel(string text,
                  string nextFile,
                  int characterNumber,
                  string character,
                  string secondCharacter,
                  string expression,
                  string secondExpression,
                  string background)
        {
            mainText = text;
            this.characterNumber = characterNumber;
            this.character = character;
            this.secondCharacter = secondCharacter;
            this.expression = expression;
            this.secondExpression = secondExpression;
            this.background = background;
            nextChapter = nextFile;
            type = "end";
        }
    }
}
