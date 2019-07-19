using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI = SharpDX.DirectInput;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Contains pretty much every possible keyboard key constant
    /// </summary>
    public enum Key
    {
        /// <summary>
        /// A key
        /// </summary>
        A = DI.Key.A,
        /// <summary>
        /// B key
        /// </summary>
        B = DI.Key.B,
        /// <summary>
        /// C key
        /// </summary>
        C = DI.Key.C,
        /// <summary>
        /// D key
        /// </summary>
        D = DI.Key.D,
        /// <summary>
        /// E key
        /// </summary>
        E = DI.Key.E,
        /// <summary>
        /// F key
        /// </summary>
        F = DI.Key.F,
        /// <summary>
        /// G key
        /// </summary>
        G = DI.Key.G,
        /// <summary>
        /// H key
        /// </summary>
        H = DI.Key.H,
        /// <summary>
        /// I key
        /// </summary>
        I = DI.Key.I,
        /// <summary>
        /// J key
        /// </summary>
        J = DI.Key.J,
        /// <summary>
        /// K key
        /// </summary>
        K = DI.Key.K,
        /// <summary>
        /// L key
        /// </summary>
        L = DI.Key.L,
        /// <summary>
        /// M key
        /// </summary>
        M = DI.Key.M,
        /// <summary>
        /// N key
        /// </summary>
        N = DI.Key.N,
        /// <summary>
        /// O key
        /// </summary>
        O = DI.Key.O,
        /// <summary>
        /// P key
        /// </summary>
        P = DI.Key.P,
        /// <summary>
        /// Q key
        /// </summary>
        Q = DI.Key.Q,
        /// <summary>
        /// R key
        /// </summary>
        R = DI.Key.R,
        /// <summary>
        /// S key
        /// </summary>
        S = DI.Key.S,
        /// <summary>
        /// T key
        /// </summary>
        T = DI.Key.T,
        /// <summary>
        /// U key
        /// </summary>
        U = DI.Key.U,
        /// <summary>
        /// V key
        /// </summary>
        V = DI.Key.V,
        /// <summary>
        /// W key
        /// </summary>
        W = DI.Key.W,
        /// <summary>
        /// X key
        /// </summary>
        X = DI.Key.X,
        /// <summary>
        /// Y key
        /// </summary>
        Y = DI.Key.Y,
        /// <summary>
        /// Z key
        /// </summary>
        Z = DI.Key.Z,
        /// <summary>
        /// Also Tilda (~) key
        /// </summary>
        Grave = DI.Key.Grave,
        /// <summary>
        /// 0-) key
        /// </summary>
        MainDigit0 = DI.Key.D0,
        /// <summary>
        /// 1-! key
        /// </summary>
        MainDigit1 = DI.Key.D1,
        /// <summary>
        /// 2-@ key
        /// </summary>
        MainDigit2 = DI.Key.D2,
        /// <summary>
        /// 3-# key
        /// </summary>
        MainDigit3 = DI.Key.D3,
        /// <summary>
        /// 4-$ key
        /// </summary>
        MainDigit4 = DI.Key.D4,
        /// <summary>
        /// 5-% key
        /// </summary>
        MainDigit5 = DI.Key.D5,
        /// <summary>
        /// 6-^ key
        /// </summary>
        MainDigit6 = DI.Key.D6,
        /// <summary>
        /// 7-&amp; key
        /// </summary>
        MainDigit7 = DI.Key.D7,
        /// <summary>
        /// 8-* key
        /// </summary>
        MainDigit8 = DI.Key.D8,
        /// <summary>
        /// 9-( key
        /// </summary>
        MainDigit9 = DI.Key.D9,
        /// <summary>
        /// Minus and Underscore key
        /// </summary>
        Minus = DI.Key.Minus,
        /// <summary>
        /// Equals and Plus key
        /// </summary>
        Equals = DI.Key.Equals,
        /// <summary>
        /// Backspace key
        /// </summary>
        Backspace = DI.Key.Back,
        /// <summary>
        /// Escape key
        /// </summary>
        Escape = DI.Key.Escape,
        /// <summary>
        /// F1 key
        /// </summary>
        F1 = DI.Key.F1,
        /// <summary>
        /// F2 key
        /// </summary>
        F2 = DI.Key.F2,
        /// <summary>
        /// F3 key
        /// </summary>
        F3 = DI.Key.F3,
        /// <summary>
        /// F4 key
        /// </summary>
        F4 = DI.Key.F4,
        /// <summary>
        /// F5 key
        /// </summary>
        F5 = DI.Key.F5,
        /// <summary>
        /// F6 key
        /// </summary>
        F6 = DI.Key.F6,
        /// <summary>
        /// F7 key
        /// </summary>
        F7 = DI.Key.F7,
        /// <summary>
        /// F8 key
        /// </summary>
        F8 = DI.Key.F8,
        /// <summary>
        /// F9 key
        /// </summary>
        F9 = DI.Key.F9,
        /// <summary>
        /// F10 key
        /// </summary>
        F10 = DI.Key.F10,
        /// <summary>
        /// F11 key
        /// </summary>
        F11 = DI.Key.F11,
        /// <summary>
        /// F12 key
        /// </summary>
        F12 = DI.Key.F12,
        /// <summary>
        /// F13 key (PC-98 Japanese keyboards)
        /// </summary>
        F13 = DI.Key.F13,
        /// <summary>
        /// F14 key (PC-98 Japanese keyboards)
        /// </summary>
        F14 = DI.Key.F14,
        /// <summary>
        /// F15 key (PC-98 Japanese keyboards)
        /// </summary>
        F15 = DI.Key.F15,
        /// <summary>
        /// Print Screen and System Request key
        /// </summary>
        PrintScreen = DI.Key.PrintScreen,
        /// <summary>
        /// Scroll Lock key
        /// </summary>
        ScrollLock = DI.Key.ScrollLock,
        /// <summary>
        /// Pause and Break key
        /// </summary>
        Pause = DI.Key.Pause,
        /// <summary>
        /// Insert key
        /// </summary>
        Insert = DI.Key.Insert,
        /// <summary>
        /// Delete key
        /// </summary>
        Delete = DI.Key.Delete,
        /// <summary>
        /// Home key
        /// </summary>
        Home = DI.Key.Home,
        /// <summary>
        /// End key
        /// </summary>
        End = DI.Key.End,
        /// <summary>
        /// Page Up key
        /// </summary>
        PageUp = DI.Key.PageUp,
        /// <summary>
        /// Page Down key
        /// </summary>
        PageDown = DI.Key.PageDown,
        /// <summary>
        /// Left Arrow key
        /// </summary>
        LeftArrow = DI.Key.Left,
        /// <summary>
        /// Right Arrow key
        /// </summary>
        RightArrow = DI.Key.Right,
        /// <summary>
        /// Up Arrow key
        /// </summary>
        UpArrow = DI.Key.Up,
        /// <summary>
        /// Down Arrow key
        /// </summary>
        DownArrow = DI.Key.Down,
        /// <summary>
        /// Tab key
        /// </summary>
        Tab = DI.Key.Tab,
        /// <summary>
        /// CAPS LOCK KEY
        /// </summary>
        CapsLock = DI.Key.Capital,
        /// <summary>
        /// Left Shift Key
        /// </summary>
        LeftShift = DI.Key.LeftShift,
        /// <summary>
        /// Left Control key
        /// </summary>
        LeftControl = DI.Key.LeftControl,
        /// <summary>
        /// Left Windows key
        /// </summary>
        LeftWindows = DI.Key.LeftWindowsKey,
        /// <summary>
        /// Left Alt key
        /// </summary>
        LeftAlt = DI.Key.LeftAlt, 
        /// <summary>
        /// Space (long one) key
        /// </summary>
        Space = DI.Key.Space,
        /// <summary>
        /// Right Alt key
        /// </summary>
        RightAlt = DI.Key.RightAlt,
        /// <summary>
        /// Right Windows key
        /// </summary>
        RightWindows = DI.Key.RightWindowsKey,
        /// <summary>
        /// Also context menu key
        /// </summary>
        Applications = DI.Key.Applications,
        /// <summary>
        /// Right Control key
        /// </summary>
        RightControl = DI.Key.RightControl,
        /// <summary>
        /// righT shifT keY
        /// </summary>
        RightShift = DI.Key.RightShift,
        /// <summary>
        /// Enter (Return) key
        /// </summary>
        Enter = DI.Key.Return,
        /// <summary>
        /// Left square ([) bracket key
        /// </summary>
        LeftBracket = DI.Key.LeftBracket,
        /// <summary>
        /// Right square (]) bracket key
        /// </summary>
        RightBracket = DI.Key.RightBracket,
        /// <summary>
        /// Backslash (\) key
        /// </summary>
        Backslash = DI.Key.Backslash,
        /// <summary>
        /// Slash (/) key
        /// </summary>
        Slash = DI.Key.Slash,
        /// <summary>
        /// Comma key
        /// </summary>
        Comma = DI.Key.Comma,
        /// <summary>
        /// Period key
        /// </summary>
        Period = DI.Key.Period,
        /// <summary>
        /// Semicolon key
        /// </summary>
        Semicolon = DI.Key.Semicolon,
        /// <summary>
        /// Apostrophe key
        /// </summary>
        Apostrophe = DI.Key.Apostrophe,
        /// <summary>
        /// Num Lock key
        /// </summary>
        NumLock = DI.Key.NumberLock,
        /// <summary>
        /// Num-Divide (Num-/) key
        /// </summary>
        NumDivide = DI.Key.Divide,
        /// <summary>
        /// Num-Multiply (Num-*) key
        /// </summary>
        NumMultiply = DI.Key.Multiply,
        /// <summary>
        /// Num-Subtract (Num-Minus) key
        /// </summary>
        NumMinus = DI.Key.Subtract,
        /// <summary>
        /// Num-Add (Num-+) key
        /// </summary>
        NumPlus = DI.Key.Add,
        /// <summary>
        /// Num-Enter key
        /// </summary>
        NumEnter = DI.Key.NumberPadEnter,
        /// <summary>
        /// Num-Comma key (PC-98 Japanese keyboards)
        /// </summary>
        NumComma = DI.Key.NumberPadComma,
        /// <summary>
        /// Num-Equals key (PC-98 Japanese keyboards)
        /// </summary>
        NumEquals = DI.Key.NumberPadEquals,
        /// <summary>
        /// Num-Decimal (Num-.) key
        /// </summary>
        NumDecimal = DI.Key.Decimal,
        /// <summary>
        /// Num-0 key
        /// </summary>
        Num0 = DI.Key.NumberPad0,
        /// <summary>
        /// Num-1 key
        /// </summary>
        Num1 = DI.Key.NumberPad1,
        /// <summary>
        /// Num-2 key
        /// </summary>
        Num2 = DI.Key.NumberPad2,
        /// <summary>
        /// Num-3 key
        /// </summary>
        Num3 = DI.Key.NumberPad3,
        /// <summary>
        /// Num-4 key
        /// </summary>
        Num4 = DI.Key.NumberPad4,
        /// <summary>
        /// Num-5 key
        /// </summary>
        Num5 = DI.Key.NumberPad5,
        /// <summary>
        /// Num-6 key
        /// </summary>
        Num6 = DI.Key.NumberPad6,
        /// <summary>
        /// Num-7 key
        /// </summary>
        Num7 = DI.Key.NumberPad7,
        /// <summary>
        /// Num-8 key
        /// </summary>
        Num8 = DI.Key.NumberPad8,
        /// <summary>
        /// Num-9 key
        /// </summary>
        Num9 = DI.Key.NumberPad9,
        /// <summary>
        /// On numeric pad of Brazilian keyboards
        /// </summary>
        AbntC1 = DI.Key.AbntC1,
        /// <summary>
        /// On numeric pad of Brazilian keyboards
        /// </summary>
        AbntC2 = DI.Key.AbntC2,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        AT = DI.Key.AT,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        AX = DI.Key.AX,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        Colon = DI.Key.Colon,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        Convert = DI.Key.Convert,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        NoConvert = DI.Key.NoConvert,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        Kana = DI.Key.Kana,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        Kanji = DI.Key.Kanji,
        /// <summary>
        /// On British and German keyboards
        /// </summary>
        Oem102 = DI.Key.Oem102,
        /// <summary>
        /// On NEC PC-98 Japanese keyboards
        /// </summary>
        Stop = DI.Key.Stop,
        /// <summary>
        /// On NEC PC-98 Japanese keyboards
        /// </summary>
        Underline = DI.Key.Underline,
        /// <summary>
        /// On Japanese keyboards
        /// </summary>
        Unlabeled = DI.Key.Unlabeled,
        /// <summary>
        /// On Japanese keyboards (probably Yen sign)
        /// </summary>
        Yen = DI.Key.Yen,
        /// <summary>
        /// Back key for navigating Internet Browser
        /// </summary>
        WebBack = DI.Key.WebBack,
        /// <summary>
        /// Forward key for navigating Internet Browser
        /// </summary>
        WebForward = DI.Key.WebForward,
        /// <summary>
        /// Favorites key for navigating Internet Browser
        /// </summary>
        WebFavorites = DI.Key.WebFavorites,
        /// <summary>
        /// Home key for navigating Internet Browser
        /// </summary>
        WebHome = DI.Key.WebHome,
        /// <summary>
        /// Refresh key for refreshing page in Internet Browser
        /// </summary>
        WebRefresh = DI.Key.WebRefresh,
        /// <summary>
        /// Stop key for stop loading page in Internet Browser
        /// </summary>
        WebStop = DI.Key.WebStop,
        /// <summary>
        /// Search key for search in Internet Browser
        /// </summary>
        WebSearch = DI.Key.WebSearch,
        /// <summary>
        /// Wake key
        /// </summary>
        Wake = DI.Key.Wake,
        /// <summary>
        /// Sleep key
        /// </summary>
        Sleep = DI.Key.Sleep,
        /// <summary>
        /// Power key
        /// </summary>
        Power = DI.Key.Power,
        /// <summary>
        /// Volume Down key
        /// </summary>
        VolumeDown = DI.Key.VolumeDown,
        /// <summary>
        /// Volume Up key
        /// </summary>
        VolumeUp = DI.Key.VolumeUp,
        /// <summary>
        /// Mute key (silence...)
        /// </summary>
        Mute = DI.Key.Mute,
        /// <summary>
        /// Previous Track key. Circumflex on Japanese keyboard
        /// </summary>
        PreviousTrack = DI.Key.PreviousTrack,
        /// <summary>
        /// Next Track key
        /// </summary>
        NextTrack = DI.Key.NextTrack,
        /// <summary>
        /// Play/Pause key
        /// </summary>
        MediaPlayPause = DI.Key.PlayPause,
        /// <summary>
        /// Stop key
        /// </summary>
        MediaStop = DI.Key.MediaStop,
        /// <summary>
        /// My Computer key
        /// </summary>
        MyComputer = DI.Key.MyComputer,
        /// <summary>
        /// Mail key
        /// </summary>
        Mail = DI.Key.Mail,
        /// <summary>
        /// Calculator key
        /// </summary>
        Calculator = DI.Key.Calculator,
        /// <summary>
        /// Unknown key
        /// </summary>
        Unknown = DI.Key.Unknown
    }
}
