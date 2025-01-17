using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GHNamespace7;
using GHNamespace8;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceE;
using GHNamespaceF;
using GHNamespaceG;
using GuitarHero.Songlist;

namespace GHNamespaceN
{
    public class QbcParser
    {
        public Dictionary<string, Track<int, NotesAtOffset>> NoteList =
            new Dictionary<string, Track<int, NotesAtOffset>>();

        public Dictionary<string, Track<int, int[]>> SpList = new Dictionary<string, Track<int, int[]>>();

        public Dictionary<string, Track<int, int[]>> BattleNoteList = new Dictionary<string, Track<int, int[]>>();

        public Fretbar<int> FretbarList;

        public Track<int, int[]> TsList = new Track<int, int[]>();

        public Track<int, string> Class2281 = new Track<int, string>();

        public Track<int, int> Class2282 = new Track<int, int>();

        public Track<int, int> Class2283 = new Track<int, int>();

        public Track<int, int> BpmList = new Track<int, int>();

        public Track<int, int> Class2285 = new Track<int, int>();

        public int Int0;

        public int Int1 = 480;

        public static float Float0 = 2.82352948f;

        public Gh3Song Gh3Song0 = new Gh3Song();

        private Track<int, int> _class2286;

        private readonly FloatListNode _class2870 = new FloatListNode(true);

        public QbcParser()
        {
            FretbarList = new Fretbar<int>();
        }

        public QbcParser(Gh3Song gh3Song1) : this()
        {
            Gh3Song0 = gh3Song1;
        }

