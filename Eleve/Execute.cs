using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Eleve.Log;

namespace Eleve
{
    /// <summary>
    /// 引数を一つだけ持つメソッドに対応したCallMethodActionです。
    /// </summary>
    public class Execute : TriggerAction<DependencyObject>
    {
        /// <summary></summary>
        private IActionCommand _commandCache;
        /// <summary>
        /// 
        /// </summary>
        public Execute()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public Execute(string action)
        {
            Action = action;
        }
        /// <summary>
        /// メソッドを呼び出すオブジェクトを指定、または取得します。
        /// </summary>
        public ViewModelBase ViewModel
        {
            get { return (ViewModelBase)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ViewModelBase), typeof(Execute), new PropertyMetadata(null));
        /// <summary>
        /// Action をキャッシュする
        /// </summary>
        public bool   Cache  { get; set; }
        /// <summary>
        /// 呼び出すアクション名を指定、または取得します。
        /// 1 タグ 1 アクション想定としてひとまず依存関係にはしないでおく
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 呼び出すメソッドに渡す引数を指定、または取得します。
        /// </summary>
        public object ActionParameter
        {
            get { return GetValue(ActionParameterProperty); }
            set { SetValue(ActionParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MethodParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionParameterProperty =
            DependencyProperty.Register("MethodParameter", typeof(object), typeof(Execute), new PropertyMetadata(null, OnActionParameterChanged));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnActionParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var thisReference = (Execute)sender;
            thisReference.ActionParameter = e.NewValue;
        }
        /// <summary>
        /// 
        /// </summary>
        private LogLevel _LogLevel = LogLevel.Info;
        public LogLevel LogLevel
        {
            get { return _LogLevel; }
            set { _LogLevel = value; }
        }
        /// <summary>
        /// 隠しコマンド
        /// </summary>
        /// <param name="parameter"></param>
        public void __Invoke__(object parameter)
        {
            Invoke(parameter);
        }
        /// <summary>
        /// 隠しコマンド
        /// </summary>
        /// <param name="parameter"></param>
        public async Task<ActionResult> __InvokeAsync__(object parameter)
        {
            ActionResult ret = await InvokeAsync(parameter);
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Invoke(object parameter)
        {
            InvokeAsync(parameter).ContinueWith(v =>
            {
                if (v.Status == TaskStatus.Faulted)
                {
                    Exception ex = v.Exception.InnerException;
                    // todo
                    MessageBox.Show(ex.Message);
                    return;
                }

                switch (v.Result.Status)
                {
                    case ActionStatus.ViewModelNotFound:
                    case ActionStatus.ActionNotFound:
                        MessageBox.Show(v.Result.Message);
                        break;
                    default:
                        break;
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        private async Task<ActionResult> InvokeAsync(object parameter)
        {
            var total = Stopwatch.StartNew();
            // 対象コマンドの生成
            IActionCommand command = null;
            if (Cache && _commandCache != null)
            {
                command = _commandCache;
            }
            else
            {
                var vm = AssociateWithViewModel();
                if (vm == null)
                {
                    return new ActionResult(ActionStatus.ViewModelNotFound) { Message = "ViewModel not found." };
                }

                string clazz = BuildClassName(vm);
                command = NewCommand(vm, clazz);
                // コマンドがなかった場合は何もしない
                if (command == null)
                {
                    return new ActionResult(ActionStatus.ActionNotFound) { Message = clazz + " not found." };
                }
            }

            // キャッシュ対象の場合
            if (Cache)
            {
                _commandCache = command;
            }

            // 実行
            var atime = Stopwatch.StartNew();
            // Action 呼び出し
            try
            {
                ActionResult result = await command.Execute(AssociatedObject, parameter as EventArgs, ActionParameter);
                return result;
            }
            finally
            {
                atime.Stop();
                total.Stop();
                Logger.Log(LogLevel, "Execute > {0} - {1}/{2}", command, atime.Elapsed.TotalMilliseconds, total.Elapsed.TotalMilliseconds);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ViewModelBase AssociateWithViewModel()
        {
            // セットされていない場合は Window から取る
            if (ViewModel == null && AssociatedObject != null)
            {
                Window window = Window.GetWindow(AssociatedObject);
                if (window != null)
                {
                    ViewModel = window.DataContext as ViewModelBase;
                }
            }

            return ViewModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string BuildClassName(ViewModelBase vm)
        {
            // 呼び出し対象のクラス名を生成
            Type   vmType = vm.GetType();
            string dir    = vmType.Name.Replace("ViewModel", "");
            string name   = vmType.FullName;
            string clazz  = string.Format("{0}Actions.{1}.{2}", name.Substring(0, name.IndexOf("ViewModels")), dir, Action);

            return clazz;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IActionCommand NewCommand(ViewModelBase vm, string clazz)
        {
            // アセンブリを取得
            Assembly asm = Assembly.GetAssembly(vm.GetType());
            // アクションクラスを取得
            Type type = asm.GetType(clazz);
            if (type == null)
            {
                return null;
            }
            // インスタンス生成
            IActionCommand action = Activator.CreateInstance(type) as IActionCommand;
            // 初期化
            action.Initialize(vm);

            return action;
        }
    }
}
