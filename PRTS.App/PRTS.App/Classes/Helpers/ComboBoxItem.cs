namespace PRTS.App.Classes.Helpers {
    public class ComboBoxItem {
        public string name;
        public string value;

        public ComboBoxItem(string name, string value) {
            this.name = name;
            this.value = value;
        }

        public override string ToString() {
            return name;
        }
    }
}
