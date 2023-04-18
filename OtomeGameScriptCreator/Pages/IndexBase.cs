using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OtomeGameScriptCreator.Panels;
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
}
