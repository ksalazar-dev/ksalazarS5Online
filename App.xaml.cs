namespace ksalazarS5Online
{
    public partial class App : Application
    {
        public static Utils.personaRepo personaRepository  { get; set; }

 
        public App(Utils.personaRepo personaRepo)
        {
            InitializeComponent();
            personaRepository = personaRepo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vpersona()); // Ejecuta nueva vista
        }
    }
}