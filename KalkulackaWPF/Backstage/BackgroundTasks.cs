namespace KalkulackaWPF
{
    public class BackgroundTasks
    {
        public bool dec { get; set; }
        public string directPad { get; set; }
        public string indirectPad { get; set; }

        public void CheckBlocksInitiate(string directPadParam, string indirectPadParam)
        {
            directPad = directPadParam;
            indirectPad = directPadParam;
            new Logger(2, "Code", string.Format("A CheckBlocksInitiate has appeared with current pad values {0} and {1}. Passing to CheckBlocks()",
                directPadParam, indirectPadParam));
            CheckBlocks();
        }
        public void CheckBlocks()
        {
            if (this.directPad.Contains("."))
            {
                dec = true;
            }
            else if (!directPad.Contains("."))
            {
                dec = false;
            }
            if (dec) {
                First.Calc.decButton.IsEnabled = false;
            }
            else if (!dec)
            {
                First.Calc.IsEnabled = true;
            }
        }
    }
}
