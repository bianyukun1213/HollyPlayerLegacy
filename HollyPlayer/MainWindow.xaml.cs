using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Un4seen.Bass;

namespace HollyPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 源码丢失之前的代码。
        //DispatcherTimer timer = new DispatcherTimer();//Timer。
        //WindowInteropHelper wih;//获取句柄相关。
        //double pos;//歌曲当前播放位置。
        //double length;//歌曲总长度
        //bool tempSliderStop = false;//临时的，当歌曲暂停，进度条被拖到最后时为true。
        //const int intVer = 2016111802;
        //const string hpVersion = "1.0.0.5";
        //ResourceDictionary rd = new ResourceDictionary();
        //public MainWindow()
        //{
        //    InitializeComponent();
        //    File.Delete(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "newhp.exe");
        //    BassNet.Registration("bianyukun1213@outlook.com", "2X1129102524822");//Bass音频库授权注册。
        //    wih = new WindowInteropHelper(this);//获取句柄相关。
        //    if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, wih.Handle))//初始化Bass音频库。
        //    {
        //        MessageBox.Show(":( 非常抱歉，Bass音频库初始化失败！作者连假酒都没来得及喝！\n没什么卵用的错误代码：" + Bass.BASS_ErrorGetCode().ToString(), "冬青音乐播放器");
        //    }
        //    Bass.BASS_PluginLoadDirectory(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);//加载Bass插件。
        //    label1.Content = BassNet.InternalName;//显示Bass版本。
        //    timer.Interval = new TimeSpan(0, 0, 1);//设置Timer间隔为1秒。
        //    timer.Tick += new EventHandler(timer_Tick);
        //    slider1.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(slider1_MouseLeftButtonUp), true);//注册进度条鼠标左键按下事件。
        //    slider1.AddHandler(Slider.MouseLeftButtonDownEvent, new MouseButtonEventHandler(slider1_MouseLeftButtonDown), true);//注册进度条鼠标左键抬起事件。
        //    listBox.SelectionMode = SelectionMode.Extended;
        //}

        //private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)//释放资源，退出程序。
        //{
        //    Bass.BASS_Stop();
        //    Bass.BASS_Free();
        //}

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        //    ofd.Multiselect = true;
        //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        for (int i = 0; i < ofd.FileNames.Length; i++)
        //        {
        //            Player.files.Add(ofd.FileNames[i]);
        //            listBox.Items.Add(ofd.FileNames[i]);
        //        }
        //        if (Player.isStreamAdded)
        //        {
        //            Player.PlayListRefresh();
        //        }
        //        button1.IsEnabled = true;
        //    }
        //}

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        Bass.BASS_Stop();
        //        Bass.BASS_Start();
        //    }
        //    if (listBox.SelectedIndex == -1)//判断listBox是否无选中项。
        //    {
        //        if (Player.playMode != 2)//listBox无选中项且播放器不在随机播放模式下，选中listBox第一项。
        //        {
        //            listBox.SelectedIndex = 0;
        //        }
        //        else//listBox无选中项且播放器在随机播放模式下，随机选中listBox。
        //        {
        //            Random r = new Random();
        //            listBox.SelectedIndex = r.Next(Player.files.Count);
        //        }
        //    }
        //    Player.Play(Player.files, listBox.SelectedIndex);
        //    button5.IsEnabled = true;
        //    button6.IsEnabled = true;
        //    button7.IsEnabled = false;
        //    button8.IsEnabled = true;
        //    timer.Start();
        //}

        //private void button2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)//这段代码可以让播放模式在文件播放期间即时生效，下同。-1用于在CreatePlayModeZero中区分。
        //    {
        //        Player.PlayModeZero(-1);
        //    }
        //    Player.playMode = 0;
        //    label2.Content = "当前播放模式：列表循环";
        //}

        //private void button3_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        Player.PlayModeOne();
        //    }
        //    Player.playMode = 1;
        //    label2.Content = "当前播放模式：单曲循环";
        //}

        //private void button4_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        Player.PlayModeTwo(-1);
        //    }
        //    Player.playMode = 2;
        //    label2.Content = "当前播放模式：随机播放";
        //}

        //private void button5_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        Player.PlayLast();
        //    }
        //    button6.IsEnabled = true;
        //    button7.IsEnabled = false;
        //    timer.Start();
        //}

        //private void button6_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        if (Player.tempStream != 0)
        //        {
        //            Bass.BASS_ChannelPause(Player.tempStream);
        //        }
        //        else
        //        {
        //            Bass.BASS_ChannelPause(Player.streams[Player.playListSelected]);
        //        }
        //        button6.IsEnabled = false;
        //        button7.IsEnabled = true;
        //        timer.Stop();
        //    }
        //}

        //private void button7_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        if (tempSliderStop)//如果tempSliderStop为true，直接播放下一首。
        //        {
        //            Player.PlayNext();
        //        }
        //        else
        //        {
        //            if (Player.tempStream != 0)
        //            {
        //                Bass.BASS_ChannelPlay(Player.tempStream, false);
        //            }
        //            else
        //            {
        //                Bass.BASS_ChannelPlay(Player.streams[Player.playListSelected], false);
        //            }
        //        }
        //        button6.IsEnabled = true;
        //        button7.IsEnabled = false;
        //        timer.Start();
        //    }
        //}

        //private void button8_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        Player.PlayNext();
        //    }
        //    button6.IsEnabled = true;
        //    button7.IsEnabled = false;
        //    timer.Start();
        //}

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        if (Player.tempStream != 0)
        //        {
        //            label.Content = "当前播放：" + Player.tempName;
        //            pos = (int)Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Bass.BASS_ChannelGetPosition(Player.tempStream));
        //            length = (int)Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Bass.BASS_ChannelGetLength(Player.tempStream));
        //            label3.Content = pos + "/" + length;
        //        }
        //        else
        //        {
        //            label.Content = "当前播放：" + Player.playList[Player.playListSelected];
        //            pos = (int)Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Bass.BASS_ChannelGetPosition(Player.streams[Player.playListSelected]));
        //            length = (int)Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
        //            label3.Content = pos + "/" + length;
        //        }
        //        slider1.Value = pos / length * 10;
        //    }
        //}

        //private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, (int)(slider.Value * 1000));
        //}

        //private void slider1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        if (Player.tempStream != 0)
        //        {
        //            Bass.BASS_ChannelPause(Player.tempStream);
        //        }
        //        else
        //        {
        //            Bass.BASS_ChannelPause(Player.streams[Player.playListSelected]);
        //        }
        //        timer.Stop();
        //    }
        //}

        //private void slider1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (Player.isStreamAdded)
        //    {
        //        if (slider1.Value == 10)//当进度条被拖到最右边时。
        //        {
        //            if (button6.IsEnabled == true && button7.IsEnabled == false)//如果当前正在播放歌曲，直接切换下一首。如果当前歌曲暂停，tempSliderStop为true。
        //            {
        //                Player.PlayNext();
        //            }
        //            else
        //            {
        //                tempSliderStop = true;
        //            }
        //        }
        //        else
        //        {
        //            if (Player.tempStream != 0)
        //            {
        //                length = Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Bass.BASS_ChannelGetLength(Player.tempStream));
        //                Bass.BASS_ChannelSetPosition(Player.tempStream, slider1.Value / 10 * length);
        //                if (!(button6.IsEnabled == false && button7.IsEnabled == true))
        //                {
        //                    Bass.BASS_ChannelPlay(Player.tempStream, false);
        //                }
        //            }
        //            else
        //            {
        //                length = Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
        //                Bass.BASS_ChannelSetPosition(Player.streams[Player.playListSelected], slider1.Value / 10 * length);
        //                if (!(button6.IsEnabled == false && button7.IsEnabled == true))
        //                {
        //                    Bass.BASS_ChannelPlay(Player.streams[Player.playListSelected], false);
        //                }
        //            }
        //        }
        //        if (tempSliderStop)//当进度条被拖到最右边时，不启用timer，但手动更新进度。
        //        {
        //            if (Player.tempStream != 0)
        //            {
        //                length = (int)Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Bass.BASS_ChannelGetLength(Player.tempStream));
        //                label3.Content = length + "/" + length;
        //            }
        //            else
        //            {
        //                length = (int)Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
        //                label3.Content = length + "/" + length;
        //            }
        //        }
        //        else
        //        {
        //            timer.Start();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("木有音乐播放，再怎么拖也没用啦。为什么还留着它呢？因为\n\n作\n\n者\n\n喝\n\n假\n\n酒\n\n了", "吼吼吼，这是一个很♂大♀的信息框");
        //    }
        //}

        //public static void Update(int intVer)//更新代码。
        //{
        //    WebClient updateWebClient = new WebClient();
        //    updateWebClient.Credentials = CredentialCache.DefaultCredentials;
        //    try
        //    {
        //        Byte[] pageData = updateWebClient.DownloadData("http://sagittarius1213.blog.163.com/blog/static/216470160201610304311180/");
        //        string pageHtml = Encoding.Default.GetString(pageData);
        //        int verHead = pageHtml.IndexOf("版本头");
        //        int verTail = pageHtml.IndexOf("版本尾");
        //        int newIntVer = Convert.ToInt32(pageHtml.Substring(verHead + 3, verTail - verHead - 3));
        //        int addressHead = pageHtml.IndexOf("地址头");
        //        int addressTail = pageHtml.IndexOf("地址尾");
        //        string address = pageHtml.Substring(addressHead + 3, addressTail - addressHead - 3);
        //        if (newIntVer > intVer)
        //        {
        //            if (MessageBox.Show("检测到新版本，是否立即安装？", "冬青音乐播放器", MessageBoxButton.YesNo).ToString() == "Yes")
        //            {
        //                Process.Start(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "hpupdater.exe", address);
        //            }
        //        }
        //        if (newIntVer < intVer)
        //        {
        //            if (MessageBox.Show("握了个草，新版本作者还没发布呢，你就拿到了，是不是有PY交易？", "冬青音乐播放器", MessageBoxButton.YesNo).ToString() == "Yes")
        //            {
        //                MessageBox.Show("老哥，稳！喝假酒的您都敢……","告诉作者注意身体");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("未发现新版本。", "冬青音乐播放器");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("由于各种奇怪的原因（比如作者喝了假酒），检查更新/更新失败了。", "冬青音乐播放器");
        //        //throw;
        //    }
        //}

        //private void button9_Click(object sender, RoutedEventArgs e)
        //{
        //    Update(intVer);
        //}

        //private void button11_Click(object sender, RoutedEventArgs e)
        //{

        //    if (listBox.SelectedItems.Count > 0)
        //    {
        //        object[] selected_objs = new object[listBox.SelectedItems.Count];//这段代码网上抄的，超级牛逼。创建一个Count大小的集合，
        //        listBox.SelectedItems.CopyTo(selected_objs, 0);//将选中项复制过去，
        //        foreach (object oval in selected_objs)//循环删除，这样能解决ListBox大小不断变化导致很难移除项目的问题。
        //        {
        //            listBox.Items.Remove(oval);
        //        }
        //        Player.files.Clear();
        //        if (listBox.Items.Count == 0)
        //        {
        //            button1.IsEnabled = false;
        //            button5.IsEnabled = false;
        //            button6.IsEnabled = false;
        //            button7.IsEnabled = false;
        //            button8.IsEnabled = false;
        //            Player.isStreamAdded = false;
        //            Bass.BASS_Stop();
        //            Bass.BASS_Start();
        //            timer.Stop();
        //            label.Content = "";
        //            label3.Content = "";
        //            slider1.Value = 0;
        //            Player.files.Clear();
        //            Player.playList.Clear();
        //            Player.streams.Clear();
        //            Player.playListSelected = 0;
        //            MessageBox.Show("用播放器也是要按照基本法的，这么玩很容易出bug的，江来bug上出现了偏差，等于你也是有泽任的，民白不民白？ ;)","喝假酒，说胡话：");
        //        }
        //        else
        //        {
        //            for (int i = 0; i < listBox.Items.Count; i++)
        //            {
        //                listBox.SelectedIndex = i;
        //                Player.files.Add(listBox.SelectedItem.ToString());
        //                //System.Diagnostics.Debug.WriteLine(listBox.SelectedItem.ToString());
        //            }
        //            listBox.UnselectAll();
        //            if (Player.isStreamAdded)
        //            {
        //                Player.PlayListRefresh();
        //            }
        //        }
        //        //Player.RemoveFromPlayList(listBox.Items.Count);
        //    }
        //}

        //private void button10_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("冬青音乐播放器 v" + hpVersion + "\n作者：不小心喝了假酒的bianyukun1213\n" + BassNet.InternalName, "冬青音乐播放器");
        //}

        //private void button12_Click(object sender, RoutedEventArgs e)
        //{
        //    /*rd.Source = new Uri(@"C:\Users\bianyukun1213\Downloads\wpf_themes\WPF_Themes\ShinyBlue.xaml");
        //    this.Resources = rd;*/
        //    System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        //    ofd.Filter = "WPF主题包 (*.xaml)|*.xaml";
        //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            rd.Source = new Uri(ofd.FileName);
        //            this.Resources = rd;
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("换肤失败，可能是文件类型不对，也可能是作者喝了假酒。","冬青音乐播放器");
        //            //throw;
        //        }
        //    }
        //}
        #endregion
        private DispatcherTimer timer = new DispatcherTimer();
        private ResourceDictionary rd = new ResourceDictionary();
        private Random color = new Random();
        private string line = "";
        private WindowInteropHelper wih;
        private double pos;
        private double length;
        private bool tempSliderStop;
        private const string hpVersion = "1.0.1.2";
        static Dictionary<string, string> dic = new Dictionary<string, string>();
        public MainWindow()
        {
            this.InitializeComponent();
            System.IO.File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "newhp.exe");
            BassNet.Registration("bianyukun1213@outlook.com", "2X1129102524822");
            this.wih = new WindowInteropHelper((Window)this);
            if (!Un4seen.Bass.Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, this.wih.Handle))
            {
                System.Windows.MessageBox.Show(":( 非常抱歉，Bass音频库初始化失败！\n错误代码：" + Un4seen.Bass.Bass.BASS_ErrorGetCode().ToString(), "冬青音乐播放器");
            }
            Un4seen.Bass.Bass.BASS_PluginLoadDirectory(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            //this.tb_Bass.Text = BassNet.InternalName;
            this.timer.Interval = new TimeSpan(0, 0, 0,0,10);//注意，这里本来的间隔设计成100毫秒（0.1秒一次），后来测试时发现有的歌词会无法显示（因为间隔较大，有时无法取到），故调小间隔以提高取词成功率。
            this.timer.Tick += new EventHandler(this.timer_Tick);
            this.sl_Pos.AddHandler(UIElement.MouseLeftButtonUpEvent, (Delegate)new MouseButtonEventHandler(this.sl_Pos_MouseLeftButtonUp), true);
            this.sl_Pos.AddHandler(UIElement.MouseLeftButtonDownEvent, (Delegate)new MouseButtonEventHandler(this.sl_Pos_MouseLeftButtonDown), true);
            this.tb_Egg.AddHandler(UIElement.MouseLeftButtonUpEvent, (Delegate)new MouseButtonEventHandler(this.tb_Egg_MouseLeftButtonUp), true);
            this.lb_List.SelectionMode = System.Windows.Controls.SelectionMode.Extended;
            if (System.IO.File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "list"))
            {
                StreamReader streamReader = new StreamReader(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "list");
                while ((this.line = streamReader.ReadLine()) != null)
                {
                    if (this.line.Substring(0, 1) == "+")
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(this.line.Remove(0, 1));
                        if (System.IO.File.Exists(stringBuilder.ToString()))
                        {
                            //Player.files.Add(stringBuilder.ToString());
                            //this.lb_List.Items.Add((object)stringBuilder.ToString());
                            try
                            {
                                dic.Add(stringBuilder.ToString().Substring(stringBuilder.ToString().LastIndexOf('\\') + 1), stringBuilder.ToString());
                                Player.files.Add(stringBuilder.ToString());
                                lb_List.Items.Add(stringBuilder.ToString().Substring(stringBuilder.ToString().LastIndexOf('\\') + 1));
                            }
                            catch (Exception)
                            {
                                System.Windows.MessageBox.Show("很抱歉，暂不支持添加重名文件！", "冬青音乐播放器");
                                continue;
                                //throw;
                            }
                        }
                        stringBuilder.Clear();
                    }
                }
            }
            if (this.lb_List.Items.Count != 0)
                this.btn_Play.IsEnabled = true;
            if (!System.IO.File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "settings"))
                return;
            StreamReader streamReader1 = new StreamReader(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "settings");
            while ((this.line = streamReader1.ReadLine()) != null)
            {
                if (this.line == "1")
                    this.GetInfo();
            }
        }

        private void tb_Egg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            System.Windows.MessageBox.Show("干嘛？！我不是彩蛋，你认错人了！","别听楼下瞎说，他就是彩蛋。");
        }

        private void Windows_Closing(object sender, CancelEventArgs e)
        {
            Un4seen.Bass.Bass.BASS_Stop();
            Un4seen.Bass.Bass.BASS_Free();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!Player.isStreamAdded)
                return;
            if (Player.tempStream != 0)
            {
                this.tb_Playing.Text = "当前播放：" + Player.tempName;
                this.pos = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Un4seen.Bass.Bass.BASS_ChannelGetPosition(Player.tempStream));
                this.length = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.tempStream));
                this.tb_Pos.Text = this.pos.ToString("0.0") + "/" + this.length.ToString("0.0");
                if (Player.isLrcExists)
                {
                    if (!Lrc.isLrcCanParse)
                    {
                        this.tb_Lrc.Text = "检测到歌词文件，但解析错误！请检查歌词文件。";
                        this.tb_Lrc.Foreground = (Brush)new SolidColorBrush(Colors.Red);
                    }
                    else if (Lrc.ShowLrc(this.pos, Player.lrcList) != "lrccannotfind")
                    {
                        this.tb_Lrc.Text = Lrc.ShowLrc(this.pos, Player.lrcList);
                        //this.tb_Lrc.Foreground = (Brush)new SolidColorBrush(Color.FromRgb((byte)this.color.Next((int)byte.MaxValue), (byte)this.color.Next((int)byte.MaxValue), (byte)this.color.Next((int)byte.MaxValue)));
                    }
                }
                else
                    this.tb_Lrc.Text = "";
            }
            else
            {
                this.tb_Playing.Text = "当前播放：" + Player.playList[Player.playListSelected];
                this.pos = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Un4seen.Bass.Bass.BASS_ChannelGetPosition(Player.streams[Player.playListSelected]));
                this.length = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
                this.tb_Pos.Text = this.pos.ToString("0.0") + "/" + this.length.ToString("0.0");
                if (Player.isLrcExists)
                {
                    if (!Lrc.isLrcCanParse)
                    {
                        this.tb_Lrc.Text = "检测到歌词文件，但解析错误！请检查歌词文件。";
                        this.tb_Lrc.Foreground = (Brush)new SolidColorBrush(Colors.Red);
                    }
                    else if (Lrc.ShowLrc(this.pos, Player.lrcList) != "lrccannotfind")
                    {
                        this.tb_Lrc.Text = Lrc.ShowLrc(this.pos, Player.lrcList);
                        //this.tb_Lrc.Foreground = (Brush)new SolidColorBrush(Color.FromRgb((byte)this.color.Next((int)byte.MaxValue), (byte)this.color.Next((int)byte.MaxValue), (byte)this.color.Next((int)byte.MaxValue)));
                    }
                }
                else
                    this.tb_Lrc.Text = "";
            }
            this.sl_Pos.Value = this.pos / this.length * 10.0;
        }

        private void sl_Pos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Player.isStreamAdded)
                return;
            if (Player.tempStream != 0)
                Un4seen.Bass.Bass.BASS_ChannelPause(Player.tempStream);
            else
                Un4seen.Bass.Bass.BASS_ChannelPause(Player.streams[Player.playListSelected]);
            this.timer.Stop();
        }

        private void sl_Pos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Player.isStreamAdded)
                return;
            if (this.sl_Pos.Value == 10.0)
            {
                if (this.btn_Pause.IsEnabled && !this.btn_Continue.IsEnabled)
                    Player.PlayNext();
                else
                    this.tempSliderStop = true;
            }
            else if (Player.tempStream != 0)
            {
                this.length = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.tempStream));
                Un4seen.Bass.Bass.BASS_ChannelSetPosition(Player.tempStream, this.sl_Pos.Value / 10.0 * this.length);
                if (this.btn_Pause.IsEnabled || !this.btn_Continue.IsEnabled)
                    Un4seen.Bass.Bass.BASS_ChannelPlay(Player.tempStream, false);
            }
            else
            {
                this.length = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
                Un4seen.Bass.Bass.BASS_ChannelSetPosition(Player.streams[Player.playListSelected], this.sl_Pos.Value / 10.0 * this.length);
                if (this.btn_Pause.IsEnabled || !this.btn_Continue.IsEnabled)
                    Un4seen.Bass.Bass.BASS_ChannelPlay(Player.streams[Player.playListSelected], false);
            }
            if (this.tempSliderStop)
            {
                if (Player.tempStream != 0)
                {
                    this.length = (double)(int)Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.tempStream, Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.tempStream));
                    this.tb_Pos.Text = this.length.ToString() + "/" + (object)this.length;
                }
                else
                {
                    this.length = (double)(int)Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Player.streams[Player.playListSelected], Un4seen.Bass.Bass.BASS_ChannelGetLength(Player.streams[Player.playListSelected]));
                    this.tb_Pos.Text = this.length.ToString() + "/" + (object)this.length;
                }
            }
            else
                this.timer.Start();
        }

        public static void Update()
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] bytes = webClient.DownloadData("http://sagittarius1213.blog.163.com/blog/static/216470160201611631719942/");
                int versionCompare = 1;
                string pageData = Encoding.Default.GetString(bytes);
                string verHead = "版本【";
                int verHeadPos = pageData.IndexOf(verHead);
                string verTail = "】版本";
                int verTailPos = pageData.IndexOf(verTail);
                string verStr = pageData.Substring(verHeadPos + 3, verTailPos - verHeadPos - 3);
                string addrHead = "地址【";
                int  addrHeadPos= pageData.IndexOf(addrHead);
                string addrTail = "】地址";
                int addrTailPos = pageData.IndexOf(addrTail);
                string address = pageData.Substring(addrHeadPos+3, addrTailPos-addrHeadPos-3);
                string contHead = "内容【";
                int contHeadPos = pageData.IndexOf(contHead);
                string contTail = "】内容";
                int contTailPos = pageData.IndexOf(contTail);
                string[] content = pageData.Substring(contHeadPos+3, contTailPos-contHeadPos-3).Split('|');
                string upInfo = "";
                if (content.Count() > 1)
                {
                    for (int index = 0; index < content.Count(); ++index)
                        upInfo = upInfo + "\n" + (object)(index + 1) + "、" + content[index];
                }
                else if (content.Count() == 1)
                    upInfo = content[0];
                string[] verArray = verStr.Split('.');
                int verOne = 0;
                int verNumOne = int.Parse(verArray[verOne]);
                int verTwo = 1;
                int verNumTwo = int.Parse(verArray[verTwo]);
                int verThree = 2;
                int verNumThree = int.Parse(verArray[verThree]);
                int verFour = 3;
                int verNumFour = int.Parse(verArray[verFour]);
                string[] hpVerArray = hpVersion.Split('.');
                int hpVerOne = 0;
                int hpVerNumOne = int.Parse(hpVerArray[hpVerOne]);
                int hpVerTwo = 1;
                int hpVerNumTwo = int.Parse(hpVerArray[hpVerTwo]);
                int hpVerThree = 2;
                int hpVerNumThree = int.Parse(hpVerArray[hpVerThree]);
                int hpVerFour = 3;
                int hpVerNumFour = int.Parse(hpVerArray[hpVerFour]);
                if (verNumOne > hpVerNumOne)
                    versionCompare = 0;
                else if (verNumOne == hpVerNumOne)
                {
                    if (verNumTwo > hpVerNumTwo)
                        versionCompare = 0;
                    else if (verNumTwo == hpVerNumTwo)
                    {
                        if (verNumThree > hpVerNumThree)
                            versionCompare = 0;
                        else if (verNumThree == hpVerNumThree)
                        {
                            if (verNumFour > hpVerNumFour)
                                versionCompare = 0;
                            else if (verNumFour == hpVerNumFour)
                                versionCompare = 1;
                            else if (verNumFour < hpVerNumFour)
                                versionCompare = 2;
                        }
                        else if (verNumThree < hpVerNumThree)
                            versionCompare = 2;
                    }
                    else if (verNumTwo < hpVerNumTwo)
                        versionCompare = 2;
                }
                else if (verNumOne < hpVerNumOne)
                    versionCompare = 2;
                if (versionCompare == 0)
                {
                    if (!(System.Windows.MessageBox.Show("检测到新版本：" + verStr + "\n更新内容：" + upInfo + "\n是否立即安装？", "冬青音乐播放器", MessageBoxButton.YesNo).ToString() == "Yes"))
                        return;
                    Process.Start(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "hpupdater.exe", address);
                }
                else if (versionCompare == 1)
                {
                    int num16 = (int)System.Windows.MessageBox.Show("未发现新版本。", "冬青音乐播放器");
                }
                else
                {
                    if (versionCompare != 2)
                        return;
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception)
            {
                int num = (int)System.Windows.MessageBox.Show("检查更新/更新失败了。", "冬青音乐播放器");
            }
        }
        
        private void GetInfo()
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                string pageData = Encoding.Default.GetString(webClient.DownloadData("http://sagittarius1213.blog.163.com/blog/static/21647016020161177339687/"));
                string noticeHead = "公告【";
                int noticeHeadPos = pageData.IndexOf(noticeHead);
                string noticeTail = "】公告";
                int noticeTailPos = pageData.IndexOf(noticeTail);
                string[] noticeSplitOnce = pageData.Substring(noticeHeadPos+3, noticeTailPos-noticeHeadPos-3).Split(';');
                List<string> noticeList = new List<string>();
                for (int index1 = 0; index1 <noticeSplitOnce.Count(); ++index1)
                {
                    string[] noticeSplitTwice = noticeSplitOnce[index1].Split(',');
                    for (int index2 = 0; index2 < noticeSplitTwice.Count(); ++index2)
                       noticeList.Add(noticeSplitTwice[index2]);
                }
                string notice = "";
                int index3 = 0;
                while (index3 <noticeList.Count)
                {
                    if (noticeList[index3] == hpVersion)
                    {
                        notice = noticeList[index3 + 1];
                        break;
                    }
                    if (noticeList[index3] == "+")
                        notice = noticeList[index3 + 1];
                    index3 += 2;
                }
                string[] noticeArray = notice.Split('|');
                string messageBoxText = "";
                if (noticeArray.Count() > 1)
                {
                    for (int index1 = 0; index1 < noticeArray.Count(); ++index1)
                        messageBoxText = messageBoxText + "\n" + (object)(index1 + 1) + "、" + noticeArray[index1];
                }
                else if (noticeArray.Count() == 1)
                    messageBoxText = noticeArray[0];
                if (!(notice != ""))
                    return;
                int num3 = (int)System.Windows.MessageBox.Show(messageBoxText, "网络公告：");
            }
            catch (Exception)
            {
            }
        }

        private void btn_File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    try
                    {
                        dic.Add(openFileDialog.FileNames[i].Substring(openFileDialog.FileNames[i].LastIndexOf('\\') + 1), openFileDialog.FileNames[i]);
                        Player.files.Add(openFileDialog.FileNames[i]);
                        lb_List.Items.Add(openFileDialog.FileNames[i].Substring(openFileDialog.FileNames[i].LastIndexOf('\\') + 1));
                    }
                    catch (Exception)
                    {
                        System.Windows.MessageBox.Show("很抱歉，暂不支持添加重名文件！","冬青音乐播放器");
                        //System.Diagnostics.Debug.WriteLine(dic.Keys+"\n"+dic.Values+"\n \n");
                        continue;
                        //throw;
                    }
                }
                if (Player.isStreamAdded)
                {
                    Player.PlayListRefresh();
                }
                btn_Play.IsEnabled = true;
            }
            if (Player.isStreamAdded)
                Player.PlayListRefresh();
            this.btn_Play.IsEnabled = true;
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
            {
                Un4seen.Bass.Bass.BASS_Stop();
                Un4seen.Bass.Bass.BASS_Start();
            }
            if (this.lb_List.SelectedIndex == -1)
            {
                if (Player.playMode != 2)
                    this.lb_List.SelectedIndex = 0;
                else
                    this.lb_List.SelectedIndex = new Random().Next(Player.files.Count);
            }
            Player.Play(Player.files, this.lb_List.SelectedIndex);
            this.btn_Last.IsEnabled = true;
            this.btn_Pause.IsEnabled = true;
            this.btn_Continue.IsEnabled = false;
            this.btn_Next.IsEnabled = true;
            this.timer.Start();
        }

        private void btn_ModeZero_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
                Player.PlayModeZero(-1);
            Player.playMode = 0;
            this.tb_Mode.Text = "当前播放模式：列表循环";
        }

        private void btn_Last_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
                Player.PlayLast();
            this.btn_Pause.IsEnabled = true;
            this.btn_Continue.IsEnabled = false;
            this.timer.Start();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            if (!Player.isStreamAdded)
                return;
            if (Player.tempStream != 0)
                Un4seen.Bass.Bass.BASS_ChannelPause(Player.tempStream);
            else
                Un4seen.Bass.Bass.BASS_ChannelPause(Player.streams[Player.playListSelected]);
            this.btn_Pause.IsEnabled = false;
            this.btn_Continue.IsEnabled = true;
            this.timer.Stop();
        }

        private void btn_Continue_Click(object sender, RoutedEventArgs e)
        {
            if (!Player.isStreamAdded)
                return;
            if (this.tempSliderStop)
                Player.PlayNext();
            else if (Player.tempStream != 0)
                Un4seen.Bass.Bass.BASS_ChannelPlay(Player.tempStream, false);
            else
                Un4seen.Bass.Bass.BASS_ChannelPlay(Player.streams[Player.playListSelected], false);
            this.btn_Pause.IsEnabled = true;
            this.btn_Continue.IsEnabled = false;
            this.timer.Start();
        }

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
                Player.PlayNext();
            this.btn_Pause.IsEnabled = true;
            this.btn_Continue.IsEnabled = false;
            this.timer.Start();
        }

        private void btn_ModeOne_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
                Player.PlayModeOne();
            Player.playMode = 1;
            this.tb_Mode.Text = "当前播放模式：单曲循环";
        }

        private void sl_Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, (int)(this.sl_Volume.Value * 1000.0));
        }

        private void btn_ModeTwo_Click(object sender, RoutedEventArgs e)
        {
            if (Player.isStreamAdded)
                Player.PlayModeTwo(-1);
            Player.playMode = 2;
            this.tb_Mode.Text = "当前播放模式：随机播放";
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (this.lb_List.SelectedItems.Count <= 0)
                return;
            object[] objArray = new object[this.lb_List.SelectedItems.Count];
            this.lb_List.SelectedItems.CopyTo((Array)objArray, 0);
            foreach (object removeItem in objArray)
                this.lb_List.Items.Remove(removeItem);
            Player.files.Clear();
            if (this.lb_List.Items.Count == 0)
            {
                this.btn_Play.IsEnabled = false;
                this.btn_Last.IsEnabled = false;
                this.btn_Pause.IsEnabled = false;
                this.btn_Continue.IsEnabled = false;
                this.btn_Next.IsEnabled = false;
                Player.isStreamAdded = false;
                Un4seen.Bass.Bass.BASS_Stop();
                Un4seen.Bass.Bass.BASS_Start();
                this.timer.Stop();
                this.tb_Pos.Text = "";
                this.tb_Playing.Text = "";
                this.sl_Pos.Value = 0.0;
                Player.files.Clear();
                Player.playList.Clear();
                Player.streams.Clear();
                Player.playListSelected = 0;
                Player.tempName = "";
                Player.tempStream = 0;
            }
            else
            {
                for (int index = 0; index < this.lb_List.Items.Count; ++index)
                {
                    this.lb_List.SelectedIndex = index;
                    Player.files.Add(this.lb_List.SelectedItem.ToString());
                }
                this.lb_List.UnselectAll();
                if (!Player.isStreamAdded)
                    return;
                Player.PlayListRefresh();
            }
        }

        private void btn_Skin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xaml文件 (*.xaml)|*.xaml";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    rd.Source = new Uri(openFileDialog.FileName);
                    this.Resources = rd;
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("换肤失败!", "冬青音乐播放器");
                    //throw;
                }
            }
        }

        private void btn_About_Click(object sender, RoutedEventArgs e)
        {
            int num = (int)System.Windows.MessageBox.Show("冬青音乐播放器 v" + hpVersion + "\n作者：bianyukun1213\n" + BassNet.InternalName, "冬青音乐播放器");
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Update();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            List<string> stringList = new List<string>();
            for (int index = 0; index < this.lb_List.Items.Count; ++index)
                stringList.Add("+" + /*this.lb_List.Items[index].ToString()*/dic.Values.ToArray()[index]);
            try
            {
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "list", (IEnumerable<string>)stringList, Encoding.UTF8);
                int num = (int)System.Windows.MessageBox.Show("文件名清单已保存。", "冬青音乐播放器");
            }
            catch (Exception)
            {
                int num = (int)System.Windows.MessageBox.Show("文件名清单保存失败，请检查播放器目录下的list文件，确保它不是只读的并且冬青音乐播放器有权限修改它！", "冬青音乐播放器");
            }
        }
    }
}