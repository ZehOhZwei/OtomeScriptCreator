﻿namespace OtomeGameScriptCreator.Panels
{
    public class TextPanel : Panel
    {

        public TextPanel(string text,
                   int nextPanel,
                   int characterNumber,
                   string character,
                   string secondCharacter,
                   string expression,
                   string secondExpression,
                   string background)
        {
            mainText = text;
            this.nextPanel = nextPanel;
            this.characterNumber = characterNumber;
            this.character = character;
            this.secondCharacter = secondCharacter;
            this.expression = expression;
            this.secondExpression = secondExpression;
            this.background = background;
            type = "text";
        }
    }
}
