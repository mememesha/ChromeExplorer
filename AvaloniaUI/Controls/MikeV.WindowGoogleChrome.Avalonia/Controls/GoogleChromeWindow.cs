
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using System;
using System.Windows.Input;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace MikeV.WindowGoogleChrome.Avalonia
{
    public class GoogleChromeWindow:Window,IStyleable
    {
        #region Private Fields

        private const string TitleBarGrid = "TitleBarGrid";

        private Grid? _titleBar;

        #endregion

        #region  IStyleable

        Type IStyleable.StyleKey => typeof(GoogleChromeWindow);

        #endregion

        #region Dependency Properties

        public static StyledProperty<object> ToolBarContentProperty = AvaloniaProperty.Register<GoogleChromeWindow, object>(nameof(ToolBarContent));

        public static readonly StyledProperty<ICommand> CloseCommandProperty = AvaloniaProperty.Register<GoogleChromeWindow,ICommand>(
            nameof(CloseCommand));

        public static readonly StyledProperty<ICommand> ExpandCommandProperty = AvaloniaProperty.Register<GoogleChromeWindow, ICommand>(
            nameof(ExpandCommand));

        public static readonly StyledProperty<ICommand> CollapseCommandProperty = AvaloniaProperty.Register<GoogleChromeWindow, ICommand>(
            nameof(CollapseCommand));

        #endregion

        #region Public Properties
        public object ToolBarContent
        {
            get => GetValue(ToolBarContentProperty);
            set => SetValue(ToolBarContentProperty, value);
        }
        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public ICommand ExpandCommand
        {
            get => (ICommand)GetValue(ExpandCommandProperty);
            set => SetValue(ExpandCommandProperty, value);
        }

        public ICommand CollapseCommand
        {
            get => (ICommand)GetValue(CollapseCommandProperty);
            set => SetValue(CollapseCommandProperty, value);
        }

        #endregion

        #region Constructor

        public GoogleChromeWindow()
        {
            CloseCommand = new DelegateCommand(OnClose);
            CollapseCommand = new DelegateCommand(OnCollapse);
            ExpandCommand = new DelegateCommand(OnExpand);

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            TransparencyLevelHint = WindowTransparencyLevel.AcrylicBlur;
        }

        #endregion

        #region Private Methods
        private void OnClose(object param)
        {
            Close();
        }
        private void OnExpand(object param)
        {
            WindowState = WindowState switch
            {
                WindowState.Maximized => WindowState.Normal,
                WindowState.Normal => WindowState.Maximized,
                _ => WindowState
            };
        }
        private void OnCollapse(object param)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Protected Methods
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _titleBar = e.NameScope.Get<Grid>(TitleBarGrid);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            if (Equals(e.Source, _titleBar))
            {
                BeginMoveDrag(e);
            }
        }

        #endregion

    }
}
