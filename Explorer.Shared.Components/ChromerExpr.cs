
namespace Explorer.Shared.Components
{
    /// <summary>
    /// Основное приложение проводника
    /// </summary>
    public class ChromerExpr
    {
        #region Singelton

        private static ChromerExpr _instance;
        public static ChromerExpr Instance => _instance ?? new ChromerExpr();

        #endregion

        #region Public Properties

        /// <summary>
        /// Менеджер иконок
        /// </summary>
        public IIconsManager IconsManager { get; }

        #endregion
        
        #region Constructor

        public ChromerExpr()
        {
            IconsManager = new IconsManedger(new ExtentionToImageFileConverter());
        }

        #endregion
    }
}