        public QbcParser(string fileName)
        {
            List<string> list = new List<string>();
            StreamReader streamReader = File.OpenText(fileName);
            string text = null;
            string currentLine;
            while ((currentLine = streamReader.ReadLine()) != null)
            {
                if (currentLine.StartsWith("["))
                {
                    text = currentLine.Split(new[]
                    {
                        '[',
                        ']'
                    }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                else if (!currentLine.Equals("{"))
                {
                    if (currentLine.Equals("}"))
                    {
                        string key;
                        if ((key = text) == null)
                        {
                            goto IL_8AA;
                        }
                        if (Class369.Dictionary0 == null)
                        {
                            Class369.Dictionary0 = new Dictionary<string, int>(8)
                            {
                                {
                                    "Song",
                                    0
                                },
                                {
                                    "SyncTrack",
                                    1
                                },
                                {
                                    "FretBars",
                                    2
                                },
                                {
                                    "Events",
                                    3
                                },
                                {
                                    "FaceOffP1",
                                    4
                                },
                                {
                                    "FaceOffP2",
                                    5
                                },
                                {
                                    "BossBattleP1",
                                    6
                                },
                                {
                                    "BossBattleP2",
                                    7
                                }
                            };
                        }
                        if (Class369.Dictionary0.TryGetValue(key, out int num))
                        {
                            switch (num)
                            {
                                case 0:
                                    Gh3Song0.Editable = true;
                                    using (List<string>.Enumerator enumerator = list.GetEnumerator())
                                    {
                                        while (enumerator.MoveNext())
                                        {
                                            string current = enumerator.Current;
                                            string[] array = current.Split(new[]
                                            {
                                                '\t',
                                                '='
                                            }, StringSplitOptions.RemoveEmptyEntries);
                                            if (array.Length > 1)
                                            {
                                                string text3 = array[0].Trim().ToLower();
                                                string text4 = array[1].Trim().Replace("\"", "");
                                                string key2;
                                                switch (key2 = text3)
                                                {
                                                    case "name":
                                                        Gh3Song0.Title = text4;
                                                        break;
                                                    case "artist":
                                                        Gh3Song0.Artist = text4;
                                                        break;
                                                    case "year":
                                                        Gh3Song0.Year = text4;
                                                        break;
                                                    case "player2":
                                                        Gh3Song0.NotBass = !text4.ToLower().Equals("bass");
                                                        break;
                                                    case "artisttext":
                                                        if (text4.Equals("by"))
                                                        {
                                                            Gh3Song0.ArtistText = true;
                                                        }
                                                        else if (text4.Equals("as made famous by"))
                                                        {
                                                            Gh3Song0.ArtistText = false;
                                                        }
                                                        else
                                                        {
                                                            Gh3Song0.ArtistText = text4;
                                                        }
                                                        break;
                                                    case "offset":
                                                        Gh3Song0.InputOffset =
                                                        (Gh3Song0.GemOffset = Convert.ToInt32(
                                                            Convert.ToDouble(text4) * -1000.0));
                                                        break;
                                                    case "singer":
                                                        Gh3Song0.Singer = text4;
                                                        break;
                                                    case "bassist":
                                                        Gh3Song0.Bassist = text4;
                                                        break;
                                                    case "boss":
                                                        Gh3Song0.Boss = text4;
                                                        break;
                                                    case "countoff":
                                                        Gh3Song0.Countoff = text4;
                                                        break;
                                                    case "guitarvol":
                                                        Gh3Song0.GuitarVol = Convert.ToSingle(text4);
                                                        break;
                                                    case "bandvol":
                                                        Gh3Song0.BandVol = Convert.ToSingle(text4);
                                                        break;
                                                    case "hopo":
                                                        Gh3Song0.HammerOn = Convert.ToSingle(text4);
                                                        break;
                                                    case "originalartist":
                                                        Gh3Song0.OriginalArtist = text4.Equals("true");
                                                        break;
                                                    case "resolution":
                                                        Int1 = Convert.ToInt32(text4);
                                                        break;
                                                }
                                            }
                                        }
                                        goto IL_A3C;
                                    }
                                case 1:
                                    goto IL_514;
                                case 2:
                                    goto IL_5AE;
                                case 3:
                                    using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
                                    {
                                        while (enumerator2.MoveNext())
                                        {
                                            string current2 = enumerator2.Current;
                                            string[] array2 = current2.Split(new[]
                                            {
                                                ' ',
                                                '\t',
                                                '='
                                            }, StringSplitOptions.RemoveEmptyEntries);
                                            string a;
                                            if ((a = array2[1]) != null && a == "S")
                                            {
                                                Class2281.Add(Convert.ToInt32(array2[0]), array2[2]);
                                            }
                                        }
                                        goto IL_A3C;
                                    }
                                case 4:
                                    break;
                                case 5:
                                    goto IL_72D;
                                case 6:
                                    goto IL_7AC;
                                case 7:
                                    goto IL_82B;
                                default:
                                    goto IL_8AA;
                            }
                            using (List<string>.Enumerator enumerator3 = list.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    string current3 = enumerator3.Current;
                                    string[] array3 = current3.Split(new[]
                                    {
                                        ' ',
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    string a2;
                                    if ((a2 = array3[1]) != null && a2 == "F")
                                    {
                                        Class2282.Add(Convert.ToInt32(array3[0]), Convert.ToInt32(array3[2]));
                                    }
                                }
                                goto IL_A3C;
                            }
                        IL_5AE:
                            FretbarList = new Fretbar<int>();
                            foreach (string current4 in list)
                            {
                                FretbarList.method_1(Convert.ToInt32(current4.Trim(' ', '\t', '=')));
                            }
                            Int0 = (FretbarList[1] - FretbarList[0]) / 4;
                            goto IL_A3C;
                        IL_514:
                            using (List<string>.Enumerator enumerator5 = list.GetEnumerator())
                            {
                                while (enumerator5.MoveNext())
                                {
                                    string current5 = enumerator5.Current;
                                    string[] array4 = current5.Split(new[]
                                    {
                                        ' ',
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    string a3;
                                    if ((a3 = array4[1]) != null && a3 == "TS")
                                    {
                                        TsList.Add(Convert.ToInt32(array4[0]), new[]
                                        {
                                            Convert.ToInt32(array4[2]),
                                            Convert.ToInt32(array4[3])
                                        });
                                    }
                                }
                                goto IL_A3C;
                            }
                        IL_72D:
                            using (List<string>.Enumerator enumerator6 = list.GetEnumerator())
                            {
                                while (enumerator6.MoveNext())
                                {
                                    string current6 = enumerator6.Current;
                                    string[] array5 = current6.Split(new[]
                                    {
                                        ' ',
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    string a4;
                                    if ((a4 = array5[1]) != null && a4 == "F")
                                    {
                                        Class2283.Add(Convert.ToInt32(array5[0]), Convert.ToInt32(array5[2]));
                                    }
                                }
                                goto IL_A3C;
                            }
                        IL_7AC:
                            using (List<string>.Enumerator enumerator7 = list.GetEnumerator())
                            {
                                while (enumerator7.MoveNext())
                                {
                                    string current7 = enumerator7.Current;
                                    string[] array6 = current7.Split(new[]
                                    {
                                        ' ',
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    string a5;
                                    if ((a5 = array6[1]) != null && a5 == "B")
                                    {
                                        BpmList.Add(Convert.ToInt32(array6[0]), Convert.ToInt32(array6[2]));
                                    }
                                }
                                goto IL_A3C;
                            }
                        IL_82B:
                            using (List<string>.Enumerator enumerator8 = list.GetEnumerator())
                            {
                                while (enumerator8.MoveNext())
                                {
                                    string current8 = enumerator8.Current;
                                    string[] array7 = current8.Split(new[]
                                    {
                                        ' ',
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    string a6;
                                    if ((a6 = array7[1]) != null && a6 == "B")
                                    {
                                        Class2285.Add(Convert.ToInt32(array7[0]), Convert.ToInt32(array7[2]));
                                    }
                                }
                                goto IL_A3C;
                            }
                        }
                        goto IL_8AA;
                        IL_A3C:
                        list.Clear();
                        continue;
                        IL_8AA:
                        text = text.ToLower();
                        if (!NoteList.ContainsKey(text))
                        {
                            Track<int, NotesAtOffset> noteList = new Track<int, NotesAtOffset>();
                            Track<int, int[]> spList = new Track<int, int[]>();
                            Track<int, int[]> battleNote = new Track<int, int[]>();
                            foreach (string current9 in list)
                            {
                                string[] array8 = current9.Split(new[]
                                {
                                    ' ',
                                    '\t',
                                    '='
                                }, StringSplitOptions.RemoveEmptyEntries);
                                string a7;
                                if ((a7 = array8[1]) != null)
                                {
                                    if (!(a7 == "N"))
                                    {
                                        if (!(a7 == "S"))
                                        {
                                            if (a7 == "B")
                                            {
                                                battleNote.Add(Convert.ToInt32(array8[0]), new[]
                                                {
                                                    Convert.ToInt32(array8[3]),
                                                    Convert.ToInt32(array8[2])
                                                });
                                            }
                                        }
                                        else
                                        {
                                            spList.Add(Convert.ToInt32(array8[0]), new[]
                                            {
                                                Convert.ToInt32(array8[3]),
                                                Convert.ToInt32(array8[2])
                                            });
                                        }
                                    }
                                    else
                                    {
                                        noteList.Add(Convert.ToInt32(array8[0]),
                                            new NotesAtOffset(Convert.ToInt32(array8[2]), Convert.ToInt32(array8[3])));
                                    }
                                }
                            }
                            NoteList.Add(text, noteList);
                            SpList.Add(text, spList);
                            BattleNoteList.Add(text, battleNote);
                        }
                        goto IL_A3C;
                    }
                    if (!currentLine.Equals(""))
                    {
                        list.Add(currentLine);
                    }
                }
            }
            streamReader.Close();
        }

        public QbcParser(string string0, ZzGenericNode1 class3080) : this(string0, class3080, null)
        {
        }

        public QbcParser(string gh3SongName, ZzGenericNode1 class3080, ZzGenericNode1 class3081) : this(gh3SongName,
            class3080, class3081, null)
        {
        }

        public QbcParser(string string0, ZzGenericNode1 class3080, ZzGenericNode1 class3081, ZzGenericNode1 class3082)
        {
            string[] array =
            {
                "Easy",
                "Medium",
                "Hard",
                "Expert"
            };
            string[] array2 =
            {
                "Single",
                "Double"
            };
            ArrayPointerRootNode @class;
            for (int i = 0; i < array2.Length; i++)
            {
                string a = array2[i];
                string[] array3 =
                {
                    "Guitar",
                    "Rhythm"
                };
                for (int j = 0; j < array3.Length; j++)
                {
                    string text = array3[j];
                    string[] array4 = array;
                    for (int k = 0; k < array4.Length; k++)
                    {
                        string text2 = array4[k];
                        string text3 =
                            (text.ToLower() + ((a == "Double") ? "coop" : "") + "_" + text2.ToLower())
                            .Replace("guitar_", "");
                        @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_song_" + text3));
                        if (@class != null && @class.method_7() is IntegerArrayNode)
                        {
                            Track<int, NotesAtOffset> class2 = new Track<int, NotesAtOffset>();
                            int[] array5 = @class.method_7().method_7<int>();
                            for (int l = 0; l < array5.Length; l += 3)
                            {
                                class2.Add(array5[l], new NotesAtOffset(array5[l + 2], array5[l + 1]));
                            }
                            NoteList.Add(text3, class2);
                        }
                        @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_" + text3 + "_star"));
                        if (@class != null && @class.method_7() is ListArrayNode)
                        {
                            Track<int, int[]> class3 = new Track<int, int[]>();
                            foreach (IntegerArrayNode current in @class.method_7().method_8<IntegerArrayNode>())
                            {
                                class3.Add(current[0], new[]
                                {
                                    current[1],
                                    current[2]
                                });
                            }
                            SpList.Add(text3, class3);
                        }
                        @class = class3080.zzFindNode(
                            new ArrayPointerRootNode(string0 + "_" + text3 + "_starbattlemode"));
                        if (@class != null && @class.method_7() is ListArrayNode)
                        {
                            Track<int, int[]> class4 = new Track<int, int[]>();
                            foreach (IntegerArrayNode current2 in @class.method_7().method_8<IntegerArrayNode>())
                            {
                                class4.Add(current2[0], new[]
                                {
                                    current2[1],
                                    current2[2]
                                });
                            }
                            BattleNoteList.Add(text3, class4);
                        }
                    }
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_faceoffp1"));
            if (@class != null && @class.method_7() is ListArrayNode)
            {
                foreach (IntegerArrayNode current3 in @class.method_7().method_8<IntegerArrayNode>())
                {
                    Class2282.Add(current3[0], current3[1]);
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_faceoffp2"));
            if (@class != null && @class.method_7() is ListArrayNode)
            {
                foreach (IntegerArrayNode current4 in @class.method_7().method_8<IntegerArrayNode>())
                {
                    Class2283.Add(current4[0], current4[1]);
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_bossbattlep1"));
            if (@class != null && @class.method_7() is ListArrayNode)
            {
                foreach (IntegerArrayNode current5 in @class.method_7().method_8<IntegerArrayNode>())
                {
                    BpmList.Add(current5[0], current5[1]);
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_bossbattlep2"));
            if (@class != null && @class.method_7() is ListArrayNode)
            {
                foreach (IntegerArrayNode current6 in @class.method_7().method_8<IntegerArrayNode>())
                {
                    Class2285.Add(current6[0], current6[1]);
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_timesig"));
            if (@class != null && @class.method_7() is ListArrayNode)
            {
                foreach (IntegerArrayNode current7 in @class.method_7().method_8<IntegerArrayNode>())
                {
                    TsList.Add(current7[0], new[]
                    {
                        current7[1],
                        current7[2]
                    });
                }
            }
            @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_fretbars"));
            if (@class != null && @class.method_7() is IntegerArrayNode)
            {
                FretbarList = new Fretbar<int>(@class.method_7().method_8<int>());
                Int0 = (FretbarList[1] - FretbarList[0]) / 4;
                try
                {
                    Dictionary<int, string> dictionary = new Dictionary<int, string>();
                    @class = class3080.zzFindNode(new ArrayPointerRootNode(string0 + "_markers"));
                    if (class3081 != null && @class != null && @class.method_7() is StructureArrayNode)
                    {
                        foreach (UnicodeRootNode class5 in class3081.Nodes)
                        {
                            dictionary.Add(class5.Int0, class5.method_7());
                        }
                        using (List<StructureHeaderNode>.Enumerator enumerator9 = @class.method_7().method_8<StructureHeaderNode>().GetEnumerator())
                        {
                            while (enumerator9.MoveNext())
                            {
                                StructureHeaderNode current8 = enumerator9.Current;
                                Class2281.Add(((IntegerStructureNode) current8[0]).method_8(),
                                    dictionary[((FileTagStructureNode) current8[1]).method_9()]);
                            }
                            goto IL_7C2;
                        }
                    }
                    if (@class != null && @class.method_7() is StructureArrayNode)
                    {
                        foreach (StructureHeaderNode current9 in @class.method_7().method_8<StructureHeaderNode>())
                        {
                            Class2281.Add(((IntegerStructureNode) current9[0]).method_8(),
                                ((UnicodeStructureNode) current9[1]).method_8());
                        }
                    }
                    IL_7C2:
                    ;
                }
                catch
                {
                }
                try
                {
                    if (class3082 != null)
                    {
                        Gh3Song0 = new Gh3Song(class3082.zzFindNode(new StructurePointerNode(string0)));
                    }
                    return;
                }
                catch
                {
                    return;
                }
            }
            throw new Exception("Not a MID.QB!");
        }

        private int method_0(int int2)
        {
            int num = _class2286.method_1(int2);
            return Convert.ToInt32((num + (int2 - _class2286.Keys[num]) / (double) _class2286.Values[num]) * Int1);
        }

        public ChartParser method_1()
        {
            return method_2(null);
        }

        public ChartParser method_2(Gh3Song gh3Song1)
        {
            ChartParser @class = new ChartParser(Gh3Song0)
            {
                Constant480 = Int1
            };
            if (gh3Song1 != null)
            {
                @class.Gh3SongInfo.vmethod_0(gh3Song1);
            }
            _class2286 = new Track<int, int>();
            if (FretbarList != null)
            {
                int value = FretbarList[0];
                FretbarList[0] = 0;
                int num = 0;
                for (int i = 1; i < FretbarList.Count; i++)
                {
                    int num2 = FretbarList[i] - FretbarList[i - 1];
                    int num3 = Convert.ToInt32(60000000.0 / num2);
                    if (num3 != num)
                    {
                        @class.BpmInterpreter.BpmList.Add((i - 1) * Int1, num3);
                        num = num3;
                    }
                    _class2286.Add(FretbarList[i - 1], num2);
                }
                FretbarList[0] = value;
                @class.SectionInterpreter.OtherList.Add(method_0(FretbarList[FretbarList.Count - 1]), new List<string>(
                    new[]
                    {
                        "end"
                    }));
                foreach (int current in Class2281.Keys)
                {
                    @class.SectionInterpreter.SectionList.Add(method_0(current), Class2281[current]);
                }
                foreach (int current2 in TsList.Keys)
                {
                    @class.BpmInterpreter.TsList.Add(method_0(current2), TsList[current2][0]);
                }
                Track<int, int> class2 = new Track<int, int>();
                Track<int, int> class3 = new Track<int, int>();
                foreach (int current3 in Class2282.Keys)
                {
                    int num4 = method_0(current3);
                    int num5 = method_0(current3 + Class2282[current3] - Int0) - num4;
                    class2.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                }
                foreach (int current4 in Class2283.Keys)
                {
                    int num4 = method_0(current4);
                    int num5 = method_0(current4 + Class2283[current4] - Int0) - num4;
                    class3.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                }
                Track<int, int> class4 = new Track<int, int>();
                Track<int, int> class5 = new Track<int, int>();
                foreach (int current5 in BpmList.Keys)
                {
                    int num4 = method_0(current5);
                    int num5 = method_0(current5 + BpmList[current5] - Int0) - num4;
                    class4.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                }
                foreach (int current6 in Class2285.Keys)
                {
                    int num4 = method_0(current6);
                    int num5 = method_0(current6 + Class2285[current6] - Int0) - num4;
                    class5.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                }
                string[] array =
                {
                    "Easy",
                    "Medium",
                    "Hard",
                    "Expert"
                };
                string[] array2 =
                {
                    "Single",
                    "Double"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string text = array2[j];
                    string[] array3 =
                    {
                        "Guitar",
                        "Rhythm"
                    };
                    for (int k = 0; k < array3.Length; k++)
                    {
                        string text2 = array3[k];
                        string[] array4 = array;
                        for (int l = 0; l < array4.Length; l++)
                        {
                            string text3 = array4[l];
                            string key = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower())
                                .Replace("guitar_", "");
                            if (NoteList.ContainsKey(key))
                            {
                                NoteEventInterpreter class6 = new NoteEventInterpreter();
                                Track<int, NotesAtOffset> class7 = NoteList[key];
                                foreach (int current7 in class7.Keys)
                                {
                                    int num4 = method_0(current7);
                                    int num5 = method_0(current7 + class7[current7].SustainLength - Int0) - num4;
                                    class6.NoteList.Add(num4,
                                        new NotesAtOffset(class7[current7].NoteValues, (num5 <= Int1 / 4) ? 0 : num5));
                                }
                                class6.AlwaysTrue = false;
                                if (SpList.ContainsKey(key))
                                {
                                    Track<int, int[]> class8 = SpList[key];
                                    foreach (int current8 in class8.Keys)
                                    {
                                        int num4 = method_0(current8);
                                        int num5 = method_0(current8 + class8[current8][0] - Int0) - num4;
                                        class6.Class2281.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                                    }
                                }
                                if (BattleNoteList.ContainsKey(key))
                                {
                                    Track<int, int[]> class9 = SpList[key];
                                    foreach (int current9 in class9.Keys)
                                    {
                                        int num4 = method_0(current9);
                                        int num5 = method_0(current9 + class9[current9][0] - Int0) - num4;
                                        class6.Class2284.Add(num4, (num5 <= Int1 / 4) ? 0 : num5);
                                    }
                                }
                                class6.Class2282 = class2;
                                class6.Class2283 = class3;
                                class6.Class2285 = class4;
                                class6.Class2286 = class5;
                                @class.DifficultyWithNotes.Add(text3 + text + text2, class6);
                            }
                        }
                    }
                }
                _class2286.Clear();
                _class2286 = null;
                return @class;
            }
            return null;
        }

        public void QbcCreator(string fileLocation, Gh3Song song)
        {
            Gh3Song0 = song;
            StreamWriter streamWriter = new StreamWriter(fileLocation);
            streamWriter.WriteLine("[Song]");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("\tName = \"" + Gh3Song0.Title + "\"");
            streamWriter.WriteLine("\tArtist = \"" + Gh3Song0.Artist + "\"");
            streamWriter.WriteLine("\tYear = \"" + Gh3Song0.Year + "\"");
            streamWriter.WriteLine("\tPlayer2 = " + (Gh3Song0.NotBass ? "Rhythm" : "Bass"));
            streamWriter.WriteLine("\tArtistText = \"" + ((Gh3Song0.ArtistText is bool)
                                       ? (((bool) Gh3Song0.ArtistText) ? "by" : "as made famous by")
                                       : ((string) Gh3Song0.ArtistText)) + "\"");
            streamWriter.WriteLine("\tOffset = " + Gh3Song0.InputOffset / -1000.0);
            if (!Gh3Song0.Singer.Equals(""))
            {
                streamWriter.WriteLine("\tSinger = \"" + Gh3Song0.Singer + "\"");
            }
            if (!Gh3Song0.Bassist.Equals("Generic Bassist"))
            {
                streamWriter.WriteLine("\tBassist = \"" + Gh3Song0.Bassist + "\"");
            }
            if (!Gh3Song0.Boss.Equals(""))
            {
                streamWriter.WriteLine("\tBoss = \"" + Gh3Song0.Boss + "\"");
            }
            streamWriter.WriteLine("\tCountOff = \"" + Gh3Song0.Countoff + "\"");
            streamWriter.WriteLine("\tGuitarVol = " + Gh3Song0.GuitarVol);
            streamWriter.WriteLine("\tBandVol = " + Gh3Song0.BandVol);
            streamWriter.WriteLine("\tHoPo = " + Gh3Song0.HammerOn);
            streamWriter.WriteLine("\tOriginalArtist = " + (Gh3Song0.OriginalArtist ? "true" : "false"));
            streamWriter.WriteLine("\tResolution = " + Int1);
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[SyncTrack]");
            streamWriter.WriteLine("{");
            foreach (int current in TsList.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current, " = TS ", TsList[current][0], " ",
                    TsList[current][1]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FretBars]");
            streamWriter.WriteLine("{");
            foreach (int current2 in FretbarList)
            {
                streamWriter.WriteLine("\t" + current2);
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[Events]");
            streamWriter.WriteLine("{");
            foreach (int current3 in Class2281.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current3, " = S \"", Class2281[current3], "\""));
            }
            streamWriter.WriteLine("}");
            string[] array =
            {
                "",
                "rhythm_",
                "guitarcoop_",
                "rhythmcoop_"
            };
            for (int i = 0; i < array.Length; i++)
            {
                string str = array[i];
                string[] array2 =
                {
                    "easy",
                    "medium",
                    "hard",
                    "expert"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string str2 = array2[j];
                    string text = str + str2;
                    Track<int, NotesAtOffset> @class = NoteList.ContainsKey(text) ? NoteList[text] : new Track<int, NotesAtOffset>();
                    Track<int, int[]> class2 = SpList.ContainsKey(text) ? SpList[text] : new Track<int, int[]>();
                    Track<int, int[]> class3 = BattleNoteList.ContainsKey(text) ? BattleNoteList[text] : new Track<int, int[]>();
                    Class221<int> class4 = new Class221<int>(@class.Keys);
                    class4.vmethod_1(class2.Keys);
                    class4.vmethod_1(class3.Keys);
                    class4.Sort();
                    StringBuilder stringBuilder = new StringBuilder(text);
                    stringBuilder[0] = char.ToUpper(stringBuilder[0]);
                    if (text.Contains("_"))
                    {
                        stringBuilder[text.IndexOf('_') + 1] = char.ToUpper(stringBuilder[text.IndexOf('_') + 1]);
                    }
                    streamWriter.WriteLine("[" + stringBuilder + "]");
                    streamWriter.WriteLine("{");
                    foreach (int current4 in class4)
                    {
                        if (@class.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = N ", @class[current4].method_0(),
                                " ", @class[current4].SustainLength));
                        }
                        if (class2.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = S ", class2[current4][1], " ",
                                class2[current4][0]));
                        }
                        if (class3.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = B ", class3[current4][1], " ",
                                class3[current4][0]));
                        }
                    }
                    streamWriter.WriteLine("}");
                }
            }
            streamWriter.WriteLine("[FaceOffP1]");
            streamWriter.WriteLine("{");
            foreach (int current5 in Class2282.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current5, " = F ", Class2282[current5]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FaceOffP2]");
            streamWriter.WriteLine("{");
            foreach (int current6 in Class2283.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current6, " = F ", Class2283[current6]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP1]");
            streamWriter.WriteLine("{");
            foreach (int current7 in BpmList.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current7, " = B ", BpmList[current7]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP2]");
            streamWriter.WriteLine("{");
            foreach (int current8 in Class2285.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current8, " = B ", Class2285[current8]));
            }
            streamWriter.WriteLine("}");
            streamWriter.Close();
        }

        public ZzGenericNode1 method_4(string string0)
        {
            ZzGenericNode1 @class = new ZzGenericNode1();
            int int_ = QbSongClass1.AddKeyToDictionary("songs\\" + string0 + ".mid.qb");
            string[] array =
            {
                "",
                "rhythm_",
                "guitarcoop_",
                "rhythmcoop_",
                "aux_"
            };
            for (int i = 0; i < array.Length; i++)
            {
                string str = array[i];
                string[] array2 =
                {
                    "easy",
                    "medium",
                    "hard",
                    "expert"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string str2 = array2[j];
                    string text = str + str2;
                    if (NoteList.ContainsKey(text))
                    {
                        method_5(int_, string0 + "_song_" + text, @class, NoteList[text]);
                    }
                    else
                    {
                        method_11(int_, string0 + "_song_" + text, @class);
                    }
                    if (SpList.ContainsKey(text))
                    {
                        method_6(int_, string0 + "_" + text + "_star", @class, SpList[text]);
                    }
                    else
                    {
                        method_11(int_, string0 + "_" + text + "_star", @class);
                    }
                    if (BattleNoteList.ContainsKey(text))
                    {
                        method_6(int_, string0 + "_" + text + "_starbattlemode", @class, BattleNoteList[text]);
                    }
                    else
                    {
                        method_11(int_, string0 + "_" + text + "_starbattlemode", @class);
                    }
                }
            }
            method_7(int_, string0 + "_faceoffp1", @class, Class2282);
            method_7(int_, string0 + "_faceoffp2", @class, Class2283);
            method_7(int_, string0 + "_bossbattlep1", @class, BpmList);
            method_7(int_, string0 + "_bossbattlep2", @class, Class2285);
            method_8(int_, string0 + "_timesig", @class);
            method_9(int_, string0 + "_fretbars", @class);
            method_10(int_, string0 + "_markers", @class);
            method_11(int_, string0 + "_scripts_notes", @class);
            method_11(int_, string0 + "_anim_notes", @class);
            method_11(int_, string0 + "_triggers_notes", @class);
            method_11(int_, string0 + "_cameras_notes", @class);
            method_11(int_, string0 + "_lightshow_notes", @class);
            method_11(int_, string0 + "_crowd_notes", @class);
            method_11(int_, string0 + "_drums_notes", @class);
            method_11(int_, string0 + "_performance_notes", @class);
            method_11(int_, string0 + "_scripts", @class);
            method_11(int_, string0 + "_anim", @class);
            method_11(int_, string0 + "_triggers", @class);
            method_11(int_, string0 + "_cameras", @class);
            method_11(int_, string0 + "_lightshow", @class);
            method_11(int_, string0 + "_crowd", @class);
            method_11(int_, string0 + "_drums", @class);
            method_11(int_, string0 + "_performance", @class);
            return @class;
        }

        private void method_5(int int2, string string0, ZzGenericNode1 class3080, Track<int, NotesAtOffset> class2287)
        {
            if (class2287.Keys.Count == 0)
            {
                method_11(int2, string0, class3080);
                return;
            }
            List<int> list = new List<int>();
            foreach (int current in class2287.Keys)
            {
                list.Add(current);
                list.Add(class2287[current].SustainLength);
                list.Add(class2287[current].method_0());
            }
            class3080.addChild(new ArrayPointerRootNode(string0, int2, new IntegerArrayNode(list)));
        }

        private void method_6(int int2, string string0, ZzGenericNode1 class3080, Track<int, int[]> class2287)
        {
            if (class2287.Keys.Count == 0)
            {
                method_11(int2, string0, class3080);
                return;
            }
            ListArrayNode @class = new ListArrayNode();
            foreach (int current in class2287.Keys)
            {
                @class.addChild(new IntegerArrayNode(new[]
                {
                    current,
                    class2287[current][0],
                    class2287[current][1]
                }));
            }
            class3080.addChild(new ArrayPointerRootNode(string0, int2, @class));
        }

        private void method_7(int int2, string string0, ZzGenericNode1 class3080, Track<int, int> class2287)
        {
            if (class2287.Keys.Count == 0)
            {
                method_11(int2, string0, class3080);
                return;
            }
            ListArrayNode @class = new ListArrayNode();
            foreach (int current in class2287.Keys)
            {
                @class.addChild(new IntegerArrayNode(new[]
                {
                    current,
                    class2287[current]
                }));
            }
            class3080.addChild(new ArrayPointerRootNode(string0, int2, @class));
        }

        private void method_8(int int2, string string0, ZzGenericNode1 class3080)
        {
            ListArrayNode @class = new ListArrayNode();
            foreach (int current in TsList.Keys)
            {
                @class.addChild(new IntegerArrayNode(new[]
                {
                    current,
                    TsList[current][0],
                    TsList[current][1]
                }));
            }
            class3080.addChild(new ArrayPointerRootNode(string0, int2, @class));
        }

        private void method_9(int int2, string string0, ZzGenericNode1 class3080)
        {
            class3080.addChild(new ArrayPointerRootNode(string0, int2, new IntegerArrayNode(FretbarList)));
        }

        private void method_10(int int2, string string0, ZzGenericNode1 class3080)
        {
            if (Class2281.Keys.Count == 0)
            {
                method_11(int2, string0, class3080);
                return;
            }
            StructureArrayNode @class = new StructureArrayNode();
            foreach (int current in Class2281.Keys)
            {
                @class.addChild(new StructureHeaderNode(new ZzUnkNode294[]
                {
                    new IntegerStructureNode("time", current),
                    new UnicodeStructureNode("marker", Class2281[current])
                }));
            }
            class3080.addChild(new ArrayPointerRootNode(string0, int2, @class));
        }

        private void method_11(int int2, string string0, ZzGenericNode1 class3080)
        {
            class3080.addChild(new ArrayPointerRootNode(string0, int2, _class2870));
        }
    }
}