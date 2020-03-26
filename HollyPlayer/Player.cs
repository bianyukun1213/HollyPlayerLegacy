using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;
using System.Collections;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace HollyPlayer
{
    class Player
    {
        #region 源码丢失之前的代码。
        //public static List<string> files = new List<string>();//文件列表，显示在listbox上的。
        //public static List<string> playList = new List<string>();//实际播放列表，受播放循环模式的影响。
        //public static List<int> streams = new List<int>();//流，与playList有关。
        //public static int playMode = 0;//播放模式，0为列表循环，1为单曲循环，2为随机播放，没做枚举。
        //private static SYNCPROC MusicEnd = new SYNCPROC(EndSync);//回调函数相关。
        //public static bool isStreamAdded = false;//用于判断流是否已加入到集合中。
        //private static int i;//用于操作流集合的变量。
        //public static int playListSelected;//用于将files选中项转化成playList选中项的变量。
        //public static string tempName;//临时存储文件路径。
        //public static int tempStream;//临时存放流，方便重新生成流后，操作正在播放的流。
        ////private static List<string> tempList;
        //private static void EndSync(int handle, int channel, int data, IntPtr user)//回调函数。
        //{
        //    if (playListSelected >= streams.Count - 1)
        //    {
        //        playListSelected = -1;
        //    }
        //    tempStream = 0;
        //    Bass.BASS_ChannelPlay(streams[++playListSelected], true);
        //}

        //public static void Play(List<string> files, int selected)
        //{
        //    if (isStreamAdded)//判断流是否已被添加，若已被添加则清空合集，同时停止歌曲。
        //    {
        //        for (i = 0; i < streams.Count; i++)
        //        {
        //            Bass.BASS_ChannelStop(streams[i]);
        //        }
        //        playList.Clear();
        //        streams.Clear();
        //    }
        //    switch (playMode)//根据files和playMod生成playList。
        //    {
        //        case 0://列表循环。
        //            CreatePlayListModeZero(selected);
        //            break;
        //        case 1://单曲循环。
        //            CreatePlayListModeOne(selected);
        //            break;
        //        case 2:
        //            CreatePlayListModeTwo(selected);
        //            break;
        //        default://默认列表循环。
        //            CreatePlayListModeZero(selected);
        //            break;
        //    }
        //    CreateStreams();
        //    isStreamAdded = true;//设置流已添加。
        //    Bass.BASS_ChannelPlay(streams[playListSelected], true);//播放选中流。
        //}

        //private static void CreatePlayListModeZero(int selected)//若参数为-1，表示是在播放过程中改变播放模式的，需要根据记录下的当前播放歌曲的路径寻找歌曲在新合集中的位置。
        //{
        //    if (selected == -1)
        //    {
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            playList.Add(files[i]);
        //        }
        //        for (int i = 0; i < playList.Count; i++)
        //        {
        //            if (tempName == playList[i])
        //            {
        //                playListSelected = i;
        //                break;
        //            }
        //            else
        //            {
        //                playListSelected = -1;
        //            }
        //        }
        //        //System.Diagnostics.Debug.WriteLine(playListSelected);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            playList.Add(files[i]);
        //        }
        //        playListSelected = selected;
        //    }
        //}

        //private static void CreatePlayListModeOne(int selected)//因为是单曲循环，就不需要记录位置了，playSelected设置为0就可以了。
        //{
        //    playList.Add(files[selected]);
        //    playListSelected = 0;
        //}

        //private static void CreatePlayListModeTwo(int selected)//若参数为-1，表示是在播放过程中改变播放模式的，需要根据记录下的当前播放歌曲的路径寻找歌曲在新合集中的位置。
        //{
        //    if (selected == -1)
        //    {
        //        Random r = new Random();
        //        foreach (string item in files)
        //        {
        //            playList.Insert(r.Next(playList.Count + 1), item);
        //        }
        //        //for (int i = 0; i < playList.Count; i++)
        //        //{
        //        //    System.Diagnostics.Debug.WriteLine(playList[i]);
        //        //}
        //        for (int i = 0; i < playList.Count; i++)
        //        {
        //            if (tempName == playList[i])
        //            {
        //                playListSelected = i;
        //                break;
        //            }
        //            else
        //            {
        //                playListSelected = -1;
        //            }
        //        }
        //        //System.Diagnostics.Debug.WriteLine(playListSelected);
        //    }
        //    else
        //    {
        //        Random r = new Random();
        //        foreach (string item in files)
        //        {
        //            playList.Insert(r.Next(playList.Count + 1), item);
        //        }
        //        for (int i = 0; i < playList.Count; i++)
        //        {
        //            if (playList[i] == files[selected])
        //            {
        //                playListSelected = i;
        //            }
        //        }
        //    }
        //}

        //private static void CreateStreams()
        //{
        //    for (i = 0; i < playList.Count; i++)//根据playList生成streams，并SetSync。
        //    {
        //        streams.Add(Bass.BASS_StreamCreateFile(playList[i], 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT));
        //        Bass.BASS_ChannelSetSync(streams[i], BASSSync.BASS_SYNC_END | BASSSync.BASS_SYNC_MIXTIME, 0, MusicEnd, IntPtr.Zero);
        //    }
        //}

        //public static void PlayModeZero(int selected)//在播放过程中改变模式时会调用此方法，下同。
        //{
        //    if (tempStream == 0)
        //    {
        //        tempName = playList[playListSelected];
        //        tempStream = streams[playListSelected];
        //    }
        //    //System.Diagnostics.Debug.WriteLine(tempName);
        //    playList.Clear();
        //    streams.Clear();
        //    CreatePlayListModeZero(selected);
        //    CreateStreams();
        //}

        //public static void PlayModeOne()
        //{
        //    if (tempStream == 0)
        //    {
        //        tempName = playList[playListSelected];
        //        tempStream = streams[playListSelected];
        //    }
        //    //System.Diagnostics.Debug.WriteLine(playListSelected);
        //    int tempSelected = playListSelected;
        //    playList.Clear();
        //    streams.Clear();
        //    CreatePlayListModeOne(tempSelected);
        //    CreateStreams();
        //}

        //public static void PlayModeTwo(int selected)
        //{
        //    if (tempStream == 0)
        //    {
        //        tempName = playList[playListSelected];
        //        tempStream = streams[playListSelected];
        //    }
        //    //System.Diagnostics.Debug.WriteLine("tempName："+tempName);
        //    playList.Clear();
        //    streams.Clear();
        //    CreatePlayListModeTwo(selected);
        //    CreateStreams();
        //}

        //public static void PlayLast()
        //{
        //    Bass.BASS_Stop();
        //    Bass.BASS_Start();
        //    tempStream = 0;
        //    if (playListSelected == 0)
        //    {
        //        Bass.BASS_ChannelPlay(streams[streams.Count - 1], true);
        //        playListSelected = playList.Count - 1;
        //    }
        //    else
        //    {
        //        Bass.BASS_ChannelPlay(streams[playListSelected - 1], true);
        //        playListSelected -= 1;
        //    }
        //}

        //public static void PlayNext()
        //{
        //    Bass.BASS_Stop();
        //    Bass.BASS_Start();
        //    tempStream = 0;
        //    if (playListSelected == (streams.Count - 1))
        //    {
        //        Bass.BASS_ChannelPlay(streams[0], true);
        //        playListSelected = 0;
        //    }
        //    else
        //    {
        //        Bass.BASS_ChannelPlay(streams[playListSelected + 1], true);
        //        playListSelected += 1;
        //    }
        //}

        //public static void PlayListRefresh()
        //{

        //    switch (playMode)//根据files和playMod生成playList。
        //    {
        //        case 0://列表循环。
        //            PlayModeZero(-1);
        //            break;
        //        case 1://单曲循环。
        //            PlayModeOne();
        //            break;
        //        case 2:
        //            PlayModeTwo(-1);
        //            break;
        //        default://默认列表循环。
        //            PlayModeZero(-1);
        //            break;
        //    }
        //}
        #endregion
        public static List<string> files = new List<string>();
        public static List<string> playList = new List<string>();
        public static List<int> streams = new List<int>();
        public static int playMode = 0;
        private static SYNCPROC MusicEnd = new SYNCPROC(Player.EndSync);
        public static bool isStreamAdded = false;
        public static bool isLrcExists = true;
        private static int i;
        public static int playListSelected;
        public static string tempName;
        public static int tempStream;
        public static List<string> lrcList;
        private static string lrcFileName;

        private static void EndSync(int handle, int channel, int data, IntPtr user)
        {
            if (Player.playListSelected >= Player.streams.Count - 1)
                Player.playListSelected = -1;
            Player.tempStream = 0;
            Player.PlayReady(Player.streams[++Player.playListSelected], true);
        }

        public static void Play(List<string> files, int selected)
        {
            if (Player.isStreamAdded)
            {
                if (Player.tempStream != 0)
                {
                    Un4seen.Bass.Bass.BASS_ChannelStop(Player.tempStream);
                    Player.tempStream = 0;
                }
                for (Player.i = 0; Player.i < Player.streams.Count; ++Player.i)
                    Un4seen.Bass.Bass.BASS_ChannelStop(Player.streams[Player.i]);
                Player.playList.Clear();
                Player.streams.Clear();
            }
            switch (Player.playMode)
            {
                case 0:
                    Player.CreatePlayListModeZero(selected);
                    break;
                case 1:
                    Player.CreatePlayListModeOne(selected);
                    break;
                case 2:
                    Player.CreatePlayListModeTwo(selected);
                    break;
                default:
                    Player.CreatePlayListModeZero(selected);
                    break;
            }
            Player.CreateStreams();
            Player.isStreamAdded = true;
            Player.PlayReady(Player.streams[Player.playListSelected], true);
        }

        private static void CreatePlayListModeZero(int selected)
        {
            if (selected == -1)
            {
                for (int index = 0; index < Player.files.Count; ++index)
                    Player.playList.Add(Player.files[index]);
                for (int index = 0; index < Player.playList.Count; ++index)
                {
                    if (Player.tempName == Player.playList[index])
                    {
                        Player.playListSelected = index;
                        break;
                    }
                    Player.playListSelected = -1;
                }
            }
            else
            {
                for (int index = 0; index < Player.files.Count; ++index)
                    Player.playList.Add(Player.files[index]);
                Player.playListSelected = selected;
            }
        }

        private static void CreatePlayListModeOne(int selected)
        {
            Player.playList.Add(Player.files[selected]);
            Player.playListSelected = 0;
        }

        private static void CreatePlayListModeTwo(int selected)
        {
            if (selected == -1)
            {
                Random random = new Random();
                foreach (string file in Player.files)
                    Player.playList.Insert(random.Next(Player.playList.Count + 1), file);
                for (int index = 0; index < Player.playList.Count; ++index)
                {
                    if (Player.tempName == Player.playList[index])
                    {
                        Player.playListSelected = index;
                        break;
                    }
                    Player.playListSelected = -1;
                }
            }
            else
            {
                Random random = new Random();
                foreach (string file in Player.files)
                    Player.playList.Insert(random.Next(Player.playList.Count + 1), file);
                for (int index = 0; index < Player.playList.Count; ++index)
                {
                    if (Player.playList[index] == Player.files[selected])
                        Player.playListSelected = index;
                }
            }
        }

        private static void CreateStreams()
        {
            for (Player.i = 0; Player.i < Player.playList.Count; ++Player.i)
            {
                Player.streams.Add(Un4seen.Bass.Bass.BASS_StreamCreateFile(Player.playList[Player.i], 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT));
                Un4seen.Bass.Bass.BASS_ChannelSetSync(Player.streams[Player.i], BASSSync.BASS_SYNC_END | BASSSync.BASS_SYNC_MIXTIME, 0L, Player.MusicEnd, IntPtr.Zero);
            }
        }

        public static void PlayModeZero(int selected)
        {
            if (Player.tempStream == 0)
            {
                Player.tempName = Player.playList[Player.playListSelected];
                Player.tempStream = Player.streams[Player.playListSelected];
            }
            Player.playList.Clear();
            Player.streams.Clear();
            Player.CreatePlayListModeZero(selected);
            Player.CreateStreams();
        }

        public static void PlayModeOne()
        {
            if (Player.tempStream == 0)
            {
                Player.tempName = Player.playList[Player.playListSelected];
                Player.tempStream = Player.streams[Player.playListSelected];
            }
            int playListSelected = Player.playListSelected;
            Player.playList.Clear();
            Player.streams.Clear();
            Player.CreatePlayListModeOne(playListSelected);
            Player.CreateStreams();
        }

        public static void PlayModeTwo(int selected)
        {
            if (Player.tempStream == 0)
            {
                Player.tempName = Player.playList[Player.playListSelected];
                Player.tempStream = Player.streams[Player.playListSelected];
            }
            Player.playList.Clear();
            Player.streams.Clear();
            Player.CreatePlayListModeTwo(selected);
            Player.CreateStreams();
        }

        public static void PlayLast()
        {
            Un4seen.Bass.Bass.BASS_Stop();
            Un4seen.Bass.Bass.BASS_Start();
            Player.tempStream = 0;
            if (Player.playListSelected == 0)
            {
                Player.playListSelected = Player.playList.Count - 1;
                Player.PlayReady(Player.streams[Player.streams.Count - 1], true);
            }
            else
            {
                --Player.playListSelected;
                Player.PlayReady(Player.streams[Player.playListSelected], true);
            }
        }

        public static void PlayNext()
        {
            Un4seen.Bass.Bass.BASS_Stop();
            Un4seen.Bass.Bass.BASS_Start();
            Player.tempStream = 0;
            if (Player.playListSelected == Player.streams.Count - 1)
            {
                Player.playListSelected = 0;
                Player.PlayReady(Player.streams[0], true);
            }
            else
            {
                ++Player.playListSelected;
                Player.PlayReady(Player.streams[Player.playListSelected], true);
            }
        }

        public static void PlayListRefresh()
        {
            switch (Player.playMode)
            {
                case 0:
                    Player.PlayModeZero(-1);
                    break;
                case 1:
                    Player.PlayModeOne();
                    break;
                case 2:
                    Player.PlayModeTwo(-1);
                    break;
                default:
                    Player.PlayModeZero(-1);
                    break;
            }
        }

        public static void PlayReady(int stream, bool begin)
        {
            if (!Un4seen.Bass.Bass.BASS_ChannelPlay(stream, begin))
            {
                MessageBox.Show("文件异常，即将结束进程。", "冬青音乐播放器");
                File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "list");
                Process.GetCurrentProcess().Kill();
            }
            Player.lrcFileName = Player.playList[Player.playListSelected].Substring(0, Player.playList[Player.playListSelected].LastIndexOf("."));
            if (File.Exists(Player.lrcFileName + ".lrc"))
            {
                Player.isLrcExists = true;
                Player.lrcList = Lrc.ParseLrc(Player.lrcFileName + ".lrc");
            }
            else
                Player.isLrcExists = false;
        }
    }
}