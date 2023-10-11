namespace AbsolutelyNoHotkey.Concepts
{
    /// <summary>
    /// Written based on game version 2.0.206.3 Early Access
    /// Symbol reference:
    /// https://wiki.cavesofqud.com/wiki/Modding:Code_page_437
    /// </summary>
    public static class Symbol
    {
        public const int CODE_PAGE_MAX = 255;

        public const char ITEM = (char) 7;
        public const char GROUP = (char) 254;

        public static char GetHotkey(int pos)
        {
            if (pos < HOTKEYS.Length)
            {
                return HOTKEYS[pos];
            }
            return (char) (pos + CODE_PAGE_MAX);
        }

        public static readonly char[] HOTKEYS = {
            (char) 224,
            (char) 225,
            (char) 226,
            (char) 227,
            (char) 228,
            (char) 229,
            (char) 230,
            (char) 231,
            (char) 232,
            (char) 234,
            (char) 235,
            (char) 236,
            (char) 237,
            (char) 238,
            (char) 239,
            (char) 3,
            (char) 4,
            (char) 5,
            (char) 6,
            (char) 13,
            (char) 14,
            (char) 15,
            (char) 20,
            (char) 21,
            (char) 128,
            (char) 129,
            (char) 130,
            (char) 131,
            (char) 11,
            (char) 12,
            (char) 7,
            (char) 9,
        };
    }
}
