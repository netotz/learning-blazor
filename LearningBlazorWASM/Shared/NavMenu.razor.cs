namespace LearningBlazorWASM.Shared {
    public partial class NavMenu {
        
        private bool CollapseNavMenu { get; set; } = true;

        public string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

        public void ToggleNavMenu() {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
