using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace OtomeGameScriptCreator.Pages
{
    public class IndexBase: ComponentBase
    {
        public string panelType = "text";
		public int characterNumber = 1;
		public string currentCharacter = "necromancer";
		public string currentSecondCharacter = "necromancer";

		public string currentExpression = "neutral";
		public string currentSecondExpression = "neutral";

		public string currentMainText = "";
		public int currentNextPanel = 1;
		public string? currentNextChapter = "default";
		public int currentPanel = 0;
		public string[] choiceTexts = new string[3];
		public string[] choicePersons = new string[3];
		public int[] choiceNextPanels = new int[3];
		public int[] choicePoints = new int[3];

		public string fileName = "name";

		public List<Panel> panels = new List<Panel>();

		public void AddTextPanel()
		{
			var newPanel = new TextPanel(currentMainText,
								currentNextPanel,
								characterNumber,
								currentCharacter,
								currentSecondCharacter,
								currentExpression,
								currentSecondExpression);
			newPanel.panelNumber = currentPanel;
			currentPanel++;
			panels.Add(newPanel);
			currentNextPanel = currentPanel + 1;
			currentMainText = "";
		}

		public void AddChoicePanel()
		{
			var newPanel = new ChoicePanel(currentMainText,
								  characterNumber,
								  currentCharacter,
								  currentSecondCharacter,
								  currentExpression,
								  currentSecondExpression,
								  choiceTexts[0],
								  choiceNextPanels[0],
								  choicePersons[0],
								  choicePoints[0],
								  choiceTexts[1],
								  choiceNextPanels[1],
								  choicePersons[1],
								  choicePoints[1],
								  choiceTexts[2],
								  choiceNextPanels[2],
								  choicePersons[2],
								  choicePoints[2]);
			newPanel.panelNumber = currentPanel;
			currentPanel++;
			panels.Add(newPanel);
			currentMainText = "";
			currentNextPanel = currentPanel + 1;
		}

		public void AddEndPanel()
		{
			var newPanel = new EndPanel(currentMainText,
							   currentNextChapter,
							   characterNumber,
							   currentCharacter,
							   currentSecondCharacter,
							   currentExpression,
							   currentSecondExpression);
			newPanel.panelNumber = currentPanel;
			currentPanel++;
			panels.Add(newPanel);
			currentMainText = "";
			currentNextPanel = currentPanel + 1;
		}

		public async void LoadFiles(InputFileChangeEventArgs e)
		{
			var stream = e.File.OpenReadStream();
			var result = new byte[stream.Length];
			await stream.ReadAsync(result, 0, (int)stream.Length);
			var text = System.Text.Encoding.ASCII.GetString(result);
            panels = JsonConvert.DeserializeObject<List<Panel>>(text, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
			currentPanel = panels.Count;
			currentNextPanel = panels.Count + 1;
			await InvokeAsync(() =>
			{
				StateHasChanged();
			});
		}
	}
    
    public class Panel 
	{
		public int panelNumber { get; set; }
		public string? mainText { get; set; }
		public int nextPanel { get; set; }
		public int characterNumber { get; set; }
		public string character { get; set; }
		public string secondCharacter { get; set; }
		public string expression { get; set; }
		public string secondExpression { get; set; }
		public string type { get; set; }
	}

    public class TextPanel : Panel
    {

		public TextPanel(string text,
				   int nextPanel,
				   int characterNumber,
				   string character,
				   string secondCharacter,
				   string expression,
				   string secondExpression)
		{
			this.mainText = text;
			this.nextPanel = nextPanel;
			this.characterNumber = characterNumber;
			this.character = character;
			this.secondCharacter = secondCharacter;
			this.expression = expression;
			this.secondExpression = secondExpression;
			this.type = "text";
		}
	}

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
			this.type = "choice";
		}
	}

	public class EndPanel : Panel
	{
		public string nextChapter;

		public EndPanel(string text,
				  string nextFile,
				  int characterNumber,
				  string character,
				  string secondCharacter,
				  string expression,
				  string secondExpression)
		{
			this.mainText = text;
			this.characterNumber = characterNumber;
			this.character = character;
			this.secondCharacter = secondCharacter;
			this.expression = expression;
			this.secondExpression = secondExpression; 
			this.nextChapter = nextFile;
			this.type = "end";
		}
	}
}
