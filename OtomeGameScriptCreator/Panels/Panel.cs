namespace OtomeGameScriptCreator.Panels
{
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
        public string background { get; set; }
        public string type { get; set; }
    }
}
